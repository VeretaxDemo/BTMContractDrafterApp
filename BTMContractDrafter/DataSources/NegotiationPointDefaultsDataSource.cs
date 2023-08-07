using BTMContractDrafter.WPF.Settings.NegotiationPoints;

namespace BTMContractDrafter.WPF.DataSources;

public class NegotiationPointDefaultsDataSource
{
    private string _settingsFilePath; //"NegotiationPointsSettings.json";
    private string _defaultKeyName = "Defaults";

    private NegotiationPointDefaults GetDefaultNegotiationPoints()
    {
        return new NegotiationPointDefaults
        {
            BasePoints = 5,
            UnitSize = 1,
            DragoonRatingValue = -5,
            DragoonRating = "F",
            EmployerReputation = 0,
            PayRate = 900,
            ContractTime = 3,
            ContractWordGoal = 40000,
            DoubleSalvageWordGoal = 100000,
            EmployerReputationGain = 3,
            OppositionReputationLoss = -3
        };

    }
}