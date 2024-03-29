using TracingLibrary.Trace;

namespace Tracing
{
    public class Inner
    {
        public readonly ITracer _tracer;

        internal Inner(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void InnerMethod()
        {
            _tracer.StartTrace();
            _tracer.StopTrace();
        }
    }
}
