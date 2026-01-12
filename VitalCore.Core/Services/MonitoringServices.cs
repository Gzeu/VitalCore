using System;
using System.Diagnostics;
using System.Management;
using System.Linq;
using NvAPIWrapper.GPU;
using NvAPIWrapper.Native.GPU;

namespace VitalCore.Core.Services;

public interface ISystemMonitorService {
    float GetCpuUsage();
    float GetRamUsage();
    float GetCpuTemperature();
}

public interface IGpuMonitorService {
    GpuData GetGpuData();
}

public record GpuData {
    public string Name { get; init; } = "N/A";
    public float CoreTemp { get; init; }
    public float Load { get; init; }
}

public class SystemMonitorService : ISystemMonitorService {
    private readonly PerformanceCounter _cpuCounter = new("Processor", "% Processor Time", "_Total");
    private readonly PerformanceCounter _ramCounter = new("Memory", "Available MBytes");

    public float GetCpuUsage() => _cpuCounter.NextValue();
    public float GetRamUsage() {
        var total = 16f; // Fallback or WMI fetch
        return ((total - (_ramCounter.NextValue()/1024f))/total)*100;
    }
    public float GetCpuTemperature() => 45.5f; // Placeholder for WMI logic
}

public class GpuMonitorService : IGpuMonitorService {
    public GpuMonitorService() {
        try { NvAPIWrapper.NVIDIA.Initialize(); } catch {}
    }
    public GpuData GetGpuData() {
        try {
            var gpu = PhysicalGPU.GetPhysicalGPUs().FirstOrDefault();
            if (gpu == null) return new GpuData();
            return new GpuData { 
                Name = gpu.FullName, 
                CoreTemp = gpu.ThermalSettings.Sensors.FirstOrDefault()?.CurrentTemperature ?? 0,
                Load = gpu.UsageInformation.GPU.Percentage 
            };
        } catch { return new GpuData(); }
    }
}
