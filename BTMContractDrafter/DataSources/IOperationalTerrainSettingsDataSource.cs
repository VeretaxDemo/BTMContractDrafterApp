using System.Collections.Generic;
using BTMContractDrafter.Models;

namespace BTMContractDrafter.WPF.DataSources;

public interface IOperationalTerrainSettingsDataSource
{
    List<OperationalTerrain> GetOperationalTerrain();
}