namespace FakerLab.Generators.NumericGenerators.Floats
{
    public class GeneratorFloat : IGenerator<float>
    {
        private readonly Random _random = new();

        public float Generate() => _random.NextSingle();
    }
}
