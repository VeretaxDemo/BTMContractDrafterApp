using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using global::BTMContractDrafter.Models;
using Newtonsoft.Json;

namespace BTMContractDrafter.Settings;

public class UnitSizeSettings
{
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

    public List<UnitSize> GetUnitSizesFromDataSource()
    {
        string settingsFilePath = "UnitSizesSettings.json";

        if (!File.Exists(settingsFilePath))
        {
            // Handle the case when the settings file is missing or not found.
            // You can display an alert or a message box to inform the user.
            MessageBox.Show("UnitSizesSettings.json file not found. Generating using default settings.");

            // Get the default UnitSize objects as a backup
            List<UnitSize> defaultUnitSizes = GetDefaultUnitSizes();

            try
            {
                // Serialize the default UnitSize data to JSON
                string jsonDefaultContent = JsonConvert.SerializeObject(defaultUnitSizes, Formatting.Indented);

                // Create the settings file and write the JSON content to it
                File.WriteAllText(settingsFilePath, jsonDefaultContent);
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur during file creation
                MessageBox.Show($"Error creating UnitSizesSettings.json: {ex.Message}");
            }

            // Return the default UnitSize objects
            return defaultUnitSizes;
        }

        // Read JSON data from the file
        string jsonContent = File.ReadAllText(settingsFilePath);

        // Deserialize JSON to a list of UnitSize objects
        List<UnitSize> unitSizes = JsonConvert.DeserializeObject<List<UnitSize>>(jsonContent);

        return unitSizes;
    }
}
