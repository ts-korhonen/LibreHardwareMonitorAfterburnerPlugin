# Simple launcher for debugging

This is a simple CLI program for quick access to the plugin's functions while debugging.

## Build

### Prerequisites

MSI Afterburner is needed for the SDK.

If using Visual Studio, the easy way is to install "Desktop development with C++" workload, which will have everything needed; C++ Compiler (MSVC or Clang), CMake and Ninja. 

### Build using CMake

Run the following commands in this directory:

`cmake -S . -B build -G Ninja`

`cmake --build build`

If for some reason the Afterburner SDK is not found automatically, the path can be specified using the `MSI_SDK_INCLUDE_DIR` variable:

`cmake -S . -B build -G Ninja -DMSI_SDK_INCLUDE_DIR="/path/to/MSI Afterburner/SDK/Include"`

`cmake --build build`

## Usage

Run "Launch Debugger App" profile.
