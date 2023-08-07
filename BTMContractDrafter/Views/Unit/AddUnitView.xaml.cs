using System.Collections.ObjectModel;
using System.Windows;
using BTMContractDrafter.Library.Data;
using BTMContractDrafter.Library.Extensions;
using BTMContractDrafter.ViewModels;

namespace BTMContractDrafter.WPF.Views.Unit
{
    /// <summary>
    /// Interaction logic for AddUnitView.xaml
    /// </summary>
    public partial class AddUnitView : Window
    {
        public ObservableCollection<BTMContractDrafter.Models.UnitSize> UnitSizes { get; set; }

        public AddUnitView(ObservableCollection<BTMContractDrafter.Models.UnitSize> unitSizes)
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
            var size = cmbUnitSize.SelectedItem as BTMContractDrafter.Models.UnitSize;
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
