namespace TracingLibrary.Trace
{
    public class TraceResult(List<ThreadInfo> threadsData)
    {
        public IReadOnlyList<ThreadInfo> Threads => [.. threadsData];
        public List<ThreadInfo> Data => [.. Threads];
    }
}
