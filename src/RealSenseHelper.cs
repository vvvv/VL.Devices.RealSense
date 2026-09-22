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

        /// <summary>
        /// Copies the vertices into <paramref name="destination"/>, inverting X and Y in the same pass.
        /// </summary>
        /// <remarks>
        /// Reads the native rs2_vertex buffer (float xyz[3]) directly, reinterpreted as Vector3.
        /// </remarks>
        internal static unsafe void CopyAndTransformVertices(this Points points, Vector3[] destination)
        {
            var vertexData = points.VertexData;
            if (vertexData == IntPtr.Zero)
                return;

            var count = Math.Min(points.Count, destination.Length);
            var source = new ReadOnlySpan<Vector3>(vertexData.ToPointer(), count);
            for (int i = 0; i < count; i++)
            {
                var v = source[i];
                destination[i] = new Vector3(-v.X, -v.Y, v.Z);
            }
        }

        public static IObservable<IReadOnlyList<Vector3>> SelectPointCloud(this IObservable<FrameSet> frames)
        {
            return Observable.Using(
                () => new PointCloud(),
                pc =>
                {
                    var pointBuffer = Array.Empty<Vector3>();
                    return frames.Select(frameSet =>
                    {
                        using var frame = frameSet.AsFrame();
                        using var points = pc.Process(frame)
                            .DisposeWith(frameSet)
                            .AsFrameSet()
                            .DisposeWith(frameSet)
                            .FirstOrDefaultGeneric<Points>(Stream.Depth, Format.Xyz32f);
                        //using var points = pc.Process<Points>(frame);

                        // FirstOrDefault returns null if the frameset carries no Xyz32f depth frame
                        if (points is null)
                            return pointBuffer.GetSegment(0, 0);

                        // Grow buffer
                        var count = points.Count;
                        if (count > pointBuffer.Length)
                            pointBuffer = new Vector3[count];

                        // Copy vertices and invert X and Y in one pass over the native buffer
                        points.CopyAndTransformVertices(pointBuffer);

                        return pointBuffer.GetSegment(0, count);
                    });
                });
        }
    }
}
