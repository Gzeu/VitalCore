# ⚡ VitalCore (System Monitor, Benchmark & Gaming HUD)

**VitalCore** is a versatile, high-performance system utility for Windows 10/11/12. Built with **WinUI 3** and **.NET 9**, it transforms hardware monitoring into a premium experience, combining deep system analysis with interactive gaming overlays and community-driven benchmarking.

## 🚀 Versatile Feature Set
- **Gaming HUD (Overlay):** A semi-transparent, "always-on-top" floating window that tracks CPU/GPU/RAM metrics while gaming. Supports real-time drag-and-drop positioning.
- **Stress Test Engine:** Integrated multi-threaded stress tests for CPU and RAM to verify system stability under extreme loads.
- **Community Benchmarking:** Run standardized Pi and Memory bandwidth tests and compare your results on the global **VitalCore Leaderboard**.
- **Modern UI/UX:** Leveraging **Mica Alt** and **Fluent Design** for a professional look that fits perfectly with Windows 11/12.
- **Pro Monitoring:** Real-time data via **NVAPI** for NVIDIA GPUs and **WMI/PerformanceCounters** for system-wide telemetry.

## 🛠️ Technology Stack
- **Framework:** Windows App SDK 1.8 (WinUI 3)
- **Runtime:** .NET 9.0 (optimized JIT)
- **Charting:** LiveCharts2 (High-frequency rendering)
- **Networking:** REST API client for leaderboard integration
- **Interop:** Win32/AppWindow for advanced window management (Always-on-top, Click-through)

## 📥 Installation & Build
1. **Clone:** `git clone https://github.com/Gzeu/VitalCore.git`
2. **Visual Studio:** Open `VitalCore.sln` (requires VS 2022 17.12+).
3. **Architecture:** Set to `x64`.
4. **Permissions:** Run as Administrator for full sensor access (NVIDIA Fan/Voltage).

## 📅 Roadmap
- [x] **MVP:** Basic monitoring and UI.
- [x] **Benchmarks:** CPU/RAM scores and API integration.
- [x] **Gaming HUD:** Interactive draggable overlay.
- [ ] **S.M.A.R.T. Health:** Detailed storage diagnostics.
- [ ] **Advanced Settings:** Custom accent colors and alert thresholds.

---
Elevating Windows system tools to a new standard of clarity and performance.
Built by George Pricop (Gzeu) in București, Romania.
