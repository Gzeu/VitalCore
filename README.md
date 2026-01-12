# ⚡ VitalCore (Premium System Monitor, Benchmark & Gaming HUD)

**VitalCore** este un utilitar high-performance pentru Windows 10/11/12, construit cu **WinUI 3** și **.NET 9**. Transformă monitorizarea hardware în experiență premium, cu overlay gaming interactiv, benchmark-uri community și diagnostics avansați.

## 🚀 Features Complete
- **Gaming HUD (Overlay):** Fereastră semi-transparentă always-on-top, draggable, cu metrics CPU/GPU/RAM real-time în jocuri.
- **Stress Test & Benchmark:** Multi-thread CPU (Pi), RAM bandwidth; comparații pe **global Leaderboard** via API.
- **Pro Monitoring:** CPU/RAM/NVIDIA (NVAPI), charts LiveCharts2 high-freq.
- **S.M.A.R.T. Health:** Diagnostics detaliate storage (HDD/SSD): status, predict failure, size, reasons via WMI.[SmartHealthService.cs](VitalCore.Services/SmartHealthService.cs)
- **Advanced Settings:** Custom accent colors (ColorPicker), alert thresholds sliders (CPU/RAM/GPU), persistente LocalSettings.[AdvancedSettingsPage](VitalCore.UI/Pages/AdvancedSettingsPage.xaml)
- **UI/UX Modern:** Mica Alt, Fluent 2.0, hover transitions, Mica backdrop.
- **Export & More:** JSON snapshots, drag-drop window mgmt.

## 📱 Visual Assets
Structură pregătită în `VitalCore.UI/Assets/` cu specs pentru logo (1024x1024 cyan glassmorphism), splash (620x300), store icon (50x50).[Assets README](VitalCore.UI/Assets/README.md)

## 🛠️ Tech Stack
- **Framework:** Windows App SDK 1.8 (WinUI 3)
- **.NET:** 9.0
- **Charts:** LiveCharts2
- **Interop:** WMI (S.M.A.R.T.), NVAPI, PerformanceCounters
- **Storage:** LocalSettings, JSON export
- **Windows:** AppWindow (overlay), Mica

## 📥 Build & Run
1. `git clone https://github.com/Gzeu/VitalCore.git`
2. Deschide `VitalCore.sln` în VS 2022+ (x64).
3. **Admin mode** pentru NVIDIA/WMI full access.
4. Build → Deploy local.

![Overview](/VitalCore.UI/Assets/splash-preview.png) <!-- Placeholder -->
![HUD Overlay] <!-- Add screenshots -->

## 📅 Roadmap (Completed)
- [x] MVP Monitoring/UI
- [x] Benchmarks/Leaderboard
- [x] Gaming HUD
- [x] S.M.A.R.T. Health
- [x] Advanced Settings
- [ ] Store submission

---
*Built by George Pricop (Gzeu), București, RO. Premium hardware insights.*