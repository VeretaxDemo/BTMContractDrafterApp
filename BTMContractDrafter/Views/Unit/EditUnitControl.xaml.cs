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

namespace BTMContractDrafter.Views.Unit
{
    /// <summary>
    /// Interaction logic for EditUnitControl.xaml
    /// </summary>
    public partial class UnitEditorControl : UserControl
    {
        public List<Models.UnitSize> UnitSizes { get; set; }

        // Dependency property for Unit property
        public static readonly DependencyProperty UnitProperty =
            DependencyProperty.Register("Unit", typeof(Models.Unit), typeof(UnitEditorControl), new PropertyMetadata(null));

        public Models.Unit Unit
        {
            get { return (Models.Unit)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }

        public UnitEditorControl()
        {
            InitializeComponent();

            DataContext = this;
        }
    }
}
