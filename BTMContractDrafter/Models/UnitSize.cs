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
}