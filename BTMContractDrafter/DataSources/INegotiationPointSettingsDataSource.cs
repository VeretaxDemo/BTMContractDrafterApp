using BTMContractDrafter.WPF.Settings.NegotiationPoints;

namespace BTMContractDrafter.WPF.DataSources;

public interface INegotiationPointSettingsDataSource
{
    NegotiationPointSettings GetNegotiationPointSettings();
}