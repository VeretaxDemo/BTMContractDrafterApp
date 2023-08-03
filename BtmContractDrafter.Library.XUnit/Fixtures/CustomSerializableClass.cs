using BTMContractDrafter.Library.Extensions;

namespace BtmContractDrafter.Library.XUnit.Fixtures;

public class CustomSerializableClass : IPlainTextSerializable
{
    public int Value { get; set; }

    public string SerializeToPlainText()
    {
        // Implement the plain text serialization logic here for CustomSerializableClass
        return $"Value: {Value}";
    }
}