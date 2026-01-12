using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace VitalCore.Core.Services;

public interface IApiService
{
    Task<bool> SubmitScoreAsync(BenchmarkPayload payload);
}

public record BenchmarkPayload(
    string UserName,
    string CpuName,
    long CpuScore,
    double RamBandwidth,
    string OsVersion,
    DateTime Timestamp
);

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://api.vitalcore-stats.io/v1"; // Exemplu URL comunitate

    public ApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "VitalCore-App-2026");
    }

    public async Task<bool> SubmitScoreAsync(BenchmarkPayload payload)
    {
        try
        {
            // Trimitere asincronă către endpoint-ul de leaderboard
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/scores/submit", payload);
            
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            // Fallback: Logare eroare sau returnare false pentru UI handling
            return false;
        }
    }
}