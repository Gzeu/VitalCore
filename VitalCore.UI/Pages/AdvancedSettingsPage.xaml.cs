using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Storage;
using VitalCore.Services;

namespace VitalCore.UI.Pages
{
    public sealed partial class AdvancedSettingsPage : Page
    {
        private readonly SmartHealthService _smartService = new();
        private const string SETTINGS_KEY = &quot;LocalSettings&quot;;

        public AdvancedSettingsPage()
        {
            this.InitializeComponent();
            LoadSettings();
        }

        private async void LoadSettings()
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            AccentPicker.Color = XamlRoot.ColorToHsl(localSettings.Values[&quot;AccentColor&quot;] as string ?? &quot;#00BFFF&quot;);
            CpuThresholdSlider.Value = (double)(localSettings.Values[&quot;CpuThreshold&quot;] ?? 80);
        }

        private async void AccentPicker_ColorChanged(ColorPicker sender, ColorChangedEventArgs args)
        {
            var settings = ApplicationData.Current.LocalSettings;
            settings.Values[&quot;AccentColor&quot;] = args.NewColor.ToString();
            // Apply theme: RequestedThemeColors etc.
        }

        private async void ThresholdSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            ApplicationData.Current.LocalSettings.Values[&quot;CpuThreshold&quot;] = CpuThresholdSlider.Value;
        }

        private async void ScanStorage_Click(object sender, RoutedEventArgs e)
        {
            var healths = _smartService.GetDiskHealth();
            DiskListView.ItemsSource = healths;
        }
    }
}