namespace FakerLab.Generators.BoolGenerators
{
    public class GeneratorBool : IGenerator<bool>
    {
        protected readonly Random Random = new();
        public bool Generate() => Random.Next(2) == 1;
    }
}
