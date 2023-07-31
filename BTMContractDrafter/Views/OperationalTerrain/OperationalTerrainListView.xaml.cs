﻿using System;
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
using System.Windows.Shapes;

namespace BTMContractDrafter.Views.OperationalTerrain
{
    /// <summary>
    /// Interaction logic for OperationalTerrainListView.xaml
    /// </summary>
    public partial class OperationalTerrainListView : Window
    {
        public OperationalTerrainListView()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected OperationalTerrain from the ListBox
            Models.OperationalTerrain selectedOperationalTerrain = lstOperationalTerrain.SelectedItem as Models.OperationalTerrain;

            // If an item is selected, close the dialog and return the selected OperationalTerrain
            if (selectedOperationalTerrain != null)
            {
                DialogResult = true;

                // Create and show the display window for the selected OperationalTerrain
                OperationalTerrainDisplayView displayViewWindow = new OperationalTerrainDisplayView(selectedOperationalTerrain);
                displayViewWindow.DataContext = selectedOperationalTerrain;
                displayViewWindow.Show();

                Close(); // Close the OperationalTerrainListView dialog
            }
            else
            {
                // If nothing is selected, show an error message
                MessageBox.Show("Please select an Operational Terrain.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
