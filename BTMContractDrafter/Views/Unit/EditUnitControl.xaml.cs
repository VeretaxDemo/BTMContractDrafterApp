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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BTMContractDrafter.Views.Unit
{
    /// <summary>
    /// Interaction logic for EditUnitControl.xaml
    /// </summary>
    public partial class EditUnitControl : UserControl
    {
        public static readonly DependencyProperty UnitProperty =
            DependencyProperty.Register("Unit", typeof(Models.Unit), typeof(EditUnitControl), new PropertyMetadata(null));

        public Models.Unit Unit
        {
            get { return (Models.Unit)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }


        // Define the dependency property for UnitSizes
        public static readonly DependencyProperty UnitSizesProperty =
            DependencyProperty.Register("UnitSizes", typeof(IEnumerable<string>), typeof(EditUnitControl), new PropertyMetadata(null));

        // Add a public property to get/set the UnitSizes using the dependency property
        public ObservableCollection<string> UnitSizes
        {
            get { return (ObservableCollection<string>)GetValue(UnitSizesProperty); }
            set { SetValue(UnitSizesProperty, value); }
        }

        public EditUnitControl()
        {
            InitializeComponent();

            DataContext = this;
        }
    }
}
