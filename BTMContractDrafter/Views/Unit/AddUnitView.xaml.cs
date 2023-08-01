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
using BTMContractDrafter.ViewModels;

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
            // Get the UnitSizeSettingsDataSource from the App instance
            //var app = (App)Application.Current;
            //var unitSizeSettingsDataSource = app.UnitSizeSettingsDataSource;

            // Load UnitSizes from the data source
            //var unitSizesList = unitSizeSettingsDataSource.GetUnitSizes();

            // Convert the list of UnitSize objects to a list of strings
            //var unitSizes = new ObservableCollection<string>(unitSizesList.Select(unitSize => unitSize.Name));
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
            UnitData unitData = new UnitData
            {
                UnitSizeId = (int)cmbUnitSize.SelectedValue,
                UnitSizeName = cmbUnitSize.Text,
                UnitName = txtUnitName.Text,
                DragoonRating = txtDragoonRating.Text,
                EmployerFactionReputation = txtEmployerFactionReputation.Text,
                OppositionFactionReputation = txtOppositionFactionReputation.Text
            };

            // Perform actions to save the data (e.g., write to a file, send to a server, etc.)
            // ...

            // Serialize the UnitData object and save the data
            string jsonData = unitData.SerializeToJson();
            string csvData = unitData.SerializeToCsv();
            string plainTextData = unitData.SerializeToPlainText();
        }
    }
}
