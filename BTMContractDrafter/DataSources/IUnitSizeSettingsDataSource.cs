using System.Collections.Generic;
using BTMContractDrafter.Models;

namespace BTMContractDrafter.WPF.DataSources;

public interface IUnitSizeSettingsDataSource
{
    List<UnitSize> GetUnitSizes();
}