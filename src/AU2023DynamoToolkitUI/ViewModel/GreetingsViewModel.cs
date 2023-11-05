using AU2023DynamoToolkitExtension;
using AU2023DynamoToolkitUI.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dynamo.Controls;
using Dynamo.Wpf;
using System.Windows;

namespace AU2023DynamoToolkitUI.ViewModel
{
    public partial class GreetingsViewModel : INodeViewCustomization<GreetingsModel>
    {

        public void CustomizeView(GreetingsModel model, NodeView nodeView)
        {
            var v = new GreetingsView();
            nodeView.inputGrid.Children.Add(v);
            v.DataContext = model;
        }

        public void Dispose()
        {
        }
    }
}
