namespace TracingLibrary.Trace
{
    public class ThreadInfo(int threadId, long time, List<MethodInfo> methods)
    {
        public readonly int ThreadId = threadId;
        public readonly long Time = time;
        public readonly List<MethodInfo> Methods = methods;
    }
}
