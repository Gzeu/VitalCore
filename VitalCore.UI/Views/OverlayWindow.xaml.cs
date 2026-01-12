using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using VitalCore.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using WinRT.Interop;
using Microsoft.UI.Windowing;

namespace VitalCore.UI.Views;

public sealed partial class OverlayWindow : Window
{
    public OverviewViewModel ViewModel { get; }
    private bool _isDragging = false;
    private Windows.Graphics.PointInt32 _lastMousePos;

    public OverlayWindow()
    {
        this.InitializeComponent();
        
        // Setup ViewModel from DI
        ViewModel = App.Host.Services.GetRequiredService<OverviewViewModel>();
        
        // Configure Window
        AppWindow appWindow = GetAppWindow();
        appWindow.IsShownInSwitchers = false; // Hide from Alt-Tab
        
        var presenter = appWindow.Presenter as OverlappedPresenter;
        presenter.IsAlwaysOnTop = true;
        presenter.IsResizable = false;
        presenter.HasTitleBar = false;

        // Drag and Drop Logic
        this.Content.PointerPressed += (s, e) => {
            _isDragging = true;
            var properties = e.GetCurrentPoint(this.Content).Properties;
            // Capture initial drag state
            this.Content.CapturePointer(e.Pointer);
        };

        this.Content.PointerMoved += (s, e) => {
            if (_isDragging)
            {
                // Note: In a full implementation, we use AppWindow.Move to update position
                // based on screen coordinates.
            }
        };

        this.Content.PointerReleased += (s, e) => {
            _isDragging = false;
            this.Content.ReleasePointerCapture(e.Pointer);
        };
    }

    private AppWindow GetAppWindow()
    {
        IntPtr hWnd = WindowNative.GetWindowHandle(this);
        Microsoft.UI.WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
        return AppWindow.GetFromWindowId(windowId);
    }
}