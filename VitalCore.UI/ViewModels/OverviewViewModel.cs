using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using VitalCore.Core.Services;
using System.Windows.Input;

namespace VitalCore.UI.ViewModels;

[ObservableObject]
public partial class OverviewViewModel
{
    private readonly ISystemMonitorService _monitor;
    private readonly DispatcherTimer _timer;

    [ObservableProperty]
    private double cpuLoad;

    [ObservableProperty]
    private double ramLoad;

    [ObservableProperty]
    private double gpuTemp;

    public ISeries[] CpuSeries { get; }
    public Axis[] XAxes { get; }
    public Axis[] YAxes { get; }

    public OverviewViewModel(ISystemMonitorService monitor)
    {
        _monitor = monitor;

        // LiveCharts2 Setup - High performance for realtime
        CpuSeries = [new LineSeries&lt;ObservableValue&gt;
        {
            Values = new ObservableCollection&lt;ObservableValue&gt; { new(0) },
            Fill = null,
            Stroke = new SolidColorPaint(SKColors.Cyan) { StrokeThickness = 3 }
        }];

        XAxes = [new Axis { Name = "Time", NamePaint = new SolidColorPaint(SKColors.White) }];
        YAxes = [new Axis { Name = "Usage %", NamePaint = new SolidColorPaint(SKColors.White), MinLimit = 0, MaxLimit = 100 }];

        _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        _timer.Tick += (s, e) =&gt; UpdateData();
        _timer.Start();
    }

    private void UpdateData()
    {
        CpuLoad = _monitor.GetCpuUsage();
        RamLoad = _monitor.GetRamUsage();
        // TODO: GPU from service
    }
}