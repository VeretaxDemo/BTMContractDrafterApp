using System.Collections.Generic;

namespace BTMContractDrafter.WPF.Models.NegotiationPoints;

public class DragoonRatingModifiers : IDragoonRatingModifiers
{
    public DragoonRatingModifiers(IReadOnlyDictionary<string, short> dragoonModifier)
    {
        DragoonModifier = dragoonModifier;
    }

    public IReadOnlyDictionary<string, short> DragoonModifier { get; private set; }
}