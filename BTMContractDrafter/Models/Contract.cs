using System;
using System.Collections.Generic;

namespace BTMContractDrafter.Models;

public class Contract
{
    public Planet Planet = new Planet();
    public Unit Unit = new Unit();
    public OperationalTerrain OperationalTerrain = new OperationalTerrain();
    public Guid Id { get; set; }
    public string RegistryNumber { get; set; } = string.Empty;

    public string ContractType { get; set; } = string.Empty;
    public string ContractDuration { get; set; } = string.Empty;
    public string ContractNegotiable { get; set; } = string.Empty;
    public string Employer { get; set; } = string.Empty;
    public string EmployerContact { get; set; } = string.Empty;
    public string CommandRights { get; set; } = string.Empty;
    public string ForcesRecommended { get; set; } = string.Empty;
    public string LikelyAgainst { get; set; } = string.Empty;
    public string SupportingForces { get; set; } = string.Empty;
    public string EnemyForces { get; set; } = string.Empty;
    public string SupplementalContractType { get; set; } = string.Empty;
    public string EmployerReputationRequired { get; set; } = string.Empty;
    public string EmployerReputationGain { get; set; } = string.Empty;
    public string OpponentReputationLoss { get; set; } = string.Empty;
    public string BountyPerWord { get; set; } = string.Empty;
    public string MinimumBounty { get; set; } = string.Empty;
    public string SalvageCategory { get; set; } = string.Empty;
    public string EmployerSituationReport { get; set; } = string.Empty;
    public List<string> PrimaryObjectives { get; set; } = new List<string>();
    public List<string> SecondaryObjectives { get; set; } = new List<string>();
    public DateTime ContractExpiration { get; set; } = DateTime.Now.AddDays(30);
}