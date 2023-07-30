using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.IO;

namespace BTMContractDrafter.Settings;

public class GeneralSettingsService<T>
{
    private string _settingsFilePath;

    public GeneralSettingsService(string settingsFilePath)
    {
        _settingsFilePath = settingsFilePath;
    }

    public List<T> GetDataFromDataSource(List<T> defaultData)
    {
        if (!File.Exists(_settingsFilePath))
        {
            ShowMessageBox("Data file not found. Generating using default settings.");

            try
            {
                // Serialize the default data to JSON
                string jsonDefaultContent = JsonConvert.SerializeObject(defaultData, Formatting.Indented);

                // Create the settings file and write the JSON content to it
                File.WriteAllText(_settingsFilePath, jsonDefaultContent);
            }
            catch (Exception ex)
            {
                ShowMessageBox($"Error creating data file: {ex.Message}");
            }

            // Return the default data as a backup
            return defaultData;
        }

        // Read JSON data from the file
        string jsonContent = File.ReadAllText(_settingsFilePath);

        // Deserialize JSON to a list of objects of type T
        List<T> data = JsonConvert.DeserializeObject<List<T>>(jsonContent);

        return data;
    }

    private void ShowMessageBox(string message)
    {
        // Handle the display of the message box here
        // For example, you can use a cross-platform library or the UI framework available in your application
        // For the sake of example, we'll just print the message to the console
        Console.WriteLine(message);
    }
}