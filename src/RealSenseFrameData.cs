using Intel.RealSense;
using System;
using System.Buffers;
using VL.Lib.Basics.Imaging;

namespace VL.Devices.RealSense
{
    class RealSenseFrameData : MemoryManager<byte>, IImageData
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

        public ReadOnlyMemory<byte> Bytes => Memory;

        public override unsafe Span<byte> GetSpan()
        {
            return new Span<byte>(Pointer.ToPointer(), Size);
        }

        public override unsafe MemoryHandle Pin(int elementIndex = 0)
        {
            return new MemoryHandle(Pointer.ToPointer(), pinnable: this);
        }

        public override void Unpin()
        {
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}
