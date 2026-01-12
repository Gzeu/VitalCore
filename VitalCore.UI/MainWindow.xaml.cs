using Microsoft.UI.Xaml;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.Extensions.DependencyInjection;
using VitalCore.Core.Services;

namespace VitalCore.UI;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();

        ExtendsContentIntoTitleBar = true;
        SetTitleBar(null);

        // Mica Backdrop
        if (MicaBackdrop.IsSupported())
        {
            SystemBackdrop = new MicaBackdrop { Kind = MicaKind.BaseAlt };
        }
        else
        {
            SystemBackdrop = new DesktopAcrylicBackdrop();
        }

        // Navigation setup
        RootNavigation.SelectedItem = RootNavigation.MenuItems[0];
        RootNavigation.SelectionChanged += OnNavigationSelectionChanged;
    }

    private void OnNavigationSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        // TODO: Navigate to pages
    }
}