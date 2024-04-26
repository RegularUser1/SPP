using System.Collections.ObjectModel;

namespace AssemblyBrowserLab.ViewModel.Objects
{
    public class TreeNode(string text)
    {
        public string Text { get; } = text;
        public ObservableCollection<TreeNode> Children { get; } = [];
    }
}
