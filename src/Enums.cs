using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Lib.Collections;
using VL.Core;
using Intel.RealSense;
using System.Reactive.Linq;
using VL.Core.CompilerServices;

namespace VL.Devices.RealSense
{
    //https://github.com/IntelRealSense/librealsense/blob/e1688cc318457f7dd57abcdbedd3398062db3009/wrappers/unity/Assets/RealSenseSDK2.0/Scripts/ProcessingBlocks/RsSpatialFilter.cs#L29
    public enum HoleFillingMode
    {
        Disabled,
        HoleFill2PixelRadius,
        HoleFill4PixelRadius,
        HoleFill8PixelRadius,
        HoleFill16PixelRadius,
        Unlimited,
    }

    //https://github.com/IntelRealSense/librealsense/blob/e1688cc318457f7dd57abcdbedd3398062db3009/wrappers/unity/Assets/RealSenseSDK2.0/Scripts/ProcessingBlocks/RsTemporalFilter.cs#L23
    public enum PersistencyMode
    {
        Disabled, //Persistency filter is not activated and no hole filling occurs.
        ValidIn8of8, //Persistency activated if the pixel was valid in 8 out of the last 8 frames
        ValidIn2ofLast3, //Activated if the pixel was valid in two out of the last 3 frames
        ValidIn2ofLast4, //Activated if the pixel was valid in two out of the last 4 frames
        ValidIn2of8, //Activated if the pixel was valid in two out of the last 8 frames
        ValidIn1ofLast2, //Activated if the pixel was valid in one of the last two frames
        ValidIn1ofLast5, //Activated if the pixel was valid in one out of the last 5 frames
        ValidIn1ofLast8, //Activated if the pixel was valid in one out of the last 8 frames
        AlwaysOn //Persistency will be imposed regardless of the stored history(most aggressive filtering)
    }

    public class RealSenseDeviceDefinition : DynamicEnumDefinitionBase<RealSenseDeviceDefinition>
    {

        //inform the system that the enum has changed
        protected override IObservable<object> GetEntriesChangedObservable()
        {
            return Observable.Empty<object>();
        }

        protected override IReadOnlyDictionary<string, object> GetEntries()
        {
            Dictionary<string, object> cameraNames = new Dictionary<string, object>();

            //Add Default Entry
            cameraNames["Default"] = "Default";

            DeviceList devices;

            using (var ctx = new Context())
            {
                devices = ctx.QueryDevices();
            }

            foreach (var device in devices)
            {
                var cameraName = device.Info.GetInfo(CameraInfo.Name);
                var serialNumber = device.Info.GetInfo(CameraInfo.SerialNumber);

                cameraNames[cameraName + ": " + serialNumber] = serialNumber; 
            }

            return cameraNames;
        }

        //optionally disable alphabetic sorting
        protected override bool AutoSortAlphabetically => true; //true is the default
    }

    [Serializable]
    public class RealSenseDevice : DynamicEnumBase<RealSenseDevice, RealSenseDeviceDefinition>
    {
        //return the current enum entries
        public RealSenseDevice(string value) : base(value)
        {
        }

        [CreateDefault]
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

        [CreateDefault]
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

        [CreateDefault]
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

        [CreateDefault]
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

        [CreateDefault]
        public static DepthFramerate CreateDefault()
        {
            //use method of base class if nothing special required
            return CreateDefaultBase();
        }
    }

}
