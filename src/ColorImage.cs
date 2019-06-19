using Intel.RealSense;
using System;
using VL.Lib.Basics.Imaging;

namespace VL.Devices.RealSense
{
    // Exposes the frame buffer directly
    class ColorImage : IImage
    {
        readonly VideoFrame frame;

        public ColorImage(VideoFrame frame)
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
