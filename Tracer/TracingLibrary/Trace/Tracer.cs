using System.Collections.Concurrent;
using System.Diagnostics;

namespace TracingLibrary.Trace
{
    public class Tracer : ITracer
    {
        private readonly ConcurrentDictionary<int, List<MethodInfo>> _traceData = [];
        private readonly ConcurrentDictionary<int, Stack<MethodInfo>> _threadStack = [];

        public TraceResult GetTraceResult()
            => new(_traceData.Select(kv => new ThreadInfo(kv.Key, kv.Value.Sum(v => v.Time), kv.Value)).ToList());

        public void StartTrace()
        {
            var callingMethod = new StackFrame(1).GetMethod()!;
            var callingMethodName = callingMethod.Name;
            var callingClassName = callingMethod.DeclaringType!.Name;
            var method = new MethodInfo(callingMethodName, callingClassName);
            var threadId = Environment.CurrentManagedThreadId;

            if (!_threadStack.TryGetValue(threadId, out Stack<MethodInfo>? value))
            {
                _traceData[threadId] = [method];
                _threadStack[threadId] = new();
                _threadStack[threadId].Push(method);
            }
            else
            {
                if (value.Count == 0)
                {
                    _traceData[threadId].Add(method);
                }
                else
                {
                    var methodData = value.Peek();
                    methodData.InnerMethods.Add(method);
                }

                value.Push(method);
            }
            method.StartTimer();
        }

        public void StopTrace()
        {
            var threadId = Environment.CurrentManagedThreadId;
            var method = _threadStack[threadId].Pop();
            method.StopTimer();
        }
    }
}
