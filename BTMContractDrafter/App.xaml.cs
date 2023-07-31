using BTMContractDrafter.Settings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BTMContractDrafter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private string _unitSizeSettingsFilePath = "UnitSizesSettings.json";
        private string _operationalTerrainSettingsFilePath = "OperationalTerrainsSettings.json";
        private string _terrainTypesSettingsFilePath = "TerrainTypesSettingsDataSource.json";
        // Create a property to hold the data source instance
        public IUnitSizeSettingsDataSource UnitSizeSettingsDataSource { get; private set; }
        public IOperationalTerrainSettingsDataSource OperationalTerrainSettingsDataSource { get; set; }
        public ITerrainTypesSettingsDataSource TerrainTypesSettingsDataSource { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create a new DI container and configure it
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IUnitSizeSettingsDataSource>(provider =>
                    new UnitSizeSettingsDataSource(_unitSizeSettingsFilePath))
                .AddSingleton<IOperationalTerrainSettingsDataSource>(provider =>
                    new OperationalTerrainSettingsDataSource(_operationalTerrainSettingsFilePath))
                .AddSingleton<ITerrainTypesSettingsDataSource>(provider =>
                    new TerrainTypesSettingsDataSource(_terrainTypesSettingsFilePath,
                        ((App)Application.Current).OperationalTerrainSettingsDataSource.GetOperationalTerrain()))
                .BuildServiceProvider();

            //UnitSizeSettingsDataSource = CreateDataSource<UnitSizeSettingsDataSource>(_unitSizeSettingsFilePath);

            //OperationalTerrainSettingsDataSource = CreateDataSource<OperationalTerrainSettingsDataSource>(_operationalTerrainSettingsFilePath);
            //TerrainTypesSettingsDataSource =
            //    CreateDataSource<TerrainTypesSettingsDataSource>(_terrainTypesSettingsFilePath);

            // Get the data sources from the DI container
            UnitSizeSettingsDataSource = serviceProvider.GetRequiredService<IUnitSizeSettingsDataSource>();
            OperationalTerrainSettingsDataSource = serviceProvider.GetRequiredService<IOperationalTerrainSettingsDataSource>();
            TerrainTypesSettingsDataSource = serviceProvider.GetRequiredService<ITerrainTypesSettingsDataSource>();
        }

        // Generic method to create data sources based on the type T
        private T CreateDataSource<T>(string settingsFilePath) where T : class
        {
            Type targetType = typeof(T);

            try
            {
                // Use reflection to create an instance of the target type
                object instance = Activator.CreateInstance(targetType, settingsFilePath);

                // Cast the instance to the desired interface type
                return instance as T;
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur during instance creation
                // You can log the error or show a message box, etc.
                return null;
            }
        }

        public virtual void Exit_Click(object sender, EventArgs e)
        {

        }
    }
}
