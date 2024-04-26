namespace AssemblyExample.Interface
{
    internal interface ITest<in In, out Out, Default>
    {
        int A { get; set; }
        Out TestMethod(In inn, Default def);
    }
}
