using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using VitalCore.Models;

namespace VitalCore.UI.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection&lt;NavItem&gt; menuItems = new()
        {
            new NavItem { Label = &quot;🏠 Overview&quot;, Icon = &quot;Home&quot;, Tag = &quot;overview&quot; },
            new NavItem { Label = &quot;⚡ Benchmark&quot;, Icon = &quot;Speedometer&quot;, Tag = &quot;bench&quot; },
            new NavItem { Label = &quot;💾 SMART Health&quot;, Icon = &quot;DriveFile&quot;, Tag = &quot;smart&quot; },
            new NavItem { Label = &quot;🎮 HUD Overlay&quot;, Icon = &quot;Game&quot;, Tag = &quot;hud&quot; },
            new NavItem { Label = &quot;⚙️ Settings&quot;, Icon = &quot;Settings&quot;, Tag = &quot;settings&quot; }
        };
    }
}