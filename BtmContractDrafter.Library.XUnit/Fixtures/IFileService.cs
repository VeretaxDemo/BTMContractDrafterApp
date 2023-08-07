namespace BtmContractDrafter.Library.XUnit.Fixtures;

public interface IFileService
{
    void WriteAllText(string path, string content);
}