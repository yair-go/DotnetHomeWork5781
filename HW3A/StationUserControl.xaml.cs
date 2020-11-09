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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HW2;

namespace HW3A
{
    /// <summary>
    /// Interaction logic for StationUserControl.xaml
    /// </summary>
    public partial class StationUserControl : UserControl
    {

        public BusStation CurrentbusStation { get; set; }
        public StationUserControl(BusStation busStation)
        {
            InitializeComponent();
            this.CurrentbusStation = busStation;
            StationGridUserControl.DataContext = busStation;
        }
    }
}
