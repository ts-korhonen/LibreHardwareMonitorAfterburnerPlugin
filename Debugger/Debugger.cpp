/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

#define NOMINMAX

#include <windows.h>
#include <stdlib.h>
#include <conio.h>

#include <bit>
#include <iostream>
#include <charconv>
#include <string>
#include <thread>

#include "MSIAfterburnerMonitoringSourceDesc.h"

typedef bool(__cdecl* pSetupSource)(DWORD dwIndex, HWND hWnd);
typedef DWORD(__cdecl* pGetSourcesNum)();
typedef bool(__cdecl* pGetSourceDesc)(DWORD dwIndex, LPMONITORING_SOURCE_DESC pDesc);
typedef float(__cdecl* pGetSourceData)(DWORD dwIndex);

static HANDLE menu_event = nullptr;

int main(int argc, const char* argv[])
{
    if (argc != 2)
        return -1;

    std::ios_base::sync_with_stdio(false);

    menu_event = CreateEvent(nullptr, TRUE, FALSE, TEXT("LHMAP_DEBUGGER_MENU_EVENT"));

    if (menu_event == nullptr)
        return -1;

    auto library = LoadLibrary(TEXT(argv[1]));

    if (library == nullptr)
        return -1;

    auto SetupSource = std::bit_cast<pSetupSource>(GetProcAddress(library, "SetupSource"));
    auto GetSourcesNum = std::bit_cast<pGetSourcesNum>(GetProcAddress(library, "GetSourcesNum"));
    auto GetSourceDesc = std::bit_cast<pGetSourceDesc>(GetProcAddress(library, "GetSourceDesc"));
    auto GetSourceData = std::bit_cast<pGetSourceData>(GetProcAddress(library, "GetSourceData"));

    bool run = true;

    std::thread keyb([&run]() {

        while (run)
        {
            if (_kbhit())
                SetEvent(menu_event);
        }
    });

    while (run)
    {
        auto sNum = GetSourcesNum();

        system("cls");

        std::cout << sNum << " sources.\n\n";

        for (DWORD idx = 0; idx < sNum; idx++)
        {
            MONITORING_SOURCE_DESC desc;
            if (GetSourceDesc(idx, &desc))
            {
                float data = GetSourceData(idx);

                std::cout << desc.szName << ": " << data << "\n";
            }
            else
            {
                std::cout << "Error on index " << idx << "\n\n";
            }
        }

        std::cout << "\n\ns   - setup\n";
        std::cout << "s## - setup source ##\n";
        std::cout << "q   - quit\n\n";
        std::cout << "> ";

        auto menu_result = WaitForSingleObject(menu_event, 1000);

        if (menu_result == WAIT_OBJECT_0)
        {
            std::string input;

            std::getline(std::cin, input);

            if (input.length() > 0)
            {
                switch (input[0])
                {
                case 's':
                case 'S':
                    if (input.length() > 1)
                    {
                        DWORD idx{};
                        auto [ptr, ec] = std::from_chars(input.data() + 1, input.data() + input.size(), idx);
                        if (ec == std::errc())
                        {
                            SetupSource(idx, HWND(-1));
                        }
                    }
                    else
                        SetupSource(0xFFFFFFFF, HWND(-1));
                    break;
                case 'q':
                case 'Q':
                    run = false;
                    break;
                default:
                    break;
                }
            }

            ResetEvent(menu_event);
        }
    }

    FreeLibrary(library);

    CloseHandle(menu_event);

    keyb.join();
}
