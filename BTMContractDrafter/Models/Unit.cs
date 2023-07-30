namespace BTMContractDrafter.Models;

public class Unit
{
    public UnitSize UnitSize = new UnitSize();
    public string UnitName { get; set; } = string.Empty;
    public string DragoonRating { get; set; } = string.Empty;
    public string EmployerFactionReputation { get; set; } = string.Empty;
    public string OppositionFactionReputation { get; set; } = string.Empty;
}