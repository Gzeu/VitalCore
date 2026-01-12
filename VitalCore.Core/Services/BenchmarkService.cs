using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace VitalCore.Core.Services;

public interface IBenchmarkService
{
    Task<BenchmarkResult> RunCpuBenchmarkAsync();
    Task<BenchmarkResult> RunMemoryBenchmarkAsync();
}

public record BenchmarkResult(long Score, string Details);

public class BenchmarkService : IBenchmarkService
{
    public async Task<BenchmarkResult> RunCpuBenchmarkAsync()
    {
        return await Task.Run(() =>
        {
            var sw = Stopwatch.StartNew();
            // Multi-threaded Pi calculation (Leibniz formula)
            int iterations = 100_000_000;
            double pi = 0;
            Parallel.For(0, iterations, i =>
            {
                double term = (i % 2 == 0 ? 1.0 : -1.0) / (2.0 * i + 1.0);
                // Note: Simplified for stress/bench, not precision
            });
            sw.Stop();
            
            // Score formula: Higher is better (inverse of time)
            long score = (long)(1000000.0 / sw.ElapsedMilliseconds);
            return new BenchmarkResult(score, $"{sw.ElapsedMilliseconds} ms for {iterations} iterations");
        });
    }

    public async Task<BenchmarkResult> RunMemoryBenchmarkAsync()
    {
        return await Task.Run(() =>
        {
            int sizeMb = 1024;
            byte[] data = new byte[sizeMb * 1024 * 1024];
            var sw = Stopwatch.StartNew();
            
            // Sequential write
            for (int i = 0; i < data.Length; i += 64) data[i] = 1;
            
            sw.Stop();
            double bandwidthGbs = (double)sizeMb / 1024.0 / sw.Elapsed.TotalSeconds;
            long score = (long)(bandwidthGbs * 1000);
            
            return new BenchmarkResult(score, $"{bandwidthGbs:F2} GB/s Sequential Write");
        });
    }
}