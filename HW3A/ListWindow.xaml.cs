using HW2;
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

namespace HW3A
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        static Random rand = new Random(DateTime.Now.Millisecond);
        BusLines AllBusLines = new BusLines();
        private BusLine currentDisplayBusLine;

        public ListWindow()
        {
            InitializeComponent();
            GenerateBusLines(10);
            cbBusLines.ItemsSource = AllBusLines;
            cbBusLines.DisplayMemberPath = "BusLineNum";
            cbBusLines.SelectedIndex = 0;
            ShowBusLine(AllBusLines.BusLinesNums[0]);
        }

        private void ShowBusLine(int index)
        {
           
            //Use the indexer instead of the property GetBusLines
            currentDisplayBusLine = AllBusLines[index];
            UpGrid.DataContext = currentDisplayBusLine;

            lbBusLineStations.DataContext = currentDisplayBusLine.Stations;
           
        }

        #region Create Random data

        private void GenerateBusLines(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                BusLine busLine = getRandomBusLine();
                AllBusLines.AddBusLine(busLine);
            }

        }
        private static BusLine getRandomBusLine()
        {
            int busLineNum = rand.Next(100);
            BusStation first = getRandomBusStation();
            BusStation last = getRandomBusStation();
            Area area = (Area)rand.Next(Enum.GetNames(typeof(Area)).Length);
            BusLine busLine = new BusLine(busLineNum, first, last, area);
            int rndStationCount = rand.Next(3,10);
            for (int i = 1; i < rndStationCount; i++)
            {
                int minute = rand.Next(5, 20);
                busLine.InsertStation(getRandomBusStation(), i, 0, minute);
            }
            return busLine;
        }

        private static BusStation getRandomBusStation()
        {
            int stationCode = rand.Next(100000, 200000);
            Double latitude = rand.Next(31, 33) + rand.NextDouble();
            Double longitude = rand.Next(34, 35) + rand.NextDouble();
            return new BusStation(stationCode, latitude, longitude);
        }


        #endregion

        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ShowBusLine(AllBusLines.BusLinesNums[cbBusLines.SelectedIndex]);
            ShowBusLine((cbBusLines.SelectedValue as BusLine).BusLineNum);
        }
    }
}
