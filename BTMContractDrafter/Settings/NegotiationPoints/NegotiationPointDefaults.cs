using System;

namespace BTMContractDrafter.WPF.Settings.NegotiationPoints;

public class NegotiationPointDefaults : INegotiationPointDefinition
{
    public ushort BasePoints { get; set; }
    public ushort UnitSize { get; set; }
    public short DragoonRatingValue { get; set; }
    public string DragoonRating { get; set; }
    public short EmployerReputation { get; set; }
    public short OppositionReputation { get; set; }
    public short EmployerReputationGain { get; set; }
    public short OppositionReputationLoss { get; set; }
    public decimal PayRate { get; set; }
    public uint ContractWordGoal { get; set; }
    public ushort ContractTime { get; set; }
    public uint DoubleSalvageWordGoal { get; set; }

    public int GetNegotiationPointsAvailable()
    {
        return BasePoints + UnitSize + DragoonRatingValue + EmployerReputation;
    }

}