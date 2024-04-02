using FakerLab.Generators;

namespace FakerLab
{
    public class CustomStringGenerator : IGenerator<string>
    {
        public string Generate() => "ABOBA";
    }
}
