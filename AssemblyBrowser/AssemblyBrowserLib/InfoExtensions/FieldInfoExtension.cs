using System.Reflection;

namespace AssemblyBrowserLib.InfoExtensions
{
    public static partial class InfoExtension
    {
        private static readonly Dictionary<FieldAttributes, string> _visibilityField = new()
        {
            { FieldAttributes.Public, "public" },
            { FieldAttributes.Private, "private" },
            { FieldAttributes.Family, "protected" },
            { FieldAttributes.Assembly, "internal" },
            { FieldAttributes.FamORAssem, "protected internal" },
            { FieldAttributes.FamANDAssem, "private protected" }
        };

        public static string GetSignature(this FieldInfo fieldInfo)
        {
            string accessibility = _visibilityField[fieldInfo.Attributes & FieldAttributes.FieldAccessMask];
            string fieldType = GetTypeName(fieldInfo.FieldType);
            string fieldName = fieldInfo.Name;

            return $"{accessibility} {fieldType} {fieldName}";
        }
    }
}
