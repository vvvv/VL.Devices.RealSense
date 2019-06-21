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

        // Workaround for https://github.com/vvvv/vvvv/issues/4855
        public static T FirstOrDefaultGeneric<T>(this FrameSet frameSet, Stream stream, Format format = Format.Any) where T : Frame
        {
            return frameSet.FirstOrDefault<T>(stream, format);
    }
    }
}
