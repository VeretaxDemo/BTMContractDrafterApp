using BTMContractDrafter.Models;
using BTMContractDrafter.Settings;
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

namespace BTMContractDrafter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UnitSizeSettings _unitSizeSettings = new UnitSizeSettings();
        private OperationalTerrainSettings _operationalTerrainSettings = new OperationalTerrainSettings();
        public MainWindow()
        {
            InitializeComponent();
        }


        // Click event handler for the "Exit" menu item
        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_UnitSizes_Click(object sender, RoutedEventArgs e)
        {
            // Get the list of available UnitSizes
            List<UnitSize> unitSizes = _unitSizeSettings.GetUnitSizesFromDataSource();

            // Create and show the dialog to select the UnitSize
            UnitSizeListView dialog = new UnitSizeListView();
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
                _operationalTerrainSettings.GetOperationalTerrainFromDataSource();

            // Create and show the dialog to select the OperatoinalTerrain
            OperationalTerrainListView dialog = new OperationalTerrainListView();
            dialog.lstOperationalTerrain.ItemsSource = operationalTerrains;

            if (dialog.ShowDialog() == true)
            {
                // Do Nothing Let dialog handle its spin up
                this.Activate();
            }
        }
    }
}
