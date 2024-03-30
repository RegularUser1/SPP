using TracingLibrary.Trace;

namespace Tracing
{
    internal class Outer
    {
        private readonly Inner _innerClass;
        private readonly ITracer _tracer;

        internal Outer(ITracer tracer)
        {
            _tracer = tracer;
            _innerClass = new Inner(_tracer);
        }

        public void MyMethod()
        {
            _tracer.StartTrace();
            _innerClass.InnerMethod();
            _tracer.StopTrace();
        }
    }
}
