namespace FakerLab.Generators.StringGenerators
{
    public class GeneratorChar : IGenerator<char>
    {
        private readonly Random _random = new();

        public char Generate() => (char)_random.Next(byte.MaxValue);
    }
}
