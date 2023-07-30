using System.Configuration;

namespace BTMContractDrafter.Models;

public class UnitSize
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public uint MinimumTonnage { get; set;}
    public uint MaximumTonnage { get; set;}
    public uint MinimumBV { get; set;}
    public uint MaximumBV { get; set;}
    public uint MinimumMHCount { get; set;}
    public uint MaximumMHCount { get; set;}
    public int NegotiationSizeBonus { get; set; }

    public string UnitTonnageParameters
    {
        get
        {
            string minTonnage = this.MinimumTonnage.ToString("N0");
            string maxTonnage = this.MaximumTonnage == uint.MaxValue ? "unlimited" : this.MaximumTonnage.ToString("N0");
            return $"{minTonnage} tons and {maxTonnage} tons";
        }
    }

    public string UnitBVParameters
    {
        get
        {
            string minBV = this.MinimumBV.ToString("N0");
            string maxBV = this.MaximumBV == uint.MaxValue ? "unlimited" : this.MaximumBV.ToString("N0");
            return $"{minBV} and {maxBV} battle value";
        }
    }
    public string UnitMHCountParameters
    {
        get
        {
            string minMHCount = this.MinimumMHCount.ToString("N0");
            string maxMHCount = this.MaximumMHCount == uint.MaxValue ? "unlimited" : this.MaximumMHCount.ToString("N0");
            return $"{minMHCount} and {maxMHCount} military hardware items";
        }
    }

    public string UnitSizeParameters
    {
        get
        {
            string value = $"{UnitTonnageParameters}, {UnitBVParameters}, and has {UnitMHCountParameters}";
            return value;
        }
    }
}