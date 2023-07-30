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
    public uint MaximumBM { get; set;}
    public uint MinimumMHCount { get; set;}
    public uint MaximumMHCount { get; set;}
    public int NegotiationSizeBonus { get; set; }

    public string UnitTonnageParameters
    {
        get
        {
            string value = $"{this.MinimumTonnage} tons and {this.MaximumTonnage} tons";
            return value;
        }
    }

    public string UnitBVParameters
    {
        get
        {
            string value = $"{this.MinimumBV} and {this.MaximumMHCount} military hardware items";
            return value;
        }
    }
    public string UnitMHCountParameters
    {
        get
        {
            string value = $"{this.MinimumMHCount} and {this.MaximumBM} battle value";
            return value;
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