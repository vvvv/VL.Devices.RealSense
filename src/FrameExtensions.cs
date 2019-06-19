using Intel.RealSense;
using System;
using VL.Lib.Basics.Imaging;

namespace VL.Devices.RealSense
{
    // Keep all implementing classes internal and just expose them publicly through interface
    public static class FrameExtensions
    {
        public static IImage ToColorImage(this VideoFrame frame) => new ColorImage(frame);

        public static IImage ToDepthImage(this DepthFrame frame) => new DepthImage(frame);

        public static ImageInfo ToImageInfo(this Frame frame, int width, int height)
        {
            return new ImageInfo(
                width: width,
                height: height,
                format: frame.Profile.Format.ToPixelFormat(),
                originalFormat: frame.Profile.Format.ToString());
        }

        public static PixelFormat ToPixelFormat(this Format format)
        {
            switch (format)
            {
                case Format.Any:
                    return PixelFormat.Unknown;
                case Format.Rgb8:
                    return PixelFormat.R8G8B8;
                case Format.Rgba8:
                    return PixelFormat.R8G8B8A8;
                case Format.Bgra8:
                    return PixelFormat.B8G8R8A8;
                case Format.Z16:
                    return PixelFormat.R16;
                case Format.Y8:
                    return PixelFormat.R8;
                case Format.Yuyv:
                    throw new NotSupportedException(); // TODO: Make me nicer
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
