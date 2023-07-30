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
                new UnitSize
                {
                    Id = 1, Name = "Company", Description = "A company sized formation",
                    MinimumTonnage = 0, MaximumTonnage = 1_500,
                    MinimumBV = 0, MaximumBV = 30_000,
                    MinimumMHCount = 0, MaximumMHCount = 43

                },
                new UnitSize
                {
                    Id = 2, Name = "Battalion", Description = "A battalion sized formation",
                    MinimumTonnage = 1_501, MaximumTonnage = 4_500,
                    MinimumBV = 30_001, MaximumBV = 90_000,
                    MinimumMHCount = 44, MaximumMHCount = 131
                },
                new UnitSize
                {
                    Id = 3, Name = "Regiment", Description = "A regiment sized formation",
                    MinimumTonnage = 4_501, MaximumTonnage = 13_500,
                    MinimumBV = 90_001, MaximumBV = 270_000,
                    MinimumMHCount = 132, MaximumMHCount = 395
                },
                new UnitSize
                {
                    Id = 4, Name = "Brigade", Description = "A brigade or regimental combat team sized formation",
                    MinimumTonnage = 13_501, MaximumTonnage =  40_500,
                    MinimumBV = 270_001, MaximumBV = 810_000,
                    MinimumMHCount = 396, MaximumMHCount = 791
                },
                new UnitSize
                {
                    Id = 5, Name = "Division", Description = "A division sized formation",
                    MinimumTonnage = 40_501, MaximumTonnage =  uint.MaxValue,
                    MinimumBV = 810_001, MaximumBV = uint.MaxValue,
                    MinimumMHCount = 792, MaximumMHCount = uint.MaxValue
                },
                // Add more UnitSizes as needed
            };
        }
    }
}
