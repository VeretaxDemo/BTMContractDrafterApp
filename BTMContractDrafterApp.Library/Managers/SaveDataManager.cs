using BTMContractDrafter.Library.Data;
using BTMContractDrafter.Library.Extensions;
using System.Text.RegularExpressions;

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

    public static string SanitizeFilename(string filename)
    {
        string invalidChars = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
        Regex regex = new Regex($"[{Regex.Escape(invalidChars)}]");
        return regex.Replace(filename, "");
    }

    // Function to limit filename length
    public static string TruncateFilename(string filename, int maxLength)
    {
        if (filename.Length <= maxLength)
            return filename;
        return filename.Substring(0, maxLength);
    }



}

