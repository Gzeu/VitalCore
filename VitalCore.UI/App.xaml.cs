using Microsoft.UI.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VitalCore.Core.Services;
using VitalCore.UI.ViewModels;

namespace VitalCore.UI;

public partial class App : Application
{
    public static IHost Host { get; private set; }
    private Window m_window;

    public App()
    {
        this.InitializeComponent();
        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => {
                services.AddSingleton<ISystemMonitorService, SystemMonitorService>();
                services.AddSingleton<IGpuMonitorService, GpuMonitorService>();
                services.AddTransient<OverviewViewModel>();
            }).Build();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        m_window = new MainWindow();
        m_window.Activate();
    }
}