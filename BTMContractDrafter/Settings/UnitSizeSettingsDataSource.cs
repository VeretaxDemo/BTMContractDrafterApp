﻿using System.Collections.Generic;
using BTMContractDrafter.Models;
using BTMContractDrafter.WPF.Services;

namespace BTMContractDrafter.WPF.DataSources;

public class UnitSizeSettingsDataSource : IUnitSizeSettingsDataSource
{
    private string _settingsFilePath; // "UnitSizesSettings.json";

    public UnitSizeSettingsDataSource(string settingsFilePath)
    {
        _settingsFilePath = settingsFilePath;
    }
    private List<UnitSize> GetDefaultUnitSizes()
    {
        // Add your default UnitSize objects here
        return new List<UnitSize>
        {
            new UnitSize
            {
                Id = 1, Name = "Company", Description = "A company sized formation",
                MinimumTonnage = 0, MaximumTonnage = 1_500,
                MinimumBV = 0, MaximumBV = 30_000,
                MinimumMHCount = 0, MaximumMHCount = 43
            },
            new UnitSize
            {
                Id = 2, Name = "Battalion", Description = "A battalion sized formation",
                MinimumTonnage = 1_501, MaximumTonnage = 4_500,
                MinimumBV = 30_001, MaximumBV = 90_000,
                MinimumMHCount = 44, MaximumMHCount = 131
            },
            new UnitSize
            {
                Id = 3, Name = "Regiment", Description = "A regiment sized formation",
                MinimumTonnage = 4_501, MaximumTonnage = 13_500,
                MinimumBV = 90_001, MaximumBV = 270_000,
                MinimumMHCount = 132, MaximumMHCount = 395
            },
            new UnitSize
            {
                Id = 4, Name = "Brigade", Description = "A brigade or regimental combat team sized formation",
                MinimumTonnage = 13_501, MaximumTonnage =  40_500,
                MinimumBV = 270_001, MaximumBV = 810_000,
                MinimumMHCount = 396, MaximumMHCount = 791
            },
            new UnitSize
            {
                Id = 5, Name = "Division", Description = "A division sized formation",
                MinimumTonnage = 40_501, MaximumTonnage =  uint.MaxValue,
                MinimumBV = 810_001, MaximumBV = uint.MaxValue,
                MinimumMHCount = 792, MaximumMHCount = uint.MaxValue
            },
        };
    }

    public List<UnitSize> GetUnitSizes()
    {
        string settingsFilePath = _settingsFilePath;
        var dataService = new GeneralSettingsService<UnitSize>(settingsFilePath);

        // Get the default UnitSize objects as a backup
        List<UnitSize> defaultUnitSizes = GetDefaultUnitSizes();

        // Retrieve data from JSON file or generate it if the file doesn't exist
        List<UnitSize> unitSizes = dataService.GetDataFromDataSource(defaultUnitSizes);

        return unitSizes;
    }
}
