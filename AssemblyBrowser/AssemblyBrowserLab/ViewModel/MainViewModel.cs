using AssemblyBrowserLab.ViewModel.Objects;
using AssemblyBrowserLib.AssemblyBrowsers;
using AssemblyBrowserLib.InfoExtensions;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AssemblyBrowserLab.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<TreeNode> RootNodes { get; set; } = [];
        public ICommand SelectAssembly { get; }

        public MainViewModel()
        {
            SelectAssembly = new RelayCommand(OpenFileCommand);
        }

        private void OpenFileCommand()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "DLL Files (*.dll)|*.dll",
                FilterIndex = 1,
                Multiselect = false
            };

            var result = openFileDialog.ShowDialog();

            if (result is true)
            {
                string filePath = openFileDialog.FileName;
                GetAssemblyInfo(filePath);
            }
        }

        private void GetAssemblyInfo(string assemblyPath)
        {
            RootNodes.Clear();
            var assemblyInfo = AssemblyBrowser.GetAssemblyInfo(assemblyPath);

            foreach (var namespaces in assemblyInfo)
            {
                var root = new TreeNode(namespaces.Key);
                foreach (var type in namespaces.Value)
                {
                    var typeNode = new TreeNode(type.Type.GetSignature());
                    root.Children.Add(typeNode);

                    var constructors = new TreeNode("Constructors");
                    var methods = new TreeNode("Methods");
                    var properties = new TreeNode("Properties");
                    var fields = new TreeNode("Fields");
                    var extensionMethods = new TreeNode("ExtensionMethods");

                    typeNode.Children.Add(constructors);
                    typeNode.Children.Add(methods);
                    typeNode.Children.Add(properties);
                    typeNode.Children.Add(fields);
                    typeNode.Children.Add(extensionMethods);

                    foreach (var constructor in type.Constructors)
                    {
                        constructors.Children.Add(new TreeNode(constructor.GetSignature()));
                    }
                    foreach (var method in type.Methods)
                    {
                        methods.Children.Add(new TreeNode(method.GetSignature()));
                    }
                    foreach (var property in type.Properties)
                    {
                        properties.Children.Add(new TreeNode(property.GetSignature()));
                    }
                    foreach (var field in type.Fields)
                    {
                        fields.Children.Add(new TreeNode(field.GetSignature()));
                    }
                    foreach (var extensionMethod in type.ExtensionMethods)
                    {
                        extensionMethods.Children.Add(new TreeNode(extensionMethod.GetSignature()));
                    }
                }

                RootNodes.Add(root);
            }

        }
    }
}
