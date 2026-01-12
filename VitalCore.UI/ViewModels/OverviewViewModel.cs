using Microsoft.UI.Xaml;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using VitalCore.Core.Services;
using System.Collections.ObjectModel;
using System;

namespace VitalCore.UI.ViewModels;

public partial class OverviewViewModel : ObservableObject 
{
    private readonly ISystemMonitorService _sys;
    private readonly IGpuMonitorService _gpu;
    private readonly DispatcherTimer _timer;

    [ObservableProperty] private string _cpuText = "0%";
    [ObservableProperty] private double _cpuLoad = 0;
    [ObservableProperty] private string _ramLoadText = "0/16 GB";
    [ObservableProperty] private double _ramLoad = 0;
    [ObservableProperty] private string _gpuText = "N/A";
    [ObservableProperty] private double _gpuTemp = 0;

    // Series for Charts
    public ISeries[] CpuSeries { get; }
    public ISeries[] GpuSeries { get; }
    
    private readonly ObservableCollection<double> _cpuValues = new() { 0 };
    private readonly ObservableCollection<double> _gpuValues = new() { 0 };

    public Axis[] XAxes { get; } = [ new Axis { IsVisible = false } ];
    public Axis[] YAxes { get; } = [ new Axis { MinLimit = 0, MaxLimit = 100, SeparatorsPaint = new SolidColorPaint(SKColors.Gray.WithAlpha(30)) } ];

    public OverviewViewModel(ISystemMonitorService sys, IGpuMonitorService gpu) 
    {
        _sys = sys; _gpu = gpu;

        CpuSeries = [ 
            new LineSeries<double> { 
                Values = _cpuValues, 
                Name = "CPU Load",
                Fill = new LinearGradientPaint(new[] { SKColors.Cyan.WithAlpha(50), SKColors.Transparent }, new SKPoint(0.5f, 0), new SKPoint(0.5f, 1)),
                Stroke = new SolidColorPaint(SKColors.Cyan) { StrokeThickness = 2 },
                GeometrySize = 0 
            } 
        ];

        GpuSeries = [ 
            new LineSeries<double> { 
                Values = _gpuValues, 
                Name = "GPU Temp",
                Fill = new LinearGradientPaint(new[] { SKColors.OrangeRed.WithAlpha(50), SKColors.Transparent }, new SKPoint(0.5f, 0), new SKPoint(0.5f, 1)),
                Stroke = new SolidColorPaint(SKColors.OrangeRed) { StrokeThickness = 2 },
                GeometrySize = 0 
            } 
        ];

        _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        _timer.Tick += (s, e) => UpdateMetrics();
        _timer.Start();
    }

    private void UpdateMetrics() 
    {
        // CPU
        var cpu = _sys.GetCpuUsage();
        CpuLoad = cpu;
        CpuText = $"{(int)cpu}%";
        _cpuValues.Add(cpu);
        if (_cpuValues.Count > 30) _cpuValues.RemoveAt(0);

        // RAM
        RamLoad = _sys.GetRamUsage();
        RamLoadText = $"{(int)RamLoad}%";

        // GPU
        var gpuData = _gpu.GetGpuData();
        GpuText = $"{gpuData.Name} | {(int)gpuData.CoreTemp}°C";
        GpuTemp = gpuData.CoreTemp;
        _gpuValues.Add(gpuData.CoreTemp);
        if (_gpuValues.Count > 30) _gpuValues.RemoveAt(0);
    }
}