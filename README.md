# ⚡ VitalCore (System Monitor & Benchmark)

**VitalCore** is a modern, high-performance system information and hardware monitoring tool for Windows 10/11/12. Built with **WinUI 3** and **.NET 9**, it serves as a beautiful alternative to classic tools like HWiNFO or MSI Afterburner, featuring a premium Fluent Design interface.

## ✨ Features (MVP)
- **Modern UI:** Full Mica Alt backdrop support, acrylic materials, and smooth animations.
- **Hardware Monitoring:** Real-time tracking for CPU usage, RAM availability, and GPU stats.
- **NVIDIA Integration:** Precise temperature and load monitoring via **NVAPI**.
- **Live Graphics:** Beautiful, high-performance real-time charts powered by **LiveCharts2**.
- **Fluent Iconography:** Perfectly scalable icons using **Segoe Fluent Icons**.
- **Dark/Light Mode:** Full system theme synchronization.

## 🛠️ Tech Stack (January 2026)
- **Framework:** [Windows App SDK 1.8 (WinUI 3)](https://github.com/microsoft/microsoft-ui-xaml)
- **Runtime:** [.NET 9.0](https://dotnet.microsoft.com/download/dotnet/9.0)
- **Pattern:** MVVM via [CommunityToolkit.Mvvm 8.3](https://github.com/CommunityToolkit/dotnet)
- **Charting:** [LiveCharts2 (Beta)](https://github.com/beto-rodriguez/LiveCharts2)
- **GPU API:** [NvAPIWrapper](https://github.com/falahati/NvAPIWrapper)

## 🚀 Getting Started
1. **Clone the repo:**
   ```bash
   git clone https://github.com/Gzeu/VitalCore.git
   ```
2. **Open the Solution:** Use Visual Studio 2022 (v17.12 or newer).
3. **Build & Run:** Select `x64` architecture and start the `VitalCore.UI` project.

## 📅 Roadmap
- [ ] **Gaming Overlay:** Floating "Always-on-Top" window for FPS and Temps.
- [ ] **Benchmarks:** Multi-threaded CPU stress testing and RAM bandwidth metrics.
- [ ] **S.M.A.R.T. Health:** Detailed SSD/HDD health and temperature reports.
- [ ] **Export:** Snapshot system to JSON/CSV.

---
Built with 💙 by George Pricop (Gzeu) in București, Romania.
