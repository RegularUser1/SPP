using AssemblyExample.AnotherNamespace.UserManagement;
using AssemblyExample.CoolNamespace;

namespace AssemblyExample.Extensions
{
    internal static class ExtensionClass
    {
        public static void RemoveUser(this UserManager manager, int id)
        {

        }

        public static void Manage(this InventoryManager manager)
        {

        }
    }

    internal static class AnotherExtensionClass
    {
        public static void RemoveUsers(this UserManager manager, int left, int right)
        {

        }
    }
}
