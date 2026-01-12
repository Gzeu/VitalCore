using System;

namespace VitalCore.Models
{
    public class DiskHealth
    {
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = &quot;OK&quot;;
        public bool PredictFailure { get; set; }
        public string Reason { get; set; } = string.Empty;
        public long SizeGB { get; set; }

        public string HealthIcon => PredictFailure ? &quot;⚠️&quot; : Status;
    }
}