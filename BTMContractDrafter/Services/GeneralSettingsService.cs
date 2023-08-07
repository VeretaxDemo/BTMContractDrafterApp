using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using BTMContractDrafter.Library.Extensions;

namespace BTMContractDrafter.WPF.Services;

// note we moved this to System.Text.Json, but this whole class may need moved to the Library.
// And we should look for all places Newtonsoft is used and replace them
public class GeneralSettingsService<T>
{
    private string _settingsFilePath;

    public GeneralSettingsService(string settingsFilePath)
    {
        _settingsFilePath = settingsFilePath;
    }

    //public List<T> GetDataFromDataSource(List<T> defaultData)
    //{
    //    if (!File.Exists(_settingsFilePath))
    //    {
    //        ShowMessageBox("Data file not found. Generating using default settings.");

    //        try
    //        {
    //            // Serialize the default data to JSON
    //            string jsonDefaultContent = JsonSerializer.Serialize(defaultData, new JsonSerializerOptions { WriteIndented = true });

    //            // Create the settings file and write the JSON content to it
    //            File.WriteAllText(_settingsFilePath, jsonDefaultContent);
    //        }
    //        catch (Exception ex)
    //        {
    //            ShowMessageBox($"Error creating data file: {ex.Message}");
    //        }

    //        // Return the default data as a backup
    //        return defaultData;
    //    }
    //    // Read JSON data from the file
    //    string jsonContent = File.ReadAllText(_settingsFilePath);

    //    // Deserialize JSON to a list of objects of type T
    //    List<T> data = JsonSerializer.Deserialize<List<T>>(jsonContent);

    //    return data;
    //}

    public T GetDataFromDataSource<T>(T defaultData)
    {
        if (!File.Exists(_settingsFilePath))
        {
            ShowMessageBox("Data file not found. Generating using default settings.");

            try
            {
                // Serialize the default data to JSON
                string jsonDefaultContent = defaultData.SerializeToJson();

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

        // Deserialize JSON to an object of type T
        T data = JsonSerializer.Deserialize<T>(jsonContent);

        return data;
    }

    //private string SerializeToJson(T data)
    //{
    //    JsonSerializerOptions options = new JsonSerializerOptions
    //    {
    //        WriteIndented = true
    //    };

    //    return JsonSerializer.Serialize(data, options);
    //}

    //private T DeserializeFromJson<T>(string jsonContent)
    //{
    //    return JsonSerializer.Deserialize<T>(jsonContent);
    //}
    private string SerializeToJson(T data)
    {
        return data.SerializeToJson();
    }

    private T DeserializeFromJson<T>(string jsonContent)
    {
        return JsonSerializer.Deserialize<T>(jsonContent);
    }

    private void ShowMessageBox(string message)
    {
        // Handle the display of the message box here
        // For example, you can use a cross-platform library or the UI framework available in your application
        // For the sake of example, we'll just print the message to the console
        Console.WriteLine(message);
    }
}