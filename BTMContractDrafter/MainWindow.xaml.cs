﻿using BTMContractDrafter.Models;
using BTMContractDrafter.Views.UnitSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BTMContractDrafter.Views.OperationalTerrain;
using BTMContractDrafter.Views.TerrainTypes;
using BTMContractDrafter.Views.Unit;
using System.Collections.ObjectModel;
using BTMContractDrafter.WPF.DataSources;
using BTMContractDrafter.WPF.Views.Unit;

namespace BTMContractDrafter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IOperationalTerrainSettingsDataSource OperationalTerrainSettingsDataSource { get; private set; }
        public ITerrainTypesSettingsDataSource TerrainTypesSettingsDataSource { get; private set; }
        public IUnitSizeSettingsDataSource UnitSizeSettingsDataSource { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(IOperationalTerrainSettingsDataSource operationalTerrainSettingsDataSource,
            ITerrainTypesSettingsDataSource terrainTypesSettingsDataSource, IUnitSizeSettingsDataSource unitSizeSettingsDataSource)
        {
            InitializeComponent();

            OperationalTerrainSettingsDataSource = operationalTerrainSettingsDataSource;
            TerrainTypesSettingsDataSource = terrainTypesSettingsDataSource;
            UnitSizeSettingsDataSource = unitSizeSettingsDataSource;
        }


        // Click event handler for the "Exit" menu item
        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_UnitSizes_Click(object sender, RoutedEventArgs e)
        {
            // Get the list of available UnitSizes
            List<UnitSize> unitSizes = ((App)Application.Current).UnitSizeSettingsDataSource.GetUnitSizes();

            // Create and show the dialog to select the UnitSize
            ListUnitSizeView dialog = new ListUnitSizeView();
            dialog.lstUnitSizes.ItemsSource = unitSizes;

            if (dialog.ShowDialog() == true)
            {
                // Do Nothing Let dialog handle its spin up
                this.Activate();
            }
        }

        private void MenuItem_OperationalTerrains_Click(object sender, RoutedEventArgs e)
        {
            // Get the list of available OperationalTerrains
            List<OperationalTerrain> operationalTerrains =
                ((App)Application.Current).OperationalTerrainSettingsDataSource.GetOperationalTerrain();

            // Create and show the dialog to select the OperationalTerrain
            ListOperationalTerrainView dialog = new ListOperationalTerrainView();
            dialog.lstOperationalTerrain.ItemsSource = operationalTerrains;

            if (dialog.ShowDialog() == true)
            {
                // Do Nothing Let dialog handle its spin up
                this.Activate();
            }
        }

        private void MenuItem_TerrainTypes_Click(object sender, RoutedEventArgs e)
        {
            // Get the list of available TerrainTypes
            List<TerrainType> terrainTypes =
                ((App)Application.Current).TerrainTypesSettingsDataSource.GetTerrainTypes();

            // Create and show the dialog to select the TerrainType
            ListTerrainTypeView dialog = new ListTerrainTypeView();
            dialog.lstTerrainTypes.ItemsSource = terrainTypes;

            if (dialog.ShowDialog() == true)
            {
                // Do Nothing Let dialog handle its spin up
                this.Activate();
            }
        }

        private void MenuItem_AddUnit_Click(object sender, RoutedEventArgs e)
        {
            // Load UnitSize objects from the data source
            var unitSizeList = ((App)Application.Current).UnitSizeSettingsDataSource.GetUnitSizes();

            // Convert the list of UnitSize objects to a list of their names (strings)
            var unitSizeObservableCollection = new ObservableCollection<UnitSize>(unitSizeList);


            // Open the AddUnitView window and pass the unitSizeNames collection to it
            var addUnitView = new AddUnitView(unitSizeObservableCollection);
            addUnitView.ShowDialog();
        }
    }
}
