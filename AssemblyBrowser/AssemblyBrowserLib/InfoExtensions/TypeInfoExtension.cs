using System.Text;

namespace AssemblyBrowserLib.InfoExtensions
{
    public static partial class InfoExtension
    {
        public static string GetSignature(this Type type)
        {
            var builder = new StringBuilder();

            switch (type)
            {
                case { IsPublic: true }:
                case { IsNestedPublic: true }:
                    builder.Append("public ");
                    break;
                case { IsNestedPrivate: true }:
                    builder.Append("private ");
                    break;
                case { IsNestedFamily: true }:
                    builder.Append("protected ");
                    break;
                case { IsNestedAssembly: true }:
                    builder.Append("internal ");
                    break;
                case { IsNestedFamANDAssem: true }:
                    builder.Append("private protected ");
                    break;
                default:
                    builder.Append("internal ");
                    break;
            }

            if (type.IsAbstract && type.IsSealed)
            {
                builder.Append("static ");
            }
            else if (type.IsAbstract && type.IsClass)
            {
                builder.Append("abstract ");
            }
            else if (type.IsSealed && !type.IsValueType)
            {
                builder.Append("sealed ");
            }

            if (type.IsClass)
            {
                builder.Append("class ");
            }
            else if (type.IsValueType)
            {
                builder.Append("struct ");
            }
            else if (type.IsInterface)
            {
                builder.Append("interface ");
            }

            builder.Append(GetTypeName(type));

            return builder.ToString();
        }
    }
}
