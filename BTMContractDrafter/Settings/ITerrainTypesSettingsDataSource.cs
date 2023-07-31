using System.Collections.Generic;
using BTMContractDrafter.Models;

namespace BTMContractDrafter.Settings;

public interface ITerrainTypesSettingsDataSource
{
    List<TerrainType> GetTerrainTypes();
}