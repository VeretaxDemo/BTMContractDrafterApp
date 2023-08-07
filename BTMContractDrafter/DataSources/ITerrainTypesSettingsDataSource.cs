using System.Collections.Generic;
using BTMContractDrafter.Models;

namespace BTMContractDrafter.WPF.DataSources;

public interface ITerrainTypesSettingsDataSource
{
    List<TerrainType> GetTerrainTypes();
}