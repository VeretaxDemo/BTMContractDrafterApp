using System.Collections.Generic;
using BTMContractDrafter.Models;

namespace BTMContractDrafter.Settings;

public interface IUnitSizeSettingsDataSource
{
    List<UnitSize> GetUnitSizes();
}