using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Lib.Collections;
using VL.Core;

namespace VL.Devices.RealSense
{
    //public class RealSenseDevice
    //{
    //    public string Update(RealSenseDevice enumInput)
    //    {
    //        if (enumInput.IsValid())
    //            return enumInput.Definition.Entries[enumInput.SelectedIndex()];
    //        else
    //            return "No valid entry selected";
    //    }

    //    public RealSenseDeviceDefinition GetDefinition()
    //    {
    //        return RealSenseDevice.Instance;
    //    }

    //    public void AddEnumEntry(string entry)
    //    {
    //        RealSenseDeviceDefinition.Instance.AddEntry(entry, null);
    //    }

    //    public void RemoveEnumEntry(string entry)
    //    {
    //        RealSenseDeviceDefinition.Instance.RemoveEntry(entry);
    //    }
    //}

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

}
