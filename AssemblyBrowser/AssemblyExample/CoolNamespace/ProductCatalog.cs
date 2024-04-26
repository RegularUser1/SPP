namespace AssemblyExample.CoolNamespace
{
    internal class ProductCatalog<T>(T product, List<string> catalog, string name)
    {
        public T Product {  get; set; } = product;
        public List<string> Catalog { get; } = catalog;
        public readonly string Name = name;

        public K? GetProduct<K, Test>(T product)
        {
            return default;
        }
    }
}
