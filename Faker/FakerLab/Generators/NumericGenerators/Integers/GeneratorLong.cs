namespace FakerLab.Generators.NumericGenerators.Integers
{
    internal class GeneratorLong : IGenerator<long>
    {
        private readonly Random _random = new();

        public long Generate() => _random.NextInt64();
    }
}
