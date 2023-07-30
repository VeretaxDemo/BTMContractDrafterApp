using BTMContractDrafter.Models;
using System.Collections.Generic;
using System.Linq;

namespace BTMContractDrafter.Extensions;

public static class OperationalTerrainExtensions
{
    public static OperationalTerrain FindById(this List<OperationalTerrain> operationalTerrainList, int id)
    {
        return operationalTerrainList.FirstOrDefault(ot => ot.Id == id);
    }
}