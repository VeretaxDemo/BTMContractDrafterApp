using BTMContractDrafter.Library.Extensions;

namespace BtmContractDrafter.Library.XUnit.Fixtures;

public class AnotherTestData : IPlainTextSerializable
{
    public int Id { get; set; }
    public string Description { get; set; }

    public string SerializeToPlainText()
    {
        // Implement the plain text serialization logic here for TestData
        return $"Id: {Id}, {Environment.NewLine}{Environment.NewLine}Description: {Description}{Environment.NewLine}{Environment.NewLine}";
    }
}