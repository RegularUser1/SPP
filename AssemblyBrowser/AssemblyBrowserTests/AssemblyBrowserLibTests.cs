using AssemblyBrowserLib.AssemblyBrowsers;
using FluentAssertions;

namespace AssemblyBrowserTests
{
    public class AssemblyBrowserLibTests
    {
        private const string ASSEMBLY_PATH = @"Assemblies\AssemblyExample.dll";
        private readonly Dictionary<string, List<TypeInfo>> _assemblyInfo;

        public AssemblyBrowserLibTests()
        {
            _assemblyInfo = AssemblyBrowser.GetAssemblyInfo(ASSEMBLY_PATH);
        }

        [Fact]
        public void Test_NamespacesCount()
        {
            _assemblyInfo.Keys.Should().HaveCount(6);
        }

        [Fact]
        public void Test_TypesCount()
        {
            _assemblyInfo["AssemblyExample.CoolNamespace"].Should().HaveCount(3);
        }

        [Fact]
        public void Test_MethodsCount()
        {
            _assemblyInfo["AssemblyExample.CoolNamespace"].Sum(t => t.Methods.Count).Should().Be(22);
        }

        [Fact]
        public void Test_PropertiesCount()
        {
            _assemblyInfo["AssemblyExample.CoolNamespace"].Sum(t => t.Properties.Count).Should().Be(4);
        }

        [Fact]
        public void Test_FieldsCount()
        {
            _assemblyInfo["AssemblyExample.CoolNamespace"].Sum(t => t.Fields.Count).Should().Be(6);
        }

        [Fact]
        public void Test_ExtensionMethodsCount()
        {
            _assemblyInfo["AssemblyExample.CoolNamespace"].Sum(t => t.ExtensionMethods.Count).Should().Be(1);
        }

        [Fact]
        public void Test_NoExtensionMethodsInExtensionClass()
        {
            _assemblyInfo["AssemblyExample.Extensions"].Sum(t => t.Methods.Count).Should().Be(12);
            _assemblyInfo["AssemblyExample.Extensions"].Sum(t => t.ExtensionMethods.Count).Should().Be(0);
        }
    }
}