using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using VitalCore.Core.Models;

namespace VitalCore.Core.Services;

public interface IExportService
{
    Task<bool> ExportSnapshotAsync(object data, string format = "json");
}

public class ExportService : IExportService
{
    public async Task<bool> ExportSnapshotAsync(object data, string format = "json")
    {
        try
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            
            var savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add("JSON File", new[] { ".json" });
            savePicker.SuggestedFileName = $"VitalCore_Snapshot_{DateTime.Now:yyyyMMdd_HHmm}";

            // Note: For WinUI 3, we need to associate the picker with the window handle
            // This logic is typically handled in the UI layer or via a Window helper
            
            // Temporary logic for headless/core testing:
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = Path.Combine(folder, $"{savePicker.SuggestedFileName}.json");
            await File.WriteAllTextAsync(path, json);
            
            return true;
        }
        catch { return false; }
    }
}