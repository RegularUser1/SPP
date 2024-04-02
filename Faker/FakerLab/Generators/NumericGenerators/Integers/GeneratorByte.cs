namespace FakerLab.Generators.NumericGenerators.Integers
{
    public class GeneratorByte : IGenerator<byte>
    {
        private readonly Random _random = new();

        public byte Generate() => (byte)_random.Next(byte.MaxValue);
    }
}
