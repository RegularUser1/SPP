using System.Collections.Immutable;
using System.Xml.Serialization;

namespace TracingLibrary.Trace
{
    public class TraceResult
    {
        [XmlElement("Thread")]
        public List<ThreadInfo> Threads { get; set; }

        public TraceResult(List<ThreadInfo> threadsInfo)
        {
            Threads = threadsInfo;
        }

        public TraceResult()
        {
            Threads = new List<ThreadInfo>();
        }
    }
}
