using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    enum AddEdit { Add, Edit}
    /// <summary>
    /// Interaction logic for BusWindow.xaml
    /// </summary>
    public partial class BusWindow : Window
    {
        Bus currentBus;
        AddEdit addEdit;

        public Bus CurrentBus { get => currentBus;  }

        public BusWindow(Bus bus = null)
        {
            InitializeComponent();
            if (bus != null)
            {
                currentBus = bus;
                busGrid.DataContext = currentBus;
                addEdit = AddEdit.Edit;
            }
            else
            {
                addEdit = AddEdit.Add;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

          //  System.Windows.Data.CollectionViewSource busViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            this.DataContext = CurrentBus;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (addEdit == AddEdit.Add)
            {
                currentBus = new Bus(int.Parse(registrationNumTextBox.Text), firstRegDateDatePicker.DisplayDate);
            }
        }

        private void pbRefuel_Click(object sender, RoutedEventArgs e)
        {
            currentBus.Refueling();
        }
    }
}
