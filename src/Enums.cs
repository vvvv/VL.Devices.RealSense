﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Lib.Collections;
using VL.Core;

namespace VL.Devices.RealSense
{

    public class RealSenseDeviceDefinition : ManualDynamicEnumDefinitionBase<RealSenseDeviceDefinition>
    {

        //add this to get a node that can access the Instance from everywhere
        public static RealSenseDeviceDefinition Instance => ManualDynamicEnumDefinitionBase<RealSenseDeviceDefinition>.Instance;
        override protected bool AutoSortAlphabetically => false;
    }

    [Serializable]
    public class RealSenseDevice : DynamicEnumBase<RealSenseDevice, RealSenseDeviceDefinition>
    {
        public RealSenseDevice(string value) : base(value)
        {
        }

        //this method needs to be imported in VL to set the default
        public static RealSenseDevice CreateDefault()
        {
            //use method of base class if nothing special required
            return CreateDefaultBase();
        }
    }

    public class DepthResolutionDefinition : ManualDynamicEnumDefinitionBase<DepthResolutionDefinition>
    {

        //add this to get a node that can access the Instance from everywhere
        public static DepthResolutionDefinition Instance => ManualDynamicEnumDefinitionBase<DepthResolutionDefinition>.Instance;
        override protected bool AutoSortAlphabetically => false;
    }

    [Serializable]
    public class DepthResolution : DynamicEnumBase<DepthResolution, DepthResolutionDefinition>
    {
        public DepthResolution(string value) : base(value)
        {
        }

        //this method needs to be imported in VL to set the default
        public static DepthResolution CreateDefault()
        {
            //use method of base class if nothing special required
            return CreateDefaultBase();
        }
    }

    public class ColorResolutionDefinition : ManualDynamicEnumDefinitionBase<ColorResolutionDefinition>
    {

        //add this to get a node that can access the Instance from everywhere
        public static ColorResolutionDefinition Instance => ManualDynamicEnumDefinitionBase<ColorResolutionDefinition>.Instance;
        override protected bool AutoSortAlphabetically => false;
    }

    [Serializable]
    public class ColorResolution : DynamicEnumBase<ColorResolution, ColorResolutionDefinition>
    {
        public ColorResolution (string value) : base(value)
        {
        }

        //this method needs to be imported in VL to set the default
        public static ColorResolution CreateDefault()
        {
            //use method of base class if nothing special required
            return CreateDefaultBase();
        }
    }

    public class ColorFramerateDefinition : ManualDynamicEnumDefinitionBase<ColorFramerateDefinition>
    {

        //add this to get a node that can access the Instance from everywhere
        public static ColorFramerateDefinition Instance => ManualDynamicEnumDefinitionBase<ColorFramerateDefinition>.Instance;
        override protected bool AutoSortAlphabetically => false;
    }

    [Serializable]
    public class ColorFramerate : DynamicEnumBase<ColorFramerate, ColorFramerateDefinition>
    {
        public ColorFramerate (string value) : base(value)
        {
        }

        //this method needs to be imported in VL to set the default
        public static ColorFramerate CreateDefault()
        {
            //use method of base class if nothing special required
            return CreateDefaultBase();
        }
    }

    public class DepthFramerateDefinition : ManualDynamicEnumDefinitionBase<DepthFramerateDefinition>
    {

        //add this to get a node that can access the Instance from everywhere
        public static DepthFramerateDefinition Instance => ManualDynamicEnumDefinitionBase<DepthFramerateDefinition>.Instance;
        override protected bool AutoSortAlphabetically => false;
    }

    [Serializable]
    public class DepthFramerate : DynamicEnumBase<DepthFramerate, DepthFramerateDefinition>
    {
        public DepthFramerate (string value) : base(value)
        {
        }

        //this method needs to be imported in VL to set the default
        public static DepthFramerate CreateDefault()
        {
            //use method of base class if nothing special required
            return CreateDefaultBase();
        }
    }

}