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
        static List<Bus> buses = new List<Bus>();
        public MainWindow()
        {
            GenerateBuses(2);
            InitializeComponent();
        }

        private static void GenerateBuses(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                RegNumType regNumType = (RegNumType)rand.Next(7, 9);
                int regNum = getRandomRegNum(regNumType);
                int addition = (-(int)regNumType - 8) * 36;
                DateTime regDate = getRandomDateTime(rand.Next(2,35) + addition);
                DateTime serviceDate = getRandomDateTime(rand.Next(1,10));
                int serviceOdo = rand.Next(20000); 
                buses.Add(new Bus(regNum, regDate, serviceDate, serviceOdo));
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
            // busViewSource.Source = [generic data source]
        }

        private void pbAddBus_Click(object sender, RoutedEventArgs e)
        {
            new BusWindow().Show();
        }
    }
}
