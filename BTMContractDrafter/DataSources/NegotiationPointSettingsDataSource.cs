using System.IO;
using BTMContractDrafter.WPF.Settings.NegotiationPoints;
using System.Text.Json;
using BTMContractDrafter.Models;
using BTMContractDrafter.WPF.Services;
using System.Collections.Generic;

namespace BTMContractDrafter.WPF.DataSources;

public class NegotiationPointSettingsDataSource : INegotiationPointSettingsDataSource
{
    private readonly string _settingsFilePath; //"NegotiationPointsSettings.json";
    private string _defaultKeyName = "Defaults";
    private string _maximumsKeyName = "Maximums";
    private string _minimumsKeyName = "Minimums";

    public NegotiationPointSettingsDataSource(string settingsFilePath)
    {
        _settingsFilePath = settingsFilePath;
    }


    public NegotiationPointSettings GetDefaultNegotiationPointSettings()
    {
       return new NegotiationPointSettings()
        {
            Defaults = new NegotiationPointDefaults()
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
            },
            Minimums = new NegotiationPointMinimums()
            {
                BasePoints = 5,
                UnitSize = 1,
                DragoonRatingValue = -5,
                DragoonRating = "F",
                EmployerReputation = -9,
                PayRate = 400,
                ContractTime = 1,
                ContractWordGoal = 40000,
                DoubleSalvageWordGoal = 40000,
                EmployerReputationGain = 1,
                OppositionReputationLoss = -5
            },
            Maximums = new NegotiationPointMaximums()
            {
                BasePoints = 5,
                UnitSize = 5,
                DragoonRatingValue = 10,
                DragoonRating = "S+",
                EmployerReputation = 10,
                PayRate = 2100,
                ContractTime = 6,
                ContractWordGoal = 40000,
                DoubleSalvageWordGoal = 100000,
                EmployerReputationGain = 5,
                OppositionReputationLoss = 0
            }
        };
    }
    //public NegotiationPointSettings GetNegotiationPointSettings()
    //{
    //    string json = File.ReadAllText(_settingsFilePath);
    //    return JsonSerializer.Deserialize<NegotiationPointSettings>(json);
    //}

    public NegotiationPointSettings GetNegotiationPointSettings()
    {
        var dataService = new GeneralSettingsService<NegotiationPointSettings>(_settingsFilePath);

        // Get the default NegotiationPoint Settings (which includes NP Defaults, DefaultMinimums, and DefaultMaximums) objects as a backup
        NegotiationPointSettings defaultNegotiationPointSettings = GetDefaultNegotiationPointSettings();


        // Retrieve data from JSON file or generate it if the file doesn't exist
        NegotiationPointSettings negotiationPoints = dataService.GetDataFromDataSource(defaultNegotiationPointSettings);
        return negotiationPoints;

    }
}