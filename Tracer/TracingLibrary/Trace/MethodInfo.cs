using System.Diagnostics;

namespace TracingLibrary.Trace
{
    public class MethodInfo(string methodName, string className)
    {
        public MethodInfo() : this(string.Empty, string.Empty) { }

        public string Method { get; set; } = methodName;
        public string Class { get; set; } = className;
        public long Time { get; set; }
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
