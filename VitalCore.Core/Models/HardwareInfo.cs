using System;

namespace VitalCore.Core.Models;

public record HardwareInfo
{
    public string Name { get; init; } = string.Empty;
    public float Temperature { get; init; }
    public float Usage { get; init; }
    public float FanSpeed { get; init; }
}