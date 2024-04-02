using FakerLab.Generators;
using FakerLab.Generators.NumericGenerators.Integers;

namespace DateTimeGeneratorPlugin
{
    public class DateTimeGenerator : IGenerator<DateTime>
    {
        public DateTime Generate()
        {
            var intGenerator = new GeneratorInt();

            int year = intGenerator.Generate() % 10000;
            int month = intGenerator.Generate() % 12 + 1;
            int day = intGenerator.Generate() % DateTime.DaysInMonth(year, month);
            int hour = intGenerator.Generate() % 24;
            int minute = intGenerator.Generate() % 60;
            int second = intGenerator.Generate() % 60;
            int millisecond = intGenerator.Generate() % 1000;
            int microsecond = intGenerator.Generate() % 1000;

            return new DateTime(year, month, day, hour, minute, second, millisecond, microsecond, DateTimeKind.Utc);
        }
    }
}
