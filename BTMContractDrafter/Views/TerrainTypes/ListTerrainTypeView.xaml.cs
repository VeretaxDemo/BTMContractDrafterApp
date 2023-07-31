using BTMContractDrafter.Views.OperationalTerrain;
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
using System.Windows.Shapes;

namespace BTMContractDrafter.Views.TerrainTypes
{
    /// <summary>
    /// Interaction logic for ListTerrainTypeView.xaml
    /// </summary>
    public partial class ListTerrainTypeView : Window
    {
        public ListTerrainTypeView()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected OperationalTerrain from the ListBox
            Models.TerrainType selectedTerrainType = lstTerrainTypes.SelectedItem as Models.TerrainType;

            // If an item is selected, close the dialog and return the selected OperationalTerrain
            if (selectedTerrainType != null)
            {
                DialogResult = true;

                // Create and show the display window for the selected OperationalTerrain
                DisplayTerrainTypeView viewWindow = new DisplayTerrainTypeView(selectedTerrainType);
                viewWindow.DataContext = selectedTerrainType;
                viewWindow.Show();

                Close();
            }
            else
            {
                // If nothing is selected, show an error message
                MessageBox.Show("Please select an Terrain Type.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
