﻿using System;
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

namespace BTMContractDrafter.Views.OperationalTerrain
{
    /// <summary>
    /// Interaction logic for OperationalTerrainDisplayView.xaml
    /// </summary>
    public partial class OperationalTerrainDisplayView : Window
    {

        private Models.OperationalTerrain _operationalTerrain;
        public OperationalTerrainDisplayView(Models.OperationalTerrain selectedOperationalTerrain)
        {
            InitializeComponent();
            _operationalTerrain = selectedOperationalTerrain;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
