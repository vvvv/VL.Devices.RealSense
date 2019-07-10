using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VL.Devices.RealSense
{
    public static class ObservableHelper
    {
        public static IObservable<T> Forever<T>(Func<T> producer)
        {
            return Observable.Create<T>(async (observer, token) =>
            {
                await Task.Run(() =>
                {
                    while (!token.IsCancellationRequested)
                    {
                        var value = producer();
                        observer.OnNext(value);
                    }
                });
            });
        }
    }
}
