using System;

namespace BTMContractDrafter.WPF.Settings.NegotiationPoints;

public interface INegotiationPointDefinition
{
    ushort BasePoints { get; set; }
    ushort UnitSize { get; set; }
    short DragoonRatingValue { get; set; }
    string DragoonRating { get; set; }
    short EmployerReputation { get; set; }
    short OppositionReputation { get; set; }
    short EmployerReputationGain { get; set; }
    short OppositionReputationLoss { get; set; }
    decimal PayRate { get; set; }
    uint ContractWordGoal { get; set; }
    ushort ContractTime { get; set; }
    uint DoubleSalvageWordGoal { get; set; }
}