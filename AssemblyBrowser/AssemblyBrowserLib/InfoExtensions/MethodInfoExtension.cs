using System.Reflection;
using System.Text;

namespace AssemblyBrowserLib.InfoExtensions
{
    public static partial class InfoExtension
    {
        private static readonly Dictionary<MethodAttributes, string> _visibilityMethod = new()
        {
            { MethodAttributes.Public, "public" },
            { MethodAttributes.Private, "private" },
            { MethodAttributes.Family, "protected" },
            { MethodAttributes.Assembly, "internal" },
            { MethodAttributes.FamORAssem, "protected internal" },
            { MethodAttributes.FamANDAssem, "private protected" }
        };

        public static string GetSignature(this MethodInfo methodInfo)
        {
            var builder = new StringBuilder();
            var visibility = methodInfo.Attributes & MethodAttributes.MemberAccessMask;
            builder.Append(_visibilityMethod[visibility]).Append(' ');

            if (methodInfo.IsVirtual)
            {
                if (methodInfo.IsFinal)
                {
                    builder.Append("sealed ");
                }
                else
                {
                    builder.Append("virtual ");
                }
            }
            if (methodInfo.IsAbstract)
            {
                builder.Append("abstract ");
            }
            if (methodInfo.IsStatic)
            {
                builder.Append("static ");
            }

            builder.Append(GetTypeName(methodInfo.ReturnType)).Append(' ');

            builder.Append(methodInfo.Name);
            if (methodInfo.IsGenericMethod)
            {
                var genericArguments = methodInfo.GetGenericArguments();
                builder.Append('<');
                for (int i = 0; i < genericArguments.Length; i++)
                {
                    builder.Append(GetTypeName(genericArguments[i]));
                    if (i < genericArguments.Length - 1)
                    {
                        builder.Append(", ");
                    }
                }
                builder.Append('>');
            }
            builder.Append('(');
            var parameters = methodInfo.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                builder.Append(GetTypeName(parameter.ParameterType));
                builder.Append(' ');
                builder.Append(parameter.Name);
                if (i < parameters.Length - 1)
                {
                    builder.Append(", ");
                }
            }
            builder.Append(')');

            return builder.ToString();
        }

        private static string GetTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                var builder = new StringBuilder();

                builder.Append(type.Name.AsSpan(0, type.Name.IndexOf('`')));
                builder.Append('<');

                var genericArguments = type.GetGenericArguments();
                for (int i = 0; i < genericArguments.Length; i++)
                {
                    if (genericArguments[i].IsGenericParameter)
                    {
                        if (genericArguments[i].GenericParameterAttributes.HasFlag(GenericParameterAttributes.Covariant))
                        {
                            builder.Append("out ");
                        }
                        else if (genericArguments[i].GenericParameterAttributes.HasFlag(GenericParameterAttributes.Contravariant))
                        {
                            builder.Append("in ");
                        }
                    }

                    builder.Append(GetTypeName(genericArguments[i]));
                    if (i < genericArguments.Length - 1)
                    {
                        builder.Append(", ");
                    }
                }

                builder.Append('>');

                return builder.ToString();
            }

            return type.Name;
        }
    }
}
