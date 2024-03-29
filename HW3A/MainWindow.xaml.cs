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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random rand = new Random(DateTime.Now.Millisecond);
        BusLines AllBusLines = new BusLines();
        private BusLine currentDisplayBusLine;

        public MainWindow()
        {
            InitializeComponent();
            GenerateBusLines(5);
            cbBusLines.ItemsSource = AllBusLines.GetBusLines;
            cbBusLines.DisplayMemberPath = "BusLineNum";
            cbBusLines.SelectedIndex = 0;
            ShowBusLine(AllBusLines.BusLinesNums[0]);
        }

        private void ShowBusLine(int index)
        {
            MainGrid.Children.RemoveRange(1, 3);
            //currentDisplayBusLine = AllBusLines.GetBusLines[index];

            //Use the indexer instead of the property GetBusLines
            currentDisplayBusLine = AllBusLines[index];
            UpGrid.DataContext = currentDisplayBusLine;

            for (int i = 0; i < currentDisplayBusLine.Stations.Count; i++)
            {
                StationUserControl s = new StationUserControl(currentDisplayBusLine.Stations[i].BusStation);
                MainGrid.Children.Add(s);
                Grid.SetRow(s, i + 1);
            }
        }



        #region Create Random data

        private  void GenerateBusLines(int anount)
        {
            for (int i = 0; i < anount; i++)
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
            return new BusLine(busLineNum, first, last, area);
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
            //ShowBusLine(cbBusLines.SelectedIndex);

            //Use the indexer instead of the property GetBusLines
            ShowBusLine(AllBusLines.BusLinesNums[cbBusLines.SelectedIndex]);
        }
    }
}
