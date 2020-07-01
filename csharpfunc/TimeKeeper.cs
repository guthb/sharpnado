using System;
using System.Diagnostics;

namespace csharpfunc
{
    public class TimeKeeper
    {
        public TimeSpan Measure(Action action)
        {
            var watch = new Stopwatch();
            watch.Start();
            action();
            return watch.Elapsed
        }
    }
}