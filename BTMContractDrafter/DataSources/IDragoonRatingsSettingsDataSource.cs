using BTMContractDrafter.WPF.Models.NegotiationPoints;

namespace BTMContractDrafter.WPF.DataSources;

public interface IDragoonRatingsSettingsDataSource
{
    IDragoonRatingModifiers GetDragoonRatings();
}