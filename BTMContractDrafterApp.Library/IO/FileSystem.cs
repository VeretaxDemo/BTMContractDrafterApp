namespace BTMContractDrafter.Library.IO;

public class FileSystem : IFileSystem
{
    public void WriteAllText(string path, string contents)
    {
        File.WriteAllText(path, contents);
    }

    // Implement other file system operations if needed
}