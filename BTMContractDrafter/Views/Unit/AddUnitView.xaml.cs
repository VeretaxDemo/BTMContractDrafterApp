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
using BTMContractDrafter.ViewModels;

namespace BTMContractDrafter.Views.Unit
{
    /// <summary>
    /// Interaction logic for AddUnitView.xaml
    /// </summary>
    public partial class AddUnitView : Window
    {
        public ObservableCollection<string> UnitSizes { get; set; }

        public AddUnitView(ObservableCollection<string> unitSizes)
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
    }
}
