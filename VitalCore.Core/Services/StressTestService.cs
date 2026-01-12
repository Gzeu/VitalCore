using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace VitalCore.Core.Services;

public interface IStressTestService
{
    bool IsRunning { get; }
    Task StartCpuStressAsync(int threads, CancellationToken ct);
    Task StartRamStressAsync(int sizeMb, CancellationToken ct);
}

public class StressTestService : IStressTestService
{
    public bool IsRunning { get; private set; }

    public async Task StartCpuStressAsync(int threads, CancellationToken ct)
    {
        IsRunning = true;
        var tasks = new Task[threads];

        for (int i = 0; i < threads; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                while (!ct.IsCancellationRequested)
                {
                    // Busy wait for CPU stress
                    double x = 123.456;
                    x = Math.Sqrt(x) * Math.Sin(x);
                }
            }, ct);
        }

        try { await Task.WhenAll(tasks); }
        finally { IsRunning = false; }
    }

    public async Task StartRamStressAsync(int sizeMb, CancellationToken ct)
    {
        IsRunning = true;
        try
        {
            await Task.Run(() =>
            {
                byte[] stressBuffer = new byte[sizeMb * 1024 * 1024];
                var rng = new Random();
                while (!ct.IsCancellationRequested)
                {
                    rng.NextBytes(stressBuffer); // Constant memory write
                }
            }, ct);
        }
        finally { IsRunning = false; }
    }
}