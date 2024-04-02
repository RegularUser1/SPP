using FakerLab.Generators.NumericGenerators.Integers;

namespace FakerLab.Generators.NumericGenerators.Floats
{
    public class GeneratorDecimal : IGenerator<decimal>
    {
        public decimal Generate()
        {
            var intGenerator = new GeneratorInt();

            int lo = intGenerator.Generate();
            int mid = intGenerator.Generate();
            int hi = intGenerator.Generate();
            byte scale = (byte)(intGenerator.Generate() % 29);

            return new decimal(lo, mid, hi, false, scale);
        }
    }
}
