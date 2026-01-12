using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using VitalCore.Models;

namespace VitalCore.Services
{
    public class SmartHealthService
    {
        public List&lt;DiskHealth&gt; GetDiskHealth()
        {
            var disks = new List&lt;DiskHealth&gt;();

            // Basic disk status
            var searcher = new ManagementObjectSearcher(&quot;SELECT * FROM Win32_DiskDrive&quot;);
            foreach (ManagementObject disk in searcher.Get())
            {
                var health = new DiskHealth
                {
                    Name = disk[&quot;Model&quot;]?.ToString() ?? &quot;Unknown Disk&quot;,
                    Status = disk[&quot;Status&quot;]?.ToString() ?? &quot;OK&quot;,
                    SizeGB = Convert.ToInt64(disk[&quot;Size&quot;]) / (1024 * 1024 * 1024)
                };

                // S.M.A.R.T. predict failure
                try
                {
                    using var predictScope = new ManagementScope(&quot;root\\wmi&quot;);
                    var predictQuery = new ObjectQuery(&quot;SELECT * FROM MSStorageDriver_FailurePredictStatus WHERE InstanceName LIKE '%&quot; + health.Name + &quot;%'&quot;);
                    var predictSearcher = new ManagementObjectSearcher(predictScope, predictQuery);
                    var predictObj = predictSearcher.Get().Cast&lt;ManagementObject&gt;().FirstOrDefault();
                    if (predictObj != null)
                    {
                        health.PredictFailure = predictObj[&quot;PredictFailure&quot;]?.ToString() == bool.TrueString;
                        health.Reason = predictObj[&quot;Reason&quot;]?.ToString();
                    }
                }
                catch (Exception ex)
                {
                    health.Status = &quot;Error: &quot; + ex.Message;
                }

                disks.Add(health);
            }
            return disks;
        }
    }
}