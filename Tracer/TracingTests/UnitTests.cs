using FluentAssertions;
using TracingLibrary.Trace;

namespace TracingTests
{
    public class UnitTests
    {
        private readonly Tracer _tracer;

        public UnitTests()
        {
            _tracer = new Tracer();
        }

        [Fact]
        public void Test_EmptyResult()
        {
            var res = _tracer.GetTraceResult();

            Assert.Empty(res.Threads);
        }

        [Fact]
        public void Test_SingleMethod()
        {
            _tracer.StartTrace();
            _tracer.StopTrace();

            var res = _tracer.GetTraceResult();

            Assert.Single(res.Threads[0].Methods);
        }

        [Fact]
        public void Test_NestedMethods()
        {
            _tracer.StartTrace();
            _tracer.StartTrace();
            _tracer.StopTrace();
            _tracer.StopTrace();

            var res = _tracer.GetTraceResult();

            Assert.Single(res.Threads);
            Assert.Single(res.Threads[0].Methods);
        }

        [Fact]
        public void Test_MultipleMethods()
        {
            _tracer.StartTrace();
            _tracer.StopTrace();
            _tracer.StartTrace();
            _tracer.StopTrace();

            var res = _tracer.GetTraceResult();

            res.Threads[0].Methods.Should().HaveCount(2);
        }

        [Fact]
        public void Test_MultipleThreads()
        {
            var firstThread = new Thread(() =>
            {
                _tracer.StartTrace();
                _tracer.StopTrace();
            });

            var secondThread = new Thread(() =>
            {
                _tracer.StartTrace();
                _tracer.StopTrace();
            });

            firstThread.Start();
            secondThread.Start();

            _tracer.StartTrace();
            _tracer.StopTrace();

            firstThread.Join();
            secondThread.Join();

            var res = _tracer.GetTraceResult();

            res.Threads.Should().HaveCount(3);
        }

        [Fact]
        public void Test_NewThreadInsideMethod()
        {
            var firstThread = new Thread(() =>
            {
                _tracer.StartTrace();
                var thread = new Thread(() =>
                {
                    _tracer.StartTrace();
                    _tracer.StopTrace();
                });
                thread.Start();
                thread.Join();
                _tracer.StopTrace();
            });
            firstThread.Start();
            firstThread.Join();

            var res = _tracer.GetTraceResult();

            res.Threads.Should().HaveCount(2);
        }
    }
}