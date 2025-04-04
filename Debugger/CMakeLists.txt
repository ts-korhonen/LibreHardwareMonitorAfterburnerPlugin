cmake_minimum_required(VERSION 3.15)
project(Debugger)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_FLAGS_INIT "-m32 /Z7")

find_path(MSI_SDK_INCLUDE_DIR MSIAfterburnerMonitoringSourceDesc.h PATH_SUFFIXES "MSI Afterburner/SDK/Include" REQUIRED)

include_directories("${MSI_SDK_INCLUDE_DIR}")

add_executable(Debugger Debugger.cpp)

set_target_properties(Debugger PROPERTIES RUNTIME_OUTPUT_DIRECTORY "${CMAKE_SOURCE_DIR}/bin")
set_target_properties(Debugger PROPERTIES PDB_OUTPUT_DIRECTORY "${CMAKE_SOURCE_DIR}/bin")