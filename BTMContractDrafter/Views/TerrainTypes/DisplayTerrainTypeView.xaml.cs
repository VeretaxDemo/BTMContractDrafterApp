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
    /// Interaction logic for DisplayTerrainTypeView.xaml
    /// </summary>
    public partial class TerrainTypeDisplayView : Window
    {
        public Models.TerrainType _terrainType { get; set; }
        public TerrainTypeDisplayView(Models.TerrainType selectedTerrainType)
        {
            InitializeComponent();
            _terrainType = selectedTerrainType;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
