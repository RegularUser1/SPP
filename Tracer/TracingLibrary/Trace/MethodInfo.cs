using System.Diagnostics;

namespace TracingLibrary.Trace
{
    public class MethodInfo(string methodName, string className)
    {
        public readonly string Method = methodName;
        public readonly string Class = className;
        public long Time { get; private set; }
        public List<MethodInfo> InnerMethods { get; } = [];
        private readonly Stopwatch _stopwatch = new();

        public void StartTimer()
        {
            _stopwatch.Start();
        }

        public void StopTimer()
        {
            _stopwatch.Stop();
            Time = _stopwatch.ElapsedMilliseconds;
        }
    }
}
