using BTMContractDrafter.Library.Data;
using BTMContractDrafter.Library.Extensions;

namespace BTMContractDrafter.Library.Managers;

public static class SaveDataManager
{
    private static string GetFolderPath(string folderName)
    {
        string baseFolderPath = "SaveData";
        return Path.Combine(baseFolderPath, folderName, "Unit");
    }

    public static void CreateFolders()
    {
        string baseFolderPath = "SaveData";
        Directory.CreateDirectory(baseFolderPath);
        CreateSubFolderIfNotExist("Json");
        CreateSubFolderIfNotExist("Csv");
        CreateSubFolderIfNotExist("PlainText");
    }

    private static void CreateSubFolderIfNotExist(string folderName)
    {
        string subFolderPath = GetFolderPath(folderName);
        Directory.CreateDirectory(subFolderPath);
    }

    public static void SaveJson(string fileName, string jsonData)
    {
        string jsonFolderPath = GetFolderPath("Json");
        string jsonFilePath = Path.Combine(jsonFolderPath, fileName);
        File.WriteAllText(jsonFilePath, jsonData);
    }

    public static void SaveCsv(string fileName, string csvData)
    {
        string csvFolderPath = GetFolderPath("Csv");
        string csvFilePath = Path.Combine(csvFolderPath, fileName);
        File.WriteAllText(csvFilePath, csvData);
    }

    public static void SavePlainText(string fileName, string plainTextData)
    {
        string plainTextFolderPath = GetFolderPath("PlainText");
        string plainTextFilePath = Path.Combine(plainTextFolderPath, fileName);
        File.WriteAllText(plainTextFilePath, plainTextData);
    }

    public static void SaveAllFormats(string fileName, UnitData unitData)
    {
        // Serialize the UnitData object
        string jsonData = unitData.SerializeToJson();
        string csvData = unitData.SerializeToCsv();
        string plainTextData = unitData.SerializeToPlainText();

        // Save data to all formats
        SaveJson(fileName + ".json", jsonData);
        SaveCsv(fileName + ".csv", csvData);
        SavePlainText(fileName + ".txt", plainTextData);
    }
}

