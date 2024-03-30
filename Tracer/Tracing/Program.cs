using Tracing;
using TracingLibrary.Trace;

var tracer = new Tracer();

var outer = new Outer(tracer);
outer.MyMethod();

var res = tracer.GetTraceResult();

Console.WriteLine(res);
