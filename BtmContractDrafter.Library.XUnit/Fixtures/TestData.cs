using BTMContractDrafter.Library.Extensions;

namespace BtmContractDrafter.Library.XUnit.Fixtures;

public class TestData : IPlainTextSerializable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SerializeToPlainText()
    {
        // Implement the plain text serialization logic here for TestData
        return $"Id: {Id}, {Environment.NewLine}{Environment.NewLine}Name: {Name}{Environment.NewLine}{Environment.NewLine}";
    }
}