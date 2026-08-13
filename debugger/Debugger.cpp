/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

#define NOMINMAX

#include <windows.h>

#include <atomic>
#include <bit>
#include <chrono>
#include <cstdio>
#include <format>
#include <iostream>
#include <memory>
#include <ostream>
#include <stop_token>
#include <string>
#include <string_view>
#include <thread>
#include <type_traits>
#include <vector>

#include "cpptui.hpp"

#include "MSIAfterburnerMonitoringSourceDesc.h"

typedef bool(__cdecl* pSetupSource)(DWORD dwIndex, HWND hWnd);
typedef DWORD(__cdecl* pGetSourcesNum)();
typedef bool(__cdecl* pGetSourceDesc)(DWORD dwIndex, LPMONITORING_SOURCE_DESC pDesc);
typedef float(__cdecl* pGetSourceData)(DWORD dwIndex);

struct Context {
    HMODULE library;
    cpptui::App& app;
    std::shared_ptr<cpptui::TableScrollable> table;
    std::shared_ptr<cpptui::StatusBar> status;
};

void loop(std::stop_token stop, Context&& ctx);
std::string fix_degree_symbol(std::string_view input);

int main(int argc, const char* argv[]) {
    if (argc != 2) {
        std::cout << "Provide path to plugin library." << std::endl;
        return -1;
    }

    auto library = LoadLibrary(TEXT(argv[1]));

    if (library == nullptr) {
        std::cout << "Loading plugin library failed." << std::endl;
        return -1;
    }

    auto SetupSource = std::bit_cast<pSetupSource>(GetProcAddress(library, "SetupSource"));

    using namespace cpptui;

    App app;

    Theme::set_theme(Theme::Dark());

    auto root = std::make_shared<Vertical>();

    auto content = std::make_shared<Border>(BorderStyle::Rounded);
    content->set_title("Sensor data");
    root->add(content);

    auto table = std::make_shared<TableScrollable>();
    table->focusable = false;
    table->columns = {"#", "Name", "Formatted", "Raw value"};
    content->add(table);

    auto footer = std::make_shared<Horizontal>();
    footer->auto_shrink = true;
    root->add(footer);

    auto shortcuts = std::make_shared<ShortcutBar>();
    shortcuts->add("Q","Quit");
    shortcuts->add("S","Setup");
    shortcuts->add("Ctrl+S","Setup selected source");
    footer->add(shortcuts);

    auto status = std::make_shared<StatusBar>();
    status->add_section("");
    status->add_section("");
    footer->add(status);

    table->on_change = [&](int i){
        status->sections[1].styled_content =
            StyledText().colored_bold(
                std::format("Selected: {}", i), Theme::current().primary);
    };

    app.register_exit_key('q');

    app.register_key('s', [&]() {
        SetupSource(0xFFFFFFFF, HWND(-1));
    });

    app.register_key('s', [&](){
        SetupSource(table->selected_index, HWND(-1));
    }, true);

    Context ctx = {
        library,
        app,
        table,
        status
    };

    auto loop_thread = std::jthread(loop, std::move(ctx));

    app.run(root);

    loop_thread.request_stop();
    loop_thread.join();

    FreeLibrary(library);

    return 0;
}

void loop(std::stop_token stop, Context&& ctx) {

    std::atomic_flag update_guard {};

    auto GetSourcesNum = std::bit_cast<pGetSourcesNum>(GetProcAddress(ctx.library, "GetSourcesNum"));
    auto GetSourceDesc = std::bit_cast<pGetSourceDesc>(GetProcAddress(ctx.library, "GetSourceDesc"));
    auto GetSourceData = std::bit_cast<pGetSourceData>(GetProcAddress(ctx.library, "GetSourceData"));

    while (!stop.stop_requested()) {
        using std::operator""ms;
        auto loop_start = std::chrono::steady_clock::now();

        auto sNum = GetSourcesNum();

        std::vector<std::vector<cpptui::StyledText>> sensors;

        for (DWORD idx = 0; idx < sNum; idx++) {
            using namespace cpptui;

            MONITORING_SOURCE_DESC desc;
            if (GetSourceDesc(idx, &desc)) {
                float data = GetSourceData(idx);

                int size = std::snprintf(nullptr, 0, desc.szFormat, data);
                std::string fmt_data(size, '\0');
                std::snprintf(fmt_data.data(), size+1, desc.szFormat, data);

                auto& row = sensors.emplace_back();

                row.emplace_back().colored(
                    std::to_string(idx),
                    Theme::current().success);
                row.emplace_back().colored(
                    desc.szName,
                    Theme::current().primary);
                row.emplace_back().colored(
                    std::format("{} {}",fmt_data, fix_degree_symbol(desc.szUnits)),
                    Theme::current().secondary);
                row.emplace_back().colored(
                    std::to_string(data),
                    Theme::current().warning);
            }
            else {
                // Error
                auto& row = sensors.emplace_back();
                row.emplace_back().colored(
                    std::format("{} error!", idx),
                    Theme::current().error);
                row.resize(4, StyledText().colored(
                    "---",
                    Theme::current().error));
            }
        }

        if (!update_guard.test_and_set()) {
            ctx.app.post([&ctx, &update_guard, sNum, new_rows=std::move(sensors)]() mutable {
                using namespace cpptui;

                if (sNum > 0) {
                    ctx.status->sections[0].styled_content =
                        StyledText().colored_bold(std::format("Sensors: {}", sNum),
                            Theme::current().primary);

                    ctx.status->sections[1].styled_content =
                        StyledText().colored_bold(
                            std::format("Selected: {}", ctx.table->selected_index),
                                Theme::current().primary);
                }
                else {
                    ctx.status->sections[0].styled_content = "No sensors";
                    ctx.status->sections[1].styled_content = "";
                }

                ctx.table->rows = std::move(new_rows);
                ctx.table->col_widths = { 6, ctx.table->width-41, 15, 20 };
                update_guard.clear();
            });
        }

        std::this_thread::sleep_until(loop_start + 1000ms);
    }
}

/** Convert CP-1252 degree character to UTF-8 symbol */
std::string fix_degree_symbol(std::string_view input) {
    std::string result;
    result.reserve(input.size() + 4);

    for (char c : input) {
        if (static_cast<unsigned char>(c) == 0xB0) {
            result += "\xC2\xB0";
        }
        else {
            result += c;
        }
    }

    return result;
}