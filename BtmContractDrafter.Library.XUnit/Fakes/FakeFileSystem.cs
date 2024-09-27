using BTMContractDrafter.Library.IO;

namespace BtmContractDrafter.Library.XUnit.Fakes;

public class FakeFileSystem : IFileSystem
{
    public Dictionary<string, string> Files { get; } = new Dictionary<string, string>();

    public void WriteAllText(string path, string contents)
    {
        Files[path] = contents;
    }

    public bool FileExists(string path)
    {
        return Files.ContainsKey(path);
    }

    public FakeFile GetFile(string path)
    {
        if (Files.TryGetValue(path, out string contents))
        {
            return new FakeFile(path, contents);
        }

        return null;
    }

}