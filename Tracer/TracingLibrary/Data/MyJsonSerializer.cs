using Newtonsoft.Json;

namespace TracingLibrary.Data
{
    public class MyJsonSerializer(Formatting formatting = Formatting.Indented) : ISerializer
    {
        public string Serialize(object obj) => JsonConvert.SerializeObject(obj, formatting);
    }
}
