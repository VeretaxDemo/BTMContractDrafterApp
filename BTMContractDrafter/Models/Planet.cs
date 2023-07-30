namespace BTMContractDrafter.Models;

public class Planet
{
    public PlanetaryTechLevel PlanetaryTechLevel = new PlanetaryTechLevel();
    public string PlanetarySystemName { get; set; } = string.Empty;
    public string PlanetName { get; set; } = string.Empty;
    public string PlanetType { get; set; } = string.Empty;
    public string PlanetCapital { get; set; } = string.Empty;
    public string SarnaLink { get; set; } = string.Empty;
    public string FactionOwner { get; set; } = string.Empty;
    public string XCoordinate { get; set; } = string.Empty;
    public string YCoordinate { get; set; } = string.Empty;
    public string DistanceToJumpPoint { get; set; } = string.Empty;
    public string PrimaryClimate { get; set; } = string.Empty;
    public string Population { get; set; } = string.Empty;
    public string PlantDetails { get; set; } = string.Empty;
}