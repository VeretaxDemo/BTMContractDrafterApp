using BTMContractDrafter.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using BTMContractDrafter.Library.Data;
using BTMContractDrafter.Library.Extensions;
using BTMContractDrafter.Library.Managers;
using BTMContractDrafter.ViewModels;
using BTMContractDrafter.Models;

namespace BTMContractDrafter.Views.Unit
{
    /// <summary>
    /// Interaction logic for AddUnitView.xaml
    /// </summary>
    public partial class AddUnitView : Window
    {
        public ObservableCollection<Models.UnitSize> UnitSizes { get; set; }

        public AddUnitView(ObservableCollection<Models.UnitSize> unitSizes)
        {
            // Convert the list of UnitSize objects to a list of strings
            UnitSizes = unitSizes;

            // Set the DataContext to the view model or this code-behind
            DataContext = new AddUnitViewModel(unitSizes); // Pass the unitSizes collection as a constructor argument

            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Get the Unit data from the ViewModel or controls (replace UnitData with your actual data model)
            var size = cmbUnitSize.SelectedItem as Models.UnitSize;
            UnitData unitData = new UnitData
            {
                UnitSizeId = size.Id,
                UnitSizeName = cmbUnitSize.Text,
                UnitName = txtUnitName.Text,
                DragoonRating = txtDragoonRating.Text,
                EmployerFactionReputation = txtEmployerFactionReputation.Text,
                OppositionFactionReputation = txtOppositionFactionReputation.Text
            };

            // Serialize the UnitData object and save the data
            unitData.SaveAllFormats();

            this.Close();
        }
    }
}
