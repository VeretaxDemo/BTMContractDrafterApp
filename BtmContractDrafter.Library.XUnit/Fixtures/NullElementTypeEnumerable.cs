using System.Collections;

namespace BtmContractDrafter.Library.XUnit.Fixtures;

public class NullElementTypeEnumerable : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield break;
    }

    public Type GetType()
    {
        return null;
    }

}