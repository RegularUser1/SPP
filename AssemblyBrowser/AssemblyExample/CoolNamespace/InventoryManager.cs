using AssemblyExample.AnotherNamespace;

namespace AssemblyExample.CoolNamespace
{
    internal sealed class InventoryManager(string name, int age, long id) : DataProcessor
    {
        public sealed override void StopProcessing()
        {
            base.StopProcessing();
        }
    }
}
