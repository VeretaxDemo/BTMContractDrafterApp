using System.Collections.Generic;

namespace BTMContractDrafter.WPF.Models.NegotiationPoints;

public interface IDragoonRatingModifiers
{
    IReadOnlyDictionary<string, short> DragoonModifier { get; }
}