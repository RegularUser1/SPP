using Tracing;
using TracingLibrary.Data;
using TracingLibrary.Trace;

var tracer = new Tracer();

var outer = new Outer(tracer);
outer.MyMethod();

var res = tracer.GetTraceResult();
var s = new MyXmlSerializer();
var serialized = s.Serialize(res);

Console.WriteLine(serialized);
