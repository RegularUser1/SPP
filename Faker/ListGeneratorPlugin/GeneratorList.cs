namespace FakerLab.Generators.CollectionGenerators
{
    public class GeneratorList<T, TGenerator> : IGenerator<List<T>>
        where TGenerator : IGenerator<T>, new()
    {
        public List<T> Generate()
        {
            var baseGenerator = new GeneratorIEnumerable<T, TGenerator>();

            return baseGenerator.Generate().ToList();
        }
    }
}
