using System.Reflection;
using System.Text;

namespace AssemblyBrowserLib.InfoExtensions
{
    public static partial class InfoExtension
    {
        public static string GetSignature(this PropertyInfo propertyInfo)
        {
            var builder = new StringBuilder();
            var getter = propertyInfo.GetGetMethod(nonPublic: true);
            var setter = propertyInfo.GetSetMethod(nonPublic: true);

            var propertyTypeName = string.Empty;
            var propertyType = propertyInfo.PropertyType;
            if (propertyType is not null)
            {
                propertyTypeName = GetTypeName(propertyType);
            }

            var getterVisibilityString = string.Empty;
            var setterVisibilityString = string.Empty;
            if (getter is not null)
            {
                var getterVisibility = getter.Attributes & MethodAttributes.MemberAccessMask;
                getterVisibilityString = $"{_visibilityMethod[getterVisibility]} get;";
            }
            if (setter is not null)
            {
                var setterVisibility = setter.Attributes & MethodAttributes.MemberAccessMask;
                setterVisibilityString = $"{_visibilityMethod[setterVisibility]} set;";
            }


            builder.Append($"{propertyTypeName} {propertyInfo.Name} {{ {getterVisibilityString} {setterVisibilityString} }}");

            return builder.ToString();
        }
    }
}
