using AU2023DynamoToolkitToolbar.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControlzEx.Theming;
using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Dynamo.Wpf.Interfaces.ResourceNames;

namespace AU2023DynamoToolkitToolbar.View;

/// <summary>
/// Interaction logic for ToolbarView.xaml
/// </summary>
/// 
[ObservableObject]
public partial class ToolbarView
{
    public ToolbarView()
    {
        _ = new Badged();
        _ = PackIconMaterialKind.Atom;

        InitializeComponent();
        AssistantWindow.Width = 400;
        AssistantWindow.Height = 140;
    }
}
