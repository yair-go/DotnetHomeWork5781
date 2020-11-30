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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HW1;
using HW2;


namespace HW3B
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random rand = new Random(DateTime.Now.Millisecond);
        static  BindingList<Bus> buses = new BindingList<Bus>();
        public MainWindow()
        {
            InitializeComponent();
            GenerateBuses(10);
            busListView.DataContext = buses;
        }         

        private static void GenerateBuses(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                RegNumType regNumType = (RegNumType)rand.Next(7, 9);
                int regNum = getRandomRegNum(regNumType);
                int addition = ((int)regNumType - 8) * 36;
                DateTime regDate = getRandomDateTime(rand.Next(2,35) - addition);
                DateTime serviceDate = getRandomDateTime(rand.Next(1,13));
                int odo = rand.Next(10000, 20000) + (rand.Next(19700, 20000) * rand.Next(1, DateTime.Now.Year - regDate.Year + 1));
                int serviceOdo = odo - (DateTime.Now - serviceDate).Days * 90;
                buses.Add(new Bus(regNum, regDate, serviceDate, serviceOdo, odo));
            }
        }

        private static DateTime getRandomDateTime(int monthBefore)
        {
            return DateTime.Now.AddMonths(-monthBefore).AddDays(-rand.Next(1, 30));
        }

        private static int getRandomRegNum(RegNumType length)
        {
            int a = rand.Next(23, 60);
            int b = rand.Next(110, 800);
            int c = (length == RegNumType.Old) ? rand.Next(10, 99) : rand.Next(100, 800);
            int d = (length == RegNumType.Old) ? 100 : 1000;
            return ((a * 1000 + b) * d) + c; ;
           // return int.Parse(a.ToString() + b.ToString() + c.ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource busViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
          //  busViewSource.Source = buses;
        }

        private void pbAddBus_Click(object sender, RoutedEventArgs e)
        {
            BusWindow busWindow =  new BusWindow();
            busWindow.Closed += AddBusWindow_Closed;
            busWindow.Show();

        }

        private void AddBusWindow_Closed(object sender, EventArgs e)
        {
            Bus resultBus =  (sender as BusWindow).CurrentBus;
            buses.Add(resultBus);
        }

        private void DoRide(object sender, RoutedEventArgs e)
        {
            Bus bus = ((sender as Button).DataContext as Bus);
            if (NotReady(bus))
            {
                MessageBox.Show("Not Ready");
            }
            else
            {
                DoRideWindow doRideWindow = new DoRideWindow(bus);
                doRideWindow.Closed += Refresh_busViewSource;
                doRideWindow.Show();
            }
        }

        /// <summary>
        /// Checking if a bus can make the ride 
        /// </summary>
        /// <param name="bus"></param>
        /// <returns></returns>
        private static bool NotReady(Bus bus)
        {
            if (bus.BusStatus != BusStatus.Ready)
            {
                return true;
            }
            return false;
        }

        private void Refresh_busViewSource(object sender, EventArgs e)
        {
            if (sender is BusWindow)
            {
                BackgroundWorker refuelWorker = (sender as BusWindow).CurrentBus.RefuelWorker;
                if (refuelWorker != null && refuelWorker.IsBusy)
                {
                    refuelWorker.RunWorkerCompleted += RefuelWorker_RunWorkerCompleted;
                }
            }
            busListView.Items.Refresh();
        }

        private void busListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Bus bus =  (sender as ListView).SelectedItem as Bus;
            BusWindow busWindow = new BusWindow(bus);
            busWindow.Closed += Refresh_busViewSource;
            busWindow.Show();
        }

        private void Refuel(object sender, RoutedEventArgs e)
        {
            Bus bus = ((sender as Button).DataContext as Bus);
            BackgroundWorker refuelWorker = bus.Refueling();
            busListView.Items.Refresh();
            refuelWorker.RunWorkerCompleted += RefuelWorker_RunWorkerCompleted;

            //bus.RefuelingWithEvevt();
            //bus.RefuelingCompleted += Bus_RefuelingCompleted;
        }

        private void Bus_RefuelingCompleted()
        {
            MessageBox.Show("Refueling is over");
           // busListView.Items.Refresh();
        }

        private void RefuelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Refueling is over");
            busListView.Items.Refresh();
        }
    }
}
