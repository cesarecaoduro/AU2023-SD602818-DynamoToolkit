
using AU2023DynamoToolkitToolbar.Model;
using AU2023DynamoToolkitToolbar.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using System.Windows;

namespace AU2023DynamoToolkitToolbar.ViewModel;

public partial class ToolbarViewModel : ObservableObject
{
    public string DarkLightMode => "Toggle between light and dark mode";

    private ToolbarModel _m;
    [ObservableProperty]
    private bool _isLightMode;

    public ToolbarViewModel(
        ToolbarModel m
        )
    {
        _m = m;
        IsLightMode = true;
    }

    [RelayCommand]
    void Template()
    {
        _m.ToolbarGraphOperations.TemplatiseGraph();
    }

    [RelayCommand]
    void InfoGroup()
    {
        _m.ToolbarGraphOperations.CreateGroup(
            GroupType.Information,
            GraphStandards.ColorInfoGroup.R,
            GraphStandards.ColorInfoGroup.G,
            GraphStandards.ColorInfoGroup.B);
    }

    [RelayCommand]
    void SwitchTemplateMode(Window win)
    {
        if (IsLightMode)
        {
            ThemeManager.Current.ChangeTheme(win, "Dark.Steel");
        }
        else
        {
            ThemeManager.Current.ChangeTheme(win, "Light.Steel");
        }
        IsLightMode = !IsLightMode;
    }
}
