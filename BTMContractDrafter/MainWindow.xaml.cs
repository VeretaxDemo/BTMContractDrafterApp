using BTMContractDrafter.Models;
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

namespace BTMContractDrafter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            // Get the list of available UnitSizes (replace this with your actual data source)
            List<UnitSize> unitSizes = GetUnitSizesFromDataSource();

            // Create and show the dialog to select the UnitSize
            UnitSizeListView dialog = new UnitSizeListView();
            dialog.lstUnitSizes.ItemsSource = unitSizes;

            if (dialog.ShowDialog() == true)
            {
                // Get the selected UnitSize from the dialog
                UnitSize selectedUnitSize = dialog.lstUnitSizes.SelectedItem as UnitSize;

                // Create and show the display window for the selected UnitSize
                UnitSizeDisplay displayWindow = new UnitSizeDisplay();
                displayWindow.DataContext = selectedUnitSize;
                displayWindow.Show();
            }
        }

        // Replace this method with your actual data retrieval logic
        private List<UnitSize> GetUnitSizesFromDataSource()
        {
            // Dummy data for demonstration purposes
            return new List<UnitSize>
            {
                new UnitSize { Id = 1, Name = "Size 1", Description = "Description 1", /* Add other properties */ },
                new UnitSize { Id = 2, Name = "Size 2", Description = "Description 2", /* Add other properties */ },
                // Add more UnitSizes as needed
            };
        }
    }
}
