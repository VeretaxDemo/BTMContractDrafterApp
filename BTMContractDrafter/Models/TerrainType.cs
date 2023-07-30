namespace BTMContractDrafter.Models;

public class TerrainType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public OperationalTerrain OperationalTerrain { get; set; }
}