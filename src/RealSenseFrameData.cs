using Intel.RealSense;
using System;
using VL.Lib.Basics.Imaging;

namespace VL.Devices.RealSense
{
    class RealSenseFrameData : IImageData
    {
        readonly VideoFrame frame;

        public RealSenseFrameData(VideoFrame frame)
        {
            this.frame = frame;
            ScanSize = frame.Stride;
        }

        public IntPtr Pointer => frame.Data;

        public int Size => ScanSize * frame.Height;

        public int ScanSize { get; }
        public void Dispose() { }
    }
}
