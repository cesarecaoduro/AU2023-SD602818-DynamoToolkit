using AU2023DynamoToolkitToolbar.Model;
using AU2023DynamoToolkitToolbar.Utilities;
using AU2023DynamoToolkitToolbar.View;
using AU2023DynamoToolkitToolbar.ViewModel;
using Autodesk.DesignScript.Runtime;
using Dynamo.ViewModels;
using Dynamo.Wpf.Extensions;
using System.Windows;
using System.Windows.Controls;

namespace AU2023DynamoToolkitExtension;

[IsVisibleInDynamoLibrary(false)]
public class Menu
{
    private ViewLoadedParams _viewLoadedParams;
    private readonly ConfigManager _configManager;
    private string _accountName;

    public Menu()
    {
        string assemblyLocation = this.GetType().Assembly.Location;
        _configManager = new ConfigManager(assemblyLocation);
    }

    public Menu(string name)
    {
        string assemblyLocation = this.GetType().Assembly.Location;
        _configManager = new ConfigManager(assemblyLocation);
        _accountName = name;
    }

    public void AddMenuToDynamo(ViewLoadedParams viewLoadedParams)
    {
        _viewLoadedParams = viewLoadedParams;
        MenuItem au2023Menu = new MenuItem { Header = "AU2023" };

        //var accountName = Configurations.AuthenticationResult != null 
        //    ? Configurations.AuthenticationResult?.Account.Username 
        //    : _accountName;

        //var account = new MenuItem { Header = $"Welcome {accountName}" };

        var documentation = new MenuItem { Header = "AU2023 Handsout" };
        documentation.Click += new RoutedEventHandler(DirectoryHandler.Handsout);

        var toolbar = new MenuItem { Header = "AU2023 Canvas Assistant" };
        toolbar.Click += (sender, args) => OpenToolbar();

        //au2023Menu.Items.Add(account);
        //au2023Menu.Items.Add(new Separator());
        au2023Menu.Items.Add(documentation);
        au2023Menu.Items.Add(toolbar);

        viewLoadedParams.dynamoMenu.Items.Add(au2023Menu);
    }

    private void OpenToolbar()
    {
        if (_viewLoadedParams.DynamoWindow.DataContext is DynamoViewModel dynamoViewModel && dynamoViewModel.ShowStartPage)
        {
            CustomMessages.Error(CustomMessages.NoDocument);
            return;
        }
        var m = new ToolbarModel(_viewLoadedParams);
        var vm = new ToolbarViewModel(m);
        var v = new ToolbarView() { 
            DataContext = vm,
            Owner = _viewLoadedParams.DynamoWindow
        };
        v.Show();
    }
}
