using BTMContractDrafter.Library.Extensions;
using BTMContractDrafter.Library.IO;
using BTMContractDrafter.Library.Managers;

namespace BTMContractDrafter.Library.Data;

public class UnitData : IPlainTextSerializable, ISanitizedFilenameCreator
{
    public int UnitSizeId { get; set; } = 1;
    public string UnitSizeName { get; set; } = string.Empty;
    public string UnitName { get; set; } = string.Empty;
    public string DragoonRating { get; set; } = string.Empty;
    public string EmployerFactionReputation { get; set; } = string.Empty;
    public string OppositionFactionReputation { get; set; } = string.Empty;
    public string SerializeToPlainText()
    {
        string output = $"Id: {UnitSizeId}{Environment.NewLine}{Environment.NewLine}Unit Name: {UnitName}{Environment.NewLine}{Environment.NewLine}Unit Size Id: {UnitSizeId}{Environment.NewLine}{Environment.NewLine}Unit Size Name: {UnitSizeName}{Environment.NewLine}{Environment.NewLine}Dragoon Rating: {DragoonRating}{Environment.NewLine}{Environment.NewLine}Employer Reputation: {EmployerFactionReputation}{Environment.NewLine}{Environment.NewLine}Opposition Reputation: {OppositionFactionReputation}{Environment.NewLine}{Environment.NewLine}";
        return output;
    }


    public string GenerateValidFilename()
    {
        return this.CreateValidFilename(UnitDataSerializerExtension.DefaultDateFormat);
    }

    public bool SaveUnitDataInAllFormats()
    {
        bool result = false;
        try
        {
            this.SaveAllFormats();
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }
}