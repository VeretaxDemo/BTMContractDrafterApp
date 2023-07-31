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
using BTMContractDrafter.Models;

namespace BTMContractDrafter.Views.UnitSize
{
    /// <summary>
    /// Interaction logic for ListUnitSizeView.xaml
    /// </summary>
    public partial class ListUnitSizeView : Window
    {
        public ListUnitSizeView()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected UnitSize from the ListBox
            Models.UnitSize selectedUnitSize = lstUnitSizes.SelectedItem as Models.UnitSize;

            // If an item is selected, close the dialog and return the selected UnitSize
            if (selectedUnitSize != null)
            {
                DialogResult = true;

                DisplayUnitSizeView viewWindow = new DisplayUnitSizeView(selectedUnitSize);
                viewWindow.DataContext = selectedUnitSize;
                viewWindow.Show();

                Close(); // Close the ListUnitSizeView dialog
            }
            else
            {
                // If nothing is selected, show an error message
                MessageBox.Show("Please select a Unit Size.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.Activate();
        }
    }
}
