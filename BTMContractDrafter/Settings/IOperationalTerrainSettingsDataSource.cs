using System.Collections.Generic;
using BTMContractDrafter.Models;

namespace BTMContractDrafter.Settings;

public interface IOperationalTerrainSettingsDataSource
{
    List<OperationalTerrain> GetOperationalTerrain();
}