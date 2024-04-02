namespace FakerLab.Entities
{
    public class B(int id)
    {
        public readonly int Id = id;
        public int BId;

        public C? C;

        public override string ToString() =>
            $"""
            Type: {GetType()} 
            Id: {Id} 
            ANOTHER Id: {BId}
            C: {C}
            """;
    }
}
