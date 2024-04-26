using System.Reflection;
using System.Runtime.CompilerServices;

namespace AssemblyBrowserLib.AssemblyBrowsers
{
    public class AssemblyBrowser
    {
        private const string EMPTY_NAMESPACE = "NO NAMESPACE!";
        private const BindingFlags GET_ALL = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
            | BindingFlags.Static;

        public static Dictionary<string, List<TypeInfo>> GetAssemblyInfo(string assemblyPath)
        {
            var res = new Dictionary<string, List<TypeInfo>>();

            var asm = Assembly.LoadFrom(assemblyPath);
            var types = asm.GetTypes().ToList();
            types.Sort(StaticClassComparator);

            foreach (var type in types)
            {
                var currNamespace = type.Namespace ?? EMPTY_NAMESPACE;

                if (!res.ContainsKey(currNamespace))
                {
                    res[currNamespace] = [];
                }

                var typeInfo = GetTypeInfo(type);
                res[currNamespace].Add(typeInfo);

                var extensionMethods = type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                    .Where(m => m.IsDefined(typeof(ExtensionAttribute), false));
                foreach (var extensionMethod in extensionMethods)
                {
                    var extendedType = extensionMethod.GetParameters()[0].ParameterType;
                    var extendedTypeNamespace = extendedType.Namespace ?? EMPTY_NAMESPACE;
                    var extendedTypeInfo = res[extendedTypeNamespace].Find(t => t.Type.Name == extendedType.Name);

                    extendedTypeInfo!.ExtensionMethods.Add(extensionMethod);
                }
            }

            return res;
        }

        private static TypeInfo GetTypeInfo(Type type)
        {
            var constructors = type.GetConstructors(GET_ALL);
            var fields = type.GetFields(GET_ALL);
            var properties = type.GetProperties(GET_ALL);
            var methods = type.GetMethods(GET_ALL).Where(m => !m.IsDefined(typeof(ExtensionAttribute), false))
                .Where(m => !m.IsSpecialName);

            var typeInfo = new TypeInfo(type, constructors, methods, properties, fields);

            return typeInfo;
        }

        private static int StaticClassComparator(Type x, Type y)
        {
            bool isXStatic = x.IsAbstract && x.IsSealed;
            bool isYStatic = y.IsAbstract && y.IsSealed;

            if (isXStatic && !isYStatic)
            {
                return 1;
            }
            if (!isXStatic && isYStatic)
            {
                return -1;
            }

            return 0;
        }
    }
}
