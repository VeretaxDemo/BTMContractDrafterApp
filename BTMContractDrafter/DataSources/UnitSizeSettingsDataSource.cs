using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using BTMContractDrafter.Models;

namespace BTMContractDrafter.WPF.DataSources
{
    public class UnitSizeSettingDataSource : IUnitSizeSettingsDataSource
    {
        private List<UnitSize> _unitSizes;

        public UnitSizeSettingDataSource()
        {
            LoadSeedData();
        }

        private void LoadSeedData()
        {
            string seedFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SeedData", "UnitSizeDefinitions.json");

            if (File.Exists(seedFilePath))
            {
                using (StreamReader reader = new StreamReader(seedFilePath))
                {
                    string json = reader.ReadToEnd();
                    _unitSizes = JsonSerializer.Deserialize<List<UnitSize>>(json);
                }
            }
            else
            {
                // Hardcoded defaults
                _unitSizes = new List<UnitSize>
                {
                    new UnitSize
                    {
                        Id = 1,
                        Name = "Company",
                        Description = "A company sized formation",
                        MinimumTonnage = 0,
                        MaximumTonnage = 1500,
                        MinimumBV = 0,
                        MaximumBV = 30000,
                        MinimumMHCount = 0,
                        MaximumMHCount = 43
                    },
                    new UnitSize
                    {
                        Id = 2,
                        Name = "Battalion",
                        Description = "A battalion sized formation",
                        MinimumTonnage = 1501,
                        MaximumTonnage = 4500,
                        MinimumBV = 30001,
                        MaximumBV = 90000,
                        MinimumMHCount = 44,
                        MaximumMHCount = 131
                    },
                    new UnitSize
                    {
                        Id = 3,
                        Name = "Regiment",
                        Description = "A regiment sized formation",
                        MinimumTonnage = 4501,
                        MaximumTonnage = 13500,
                        MinimumBV = 90001,
                        MaximumBV = 270000,
                        MinimumMHCount = 132,
                        MaximumMHCount = 395
                    },
                    new UnitSize
                    {
                        Id = 4,
                        Name = "Brigade",
                        Description = "A brigade or regimental combat team sized formation",
                        MinimumTonnage = 13501,
                        MaximumTonnage = 40500,
                        MinimumBV = 270001,
                        MaximumBV = 810000,
                        MinimumMHCount = 396,
                        MaximumMHCount = 791
                    }
                };
            }
        }

        public List<UnitSize> GetUnitSizes()
        {
            return _unitSizes;
        }
    }
}