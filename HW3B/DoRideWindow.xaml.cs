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
using HW1;

namespace HW3B
{
    /// <summary>
    /// Interaction logic for DoRideWindow.xaml
    /// </summary>
    public partial class DoRideWindow : Window
    {
        Bus currentBus;
        public DoRideWindow(Bus bus)
        {
            currentBus = bus;
            this.DataContext = currentBus;
            InitializeComponent();
        }

        private void pbDone_Click(object sender, RoutedEventArgs e)
        {
            if (tbRide.Text != "0")
            {
                currentBus.DoRide(int.Parse(tbRide.Text));
                this.Close();
            }
            
        }

    }
}
