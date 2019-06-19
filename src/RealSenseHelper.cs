using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel.RealSense;

namespace VL.Devices.RealSense
{
    public static class RealSenseHelper
    {
        public static CustomProcessingBlock CreateCustomProcessingBlock(Action<Frame, FrameSource> cb)
        {
            return new CustomProcessingBlock((frame, source) => cb(frame, source));
        }

        public static CustomProcessingBlock StartCustomProcessingBlock(CustomProcessingBlock block, Action<Frame> cb)
        {
            block.Start(frame => cb(frame));
            return block;
        }
    }
}
