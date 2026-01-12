using Microsoft.UI.Xaml;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using VitalCore.Core.Services;
using System.Collections.ObjectModel;

namespace VitalCore.UI.ViewModels;

public partial class OverviewViewModel : ObservableObject {
    private readonly ISystemMonitorService _sys;
    private readonly IGpuMonitorService _gpu;
    private readonly DispatcherTimer _timer;

    [ObservableProperty] private string _cpuText = "0%";
    [ObservableProperty] private string _gpuText = "0°C";

    public ObservableCollection<double> CpuValues { get; } = new() { 0 };
    public ISeries[] Series { get; }

    public OverviewViewModel(ISystemMonitorService sys, IGpuMonitorService gpu) {
        _sys = sys; _gpu = gpu;
        Series = [ new LineSeries<double> { Values = CpuValues, Fill = null } ];
        _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        _timer.Tick += (s, e) => {
            var val = _sys.GetCpuUsage();
            CpuText = $"{(int)val}%";
            CpuValues.Add(val);
            if(CpuValues.Count > 20) CpuValues.RemoveAt(0);
            GpuText = $"{_gpu.GetGpuData().CoreTemp}°C";
        };
        _timer.Start();
    }
}
