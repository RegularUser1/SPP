namespace FakerLab
{
    public class MyDto(double dbl)
    {
        public double Double = dbl;
        public string? String { get; set; }
        public int Int { get; set; }
        public float Float { get; set; }
        public decimal Decimal;
        public IEnumerable<int>? Enumerable;
        public List<string>? List;
        public Dictionary<int, int>? Dictionary;
        public DateTime DateTime { get; set; }

        public override string ToString() =>
            $"""
            Class: {GetType()}
            String: {String}
            Int: {Int}
            Float: {Float}
            Double: {Double}
            Decimal: {Decimal}
            Enumerable: {string.Join(", ", Enumerable?.Select(item => $"{item}") ?? [])}
            List: {string.Join(", ", List?.Select(item => $"{item}") ?? [])}
            Dictionary: {Dictionary}
            DateTime: {DateTime}
            """;
    }
}
