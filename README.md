# VL.Devices.RealSense
Set of nodes to use [Intel RealSense](https://www.intelrealsense.com/) depth cameras in vl.

Try it with vvvv, the visual live-programming environment for .NET  
Download: http://visualprogramming.net

The development was sponsored by [wirmachenbunt](https://wirmachenbunt.de/).

## Using the library
In order to use this library with vl you have to install the nuget that is available via nuget.org.

Open VL, go to 

    Quad menu > Manage Nugets > Commandline   

and then type:

    nuget install VL.Devices.RealSense -prerelease

For more about installing and referencing nugets [read here](https://vvvv.gitbooks.io/the-gray-book/content/en/reference/libraries/dependencies.html#_manage_nugets).

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
