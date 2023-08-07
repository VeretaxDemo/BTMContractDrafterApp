namespace BTMContractDrafter.Library.IO;

public interface IFileSystem
{
    void WriteAllText(string path, string contents);
}