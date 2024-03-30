namespace TracingLibrary.Data
{
    public class MyWriter(ISerializer serializer) : IWriter
    {
        private readonly ISerializer _serializer = serializer;

        public void Write(object obj, TextWriter writer)
        {
            writer.Write(_serializer.Serialize(obj));
        }
    }
}
