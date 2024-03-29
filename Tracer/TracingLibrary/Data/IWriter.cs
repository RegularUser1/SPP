namespace TracingLibrary.Data
{
    public interface IWriter
    {
        void Write(object obj, TextWriter writer);
    }
}
