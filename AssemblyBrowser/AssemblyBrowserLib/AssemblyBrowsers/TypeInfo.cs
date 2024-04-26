using System.Reflection;

namespace AssemblyBrowserLib.AssemblyBrowsers
{
    public sealed class TypeInfo(Type type)
    {
        public readonly Type Type = type;

        public TypeInfo(Type type, IEnumerable<ConstructorInfo> constructors, IEnumerable<MethodInfo> methods,
            IEnumerable<PropertyInfo> properties, IEnumerable<FieldInfo> fields) : this(type)
        {
            Constructors = constructors.ToList();
            Methods = methods.ToList();
            Properties = properties.ToList();
            Fields = fields.ToList();
        }

        public readonly List<ConstructorInfo> Constructors = [];
        public readonly List<MethodInfo> Methods = [];
        public readonly List<PropertyInfo> Properties = [];
        public readonly List<FieldInfo> Fields = [];
        public readonly List<MethodInfo> ExtensionMethods = [];
    }
}
