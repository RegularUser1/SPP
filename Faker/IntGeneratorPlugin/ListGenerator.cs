using FakerLab.Generators;
using FakerLab.Generators.CollectionGenerators;

namespace IntGeneratorPlugin
{
    public class ListGenerator<T, TGenerator> : IGenerator<List<T>>
        where TGenerator : IGenerator<T>, new()
    {
        public List<T> Generate()
        {
            var baseGenerator = new GeneratorIEnumerable<T, TGenerator>();

            return baseGenerator.Generate().ToList();
        }
    }
}
