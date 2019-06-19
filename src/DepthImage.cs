using Intel.RealSense;
using System;
using VL.Lib.Basics.Imaging;

namespace VL.Devices.RealSense
{
    // Exposes the kinect frame buffer directly
    class DepthImage : IImage
    {
        readonly DepthFrame frame;
        public DepthImage(DepthFrame frame)
        {
            this.frame = frame;
            Info = frame.ToImageInfo(frame.Width, frame.Height);
        }

        public ImageInfo Info { get; }

        public bool IsVolatile => true;

        public IImageData GetData()
        {
            return new RealSenseFrameData(frame);
        }
    }
}
