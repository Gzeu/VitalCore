using System;
using System.Diagnostics;
using System.Management;
using NvAPIWrapper.GPU;
using NvAPIWrapper.Native.GPU;

namespace VitalCore.Core.Services;

public interface ISystemMonitorService
{
    float GetCpuUsage();
    float GetRamUsage();
    float GetCpuTemperature();
}

public interface IGpuMonitorService
{
    GpuData GetNvidiaData();
}

public record GpuData
{
    public string Name { get; init; } = string.Empty;
    public float CoreTemp { get; init; }
    public float MemoryTemp { get; init; }
    public int FanSpeedRpm { get; init; }
    public float CoreClockMHz { get; init; }
}

public class SystemMonitorService : ISystemMonitorService
{
    private readonly PerformanceCounter _cpuCounter = new("Processor", "% Processor Time", "_Total");
    private readonly PerformanceCounter _ramCounter = new("Memory", "Available MBytes");

    public float GetCpuUsage() =&gt; _cpuCounter.NextValue();

    public float GetRamUsage()
    {
        var total = GetTotalRamGB();
        var available = _ramCounter.NextValue() / 1024f;
        return ((total - available) / total) * 100;
    }

    public float GetCpuTemperature()
    {
        try
        {
            using var searcher = new ManagementObjectSearcher(@