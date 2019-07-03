# VL.Devices.RealSense
Set of nodes to use [Intel RealSense](https://www.intelrealsense.com/) devices in vl.

The development is sponsored by [wirmachenbunt](https://wirmachenbunt.de/).

We are entering testing phase.

## Using the library
In order to use this library with vl you have to install the nuget that is available via nuget.org.

Open VL, go to 

    Quad menu > Manage Nugets > Commandline   

and then type:

    nuget install VL.Devices.RealSense -prerelease

Once the VL.Devices.RealSense nuget is installed and referenced in your vl document you'll see the category "RealSense" under "Devices" in the nodebrowser.

VL help patches can be found here:

    "VL.Devices.RealSense\help\"

## Contributing to the development

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
