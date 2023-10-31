using AU2023DynamoToolkitExtension;
using AU2023DynamoToolkitUI.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dynamo.Controls;
using Dynamo.Wpf;
using System.Windows;

namespace AU2023DynamoToolkitUI.ViewModel
{
    public partial class GreetingsUIViewModel : ObservableObject, INodeViewCustomization<GreetingsUIModel>
    {
        [ObservableProperty]
        private string _name;

        public void CustomizeView(GreetingsUIModel model, NodeView nodeView)
        {
            var v = new GreetingsUIView();
            nodeView.inputGrid.Children.Add(v);
            v.DataContext = this;
            Name = Configurations.PackageName;
        }

        public void Dispose()
        {
        }

        [RelayCommand]
        void OpenMessageDialog()
        {
            MessageBox.Show($"Greetings from {Name}!");
        }
    }
}
