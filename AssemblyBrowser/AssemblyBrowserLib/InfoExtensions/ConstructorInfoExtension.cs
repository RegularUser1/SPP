using System.Reflection;
using System.Text;

namespace AssemblyBrowserLib.InfoExtensions
{
    public static partial class InfoExtension
    {
        public static string GetSignature(this ConstructorInfo constructorInfo)
        {
            var builder = new StringBuilder();
            var visibility = constructorInfo.Attributes & MethodAttributes.MemberAccessMask;
            builder.Append(_visibilityMethod[visibility]).Append(' ');

            var returnType = constructorInfo.DeclaringType;
            if (returnType is null)
            {
                builder.Append(constructorInfo.Name);
            }
            else
            {
                builder.Append(GetTypeName(returnType));
            }
            builder.Append('(');

            var parameters = constructorInfo.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                builder.Append(GetTypeName(parameter.ParameterType)).Append(' ').Append(parameter.Name);
                if (i < parameters.Length - 1)
                {
                    builder.Append(", ");
                }
            }
            builder.Append(')');

            return builder.ToString();
        }
    }
}
