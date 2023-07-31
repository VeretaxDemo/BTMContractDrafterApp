using System;

namespace BTMContractDrafter.Settings;

public class SettingsDataSources
{
    private string _unitSizeSettingsFilePath = "UnitSizesSettings.json";
    private string _operationalTerrainSettingsFilePath = "OperationalTerrainsSettings.json";
    private string _terrainTypesSettingsFilePath = "TerrainTypesSettingsDataSource.json";
    //private IUnitSizeSettingsDataSource _unitSizeSettingsDataSource;
    //private IOperationalTerrainSettingsDataSource _operationalTerrainSettingsDataSource;

    //public IUnitSizeSettingsDataSource UnitSizeSettingsDataSource
    //{
    //    get => _unitSizeSettingsDataSource;
    //}

    //public IOperationalTerrainSettingsDataSource OperationalTerrainSettingsDataSource
    //{
    //    get => (App)_operationalTerrainSettingsDataSource;
    //}

    //public SettingsDataSources()
    //{
    //    LoadUnitSizeSettings();

    //    LoadOperationalTerrainSettings();
    //}

    //private void LoadOperationalTerrainSettings()
    //{
    //    _operationalTerrainSettingsDataSource =
    //        CreateDataSource<IOperationalTerrainSettingsDataSource>(_operationalTerrainSettingsFilePath);
    //}

    //private void LoadUnitSizeSettings()
    //{
    //    _unitSizeSettingsDataSource = CreateDataSource<IUnitSizeSettingsDataSource>(_unitSizeSettingsFilePath);
    //}

    //// Generic method to create data sources based on the type T
    //private T CreateDataSource<T>(string settingsFilePath) where T : class
    //{
    //    Type targetType = typeof(T);

    //    try
    //    {
    //        // Use reflection to create an instance of the target type
    //        object instance = Activator.CreateInstance(targetType, settingsFilePath);

    //        // Cast the instance to the desired interface type
    //        return instance as T;
    //    }
    //    catch (Exception ex)
    //    {
    //        // Handle any errors that may occur during instance creation
    //        // You can log the error or show a message box, etc.
    //        return null;
    //    }
    //}
}