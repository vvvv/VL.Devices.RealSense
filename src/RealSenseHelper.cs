using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel.RealSense;
using Stride.Core.Mathematics;
using VL.Lib.Collections;

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

        public static IObservable<IReadOnlyList<Vector3>> SelectPointCloud(this IObservable<FrameSet> frames)
        {
            return Observable.Using(
                () => new PointCloud(),
                pc =>
                {
                    var pointBuffer = new Vector3[0];
                    return frames.Select(frameSet =>
                    {
                        using var frame = frameSet.AsFrame();
                        using var points = pc.Process(frame)
                            .DisposeWith(frameSet)
                            .AsFrameSet()
                            .DisposeWith(frameSet)
                            .FirstOrDefaultGeneric<Points>(Stream.Depth, Format.Xyz32f);
                        //using var points = pc.Process<Points>(frame);

                        // Grow buffer
                        var count = points.Count;
                        if (count > pointBuffer.Length)
                            pointBuffer = new Vector3[count];

                        // Copy vertices
                        if (points.VertexData != IntPtr.Zero)
                            points.CopyVertices(pointBuffer);

                        // Invert X and Y
                        var x = new Vector3(-1f, -1f, 1f);
                        for (int i = 0; i < count; i++)
                            pointBuffer[i] = Vector3.Modulate(pointBuffer[i], x);

                        return pointBuffer.GetSegment(0, count);
                    });
                });
        }
    }
}
