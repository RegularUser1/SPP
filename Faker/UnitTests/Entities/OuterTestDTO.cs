namespace FakerLab.Entities
{
    public class OuterTestDTO
    {
        public string? String { get; set; }
        public int Int { get; set; }
        public float Float { get; set; }
        public double Double;
        public decimal Decimal;
        public InnerTestDTO? Inner;
        public IEnumerable<int>? Enumerable;
        public Dictionary<int, int>? Dictionary;

        public OuterTestDTO(double dbl, InnerTestDTO testDTO)
        {
            Double = dbl;
            Inner = testDTO;
        }

        public override string ToString() =>
            $"""
            Class: {GetType()}
            String: {String}
            Int: {Int}
            Float: {Float}
            Double: {Double}
            Decimal: {Decimal}
            Enumerable: {string.Join(", ", Enumerable?.Select(item => $"{item}") ?? [])}
            Dictionary: {Dictionary}
            InnerDTO: {Inner}
            """;
    }
}
