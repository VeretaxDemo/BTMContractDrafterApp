using BTMContractDrafter.Library.Data;
using BTMContractDrafter.Library.Extensions;
using BTMContractDrafter.Library.IO;
using System.Text.RegularExpressions;

namespace BTMContractDrafter.Library.Managers;

public static class SaveDataManager
{
    public static string GetFolderPath(string folderName, string dataTypePath)
    {
        string baseFolderPath = "SaveData";
        return Path.Combine(baseFolderPath, folderName, dataTypePath);
    }

    public static void CreateFolders()
    {
        string baseFolderPath = "SaveData";
        Directory.CreateDirectory(baseFolderPath);
        CreateSubFolderIfNotExist("Json", "Unit");
        CreateSubFolderIfNotExist("Csv", "Unit");
        CreateSubFolderIfNotExist("PlainText", "Unit");
    }

    private static void CreateSubFolderIfNotExist(string folderName, string dataTypePath)
    {
        string subFolderPath = GetFolderPath(folderName, dataTypePath);
        Directory.CreateDirectory(subFolderPath);
    }

    public static void SaveJson(string fileName, string jsonData, IFileSystem fileSystem, string dataTypePath)
    {
        string jsonFolderPath = GetFolderPath("Json", dataTypePath);
        string jsonFilePath = Path.Combine(jsonFolderPath, fileName);
        fileSystem.WriteAllText(jsonFilePath, jsonData);
    }

    public static void SaveCsv(string fileName, string csvData, IFileSystem fileSystem, string dataTypePath)
    {
        string csvFolderPath = GetFolderPath("Csv", dataTypePath);
        string csvFilePath = Path.Combine(csvFolderPath, fileName);
        fileSystem.WriteAllText(csvFilePath, csvData);
    }

    public static void SavePlainText(string fileName, string plainTextData, IFileSystem fileSystem, string dataTypePath)
    {
        string plainTextFolderPath = GetFolderPath("PlainText", dataTypePath);
        string plainTextFilePath = Path.Combine(plainTextFolderPath, fileName);
        fileSystem.WriteAllText(plainTextFilePath, plainTextData);
    }

    //public static void SaveJson(string fileName, string jsonData)
    //{

    //    string jsonFolderPath = GetFolderPath("Json", "Unit");
    //    string jsonFilePath = Path.Combine(jsonFolderPath, fileName);
    //    File.WriteAllText(jsonFilePath, jsonData);
    //}

    //public static void SaveCsv(string fileName, string csvData)
    //{
    //    string csvFolderPath = GetFolderPath("Csv", "Unit");
    //    string csvFilePath = Path.Combine(csvFolderPath, fileName);
    //    File.WriteAllText(csvFilePath, csvData);
    //}

    //public static void SavePlainText(string fileName, string plainTextData)
    //{
    //    string plainTextFolderPath = GetFolderPath("PlainText", "Unit");
    //    string plainTextFilePath = Path.Combine(plainTextFolderPath, fileName);
    //    File.WriteAllText(plainTextFilePath, plainTextData);
    //}

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

