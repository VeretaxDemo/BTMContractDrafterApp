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
    /// Interaction logic for DisplayUnitSizeView.xaml
    /// </summary>
    public partial class DisplayUnitSizeView : Window
    {
        private Models.UnitSize _unitSize;
        public DisplayUnitSizeView(Models.UnitSize unitSize)
        {
            InitializeComponent();
            _unitSize = unitSize;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
