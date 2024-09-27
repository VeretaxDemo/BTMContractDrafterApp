using System.Collections.Generic;
using BTMContractDrafter.WPF.Models.NegotiationPoints;
using BTMContractDrafter.WPF.Services;

namespace BTMContractDrafter.WPF.DataSources;

public class DragoonRatingsSettingsDataSource : IDragoonRatingsSettingsDataSource
{
    private string _settingsFilePath; //"DragoonRatingsSettings.json";
    /*private IDragoonRatingsSettingsDataSource _dragoonRatings { get; set; }*/
    private IDragoonRatingModifiers _dragoonRatings { get; set; }
    public DragoonRatingsSettingsDataSource(string settingsFilePath, IDragoonRatingModifiers dragoonRatings)
    {
        _settingsFilePath = settingsFilePath;
        _dragoonRatings = dragoonRatings;
        /*_dragoonRatings = dragoonRatingsSettingsDataSource;*/
    }

    private IDragoonRatingModifiers GetDefaultDragoonRatings()
    {
        Dictionary<string, short> dictionaryData = new Dictionary<string, short>
        {
            { "F", -5 },
            { "D", -3 },
            { "C", 0 },
            { "B", 3 },
            { "A", 5 },
            // we aren't enabling S right now { "S", 7 }
            // we aren't enabling S_Plus right now { "S+", 10 }
        };
        return new DragoonRatingModifiers(dictionaryData);
    }

    public IDragoonRatingModifiers GetDragoonRatings()
    {
        var dataService = new GeneralSettingsService<DragoonRatingModifiers>(_settingsFilePath);

        // Get the default UnitSize objects as a backup
        DragoonRatingModifiers defaultDragoonRatingModifiers = GetDefaultDragoonRatings() as DragoonRatingModifiers;

        // Retrieve data from JSON file or generate it if the file doesn't exist
        DragoonRatingModifiers dragoonRatingModifiers = dataService.GetDataFromDataSource(defaultDragoonRatingModifiers);
        return dragoonRatingModifiers;
    }

}