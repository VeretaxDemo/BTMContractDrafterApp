using BTMContractDrafter.Library.Data;
using BTMContractDrafter.Library.IO;
using BTMContractDrafter.Library.Managers;

namespace BTMContractDrafter.Library.Extensions;

public static class UnitDataSerializerExtension
{
    // Function to create a valid filename
    public static string CreateValidFilename(this UnitData unit)
    {
        // Get Date to append later
        String date = DateTime.Now.ToShortDateString();

        // Sanitize UnitName and UnitSizeName
        string sanitizedUnitName = SaveDataManager.SanitizeFilename(unit.UnitName);
        string sanitizedUnitSizeName = SaveDataManager.SanitizeFilename(unit.UnitSizeName);

        // Combine sanitized strings with date
        string filename = $"{sanitizedUnitName}-{sanitizedUnitSizeName}-{date:yyyyMMdd_HHmmss}";

        // Limit filename length if needed
        int maxFilenameLength = 255; // Adjust this based on your target file system's limit
        filename = SaveDataManager.TruncateFilename(filename, maxFilenameLength);

        return filename;
    }

    public static void SaveAllFormats(this UnitData unitData)
    {
        // Get fileName
        string fileName = unitData.CreateValidFilename();
        // Serialize the UnitData object
        string jsonData = unitData.SerializeToJson();
        string csvData = unitData.SerializeToCsv();
        string plainTextData = unitData.SerializeToPlainText();

        string sanitizedFileName = SaveDataManager.SanitizeFilename(fileName);
        IFileSystem fileSystem = new FileSystem();
        // Save data to all formats
        var dataTypePath = "Unit";
        SaveDataManager.SaveJson(sanitizedFileName + ".json", jsonData, fileSystem, dataTypePath);
        SaveDataManager.SaveCsv(sanitizedFileName + ".csv", csvData, fileSystem, dataTypePath);
        SaveDataManager.SavePlainText(sanitizedFileName + ".txt", plainTextData, fileSystem, dataTypePath);
    }
}