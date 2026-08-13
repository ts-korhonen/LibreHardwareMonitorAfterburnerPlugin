cmake_minimum_required(VERSION 3.15)
project(Debugger)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_FLAGS_INIT "-m32 /Z7")

include(FetchContent)

FetchContent_Declare(
    cpptui
    GIT_REPOSITORY https://github.com/jonoton/cpp-tui.git
    GIT_TAG        9543ee3c056583eea1fc44491c6c240f0df0b570 # 1.12.0
)

FetchContent_MakeAvailable(cpptui)

if(MSVC)
        add_compile_options(/utf-8)
        target_compile_options(cpptui INTERFACE /W0)
    else()
        target_compile_options(cpptui INTERFACE -w)
endif()

find_path(MSI_SDK_INCLUDE_DIR MSIAfterburnerMonitoringSourceDesc.h PATH_SUFFIXES "MSI Afterburner/SDK/Include" REQUIRED)

include_directories("${MSI_SDK_INCLUDE_DIR}")

add_executable(Debugger Debugger.cpp)

set_target_properties(Debugger PROPERTIES RUNTIME_OUTPUT_DIRECTORY "${CMAKE_SOURCE_DIR}/bin")
set_target_properties(Debugger PROPERTIES PDB_OUTPUT_DIRECTORY "${CMAKE_SOURCE_DIR}/bin")

target_link_libraries(Debugger PRIVATE cpptui::cpptui)
