# VL.Devices.RealSense
Set of nodes to use [Intel RealSense](https://www.intelrealsense.com/) devices in vl

We are entering testing phase.

At the moment you have to build a small C# project in oder to use the library.

### 1. Clone this repository

Clone it into a directory like:
 
    X:\vl-libs\VL.Devices.RealSense

### 2. Build the C# Project
Open

    X:\vl-libs\VL.Devices.RealSense\src\VL.Devices.RealSense.sln
    
in VisualStudio and build it. This is necessary for a few things that cannot yet be expressed in vl directly.

### 3. Reference VL.Devices.RealSense.vl

In the vl document where you want to have access to the RealSense nodeset, add a dependency to:

	X:\vl-libs\VL.Devices.RealSense\VL.Devices.RealSense.vl

The available RealSense nodes should appear in the nodebrowser under Devices > RealSense.

## Test Patch

At the moment we have this tester vl document:

	X:\vl-libs\VL.Devices.RealSense\help\Intel\RealSense\HowTo RealSense-Tester.vl
