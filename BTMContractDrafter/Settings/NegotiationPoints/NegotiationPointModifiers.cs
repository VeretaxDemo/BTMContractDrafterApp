using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.AccessControl;
using BTMContractDrafter.WPF.Models.NegotiationPoints;

namespace BTMContractDrafter.WPF.Settings.NegotiationPoints;

public class NegotiationPointModifiers
{
    private readonly DragoonRatingModifiers _dragoonRatingModifiers;

    public NegotiationPointModifiers(IReadOnlyDictionary<string, short> dragoonModifier)
    {
        _dragoonRatingModifiers = new DragoonRatingModifiers(dragoonModifier);
    }

    public DragoonRatingModifiers DragoonRatingsB => _dragoonRatingModifiers;
}