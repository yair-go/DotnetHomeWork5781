using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class Program
    {
        enum MenuOption { Add, Delete, Search, Show, Exit}

        static BusLines AllBusLines;

        static  Random rand = new Random();
        static MenuOption Menu()
        {
            MenuOption option;
            Console.WriteLine("please choose one of the follow:");
            Console.WriteLine("Add, Delete,Search, Show, Exit");
            Enum.TryParse(Console.ReadLine(), out option);
            return option;
        }
        public static void ChooseBusNumber(out int busNumber)
        {
            Console.WriteLine("-------Enter Bus :---------");
            Console.WriteLine("Enter the Bus Number: ");
            int.TryParse(Console.ReadLine(), out busNumber);
        }

        static void Main(string[] args)
        {
            AllBusLines = new BusLines();
            MenuOption option;
            do
            {
                option = Menu();
                switch (option)
                {
                    case (MenuOption.Add):
                        Console.WriteLine("Add new Bus line (1)/ new Station (2)");
                        int addChoice = Int32.Parse(Console.ReadLine());
                        if (addChoice == 1) AddBusLine();
                        else AddStation();
                        break;
                    case (MenuOption.Delete):
                        break;
                    case (MenuOption.Search):
                        Console.WriteLine("Search Lines in station (1)/ alternative  (2)");
                        int searchChoice = Int32.Parse(Console.ReadLine());
                        SearchLines(searchChoice);
                        break;
                    case (MenuOption.Show):
                        break;
                    case (MenuOption.Exit):
                        break;
                    default:
                        Console.WriteLine("The option you selected is not a valid choice");
                        break;

                }
            } while (option != MenuOption.Exit);

            example();
        }

        private static void SearchLines(int searchChoice)
        {
            if (searchChoice == 1)
            {
                int stationNum = int.Parse(Console.ReadLine());
                foreach (BusLine busLine in AllBusLines )
                {
                    if (busLine.Contain(stationNum))
                    {
                        Console.WriteLine(busLine.BusLineNum);
                    }
                }
            }
            else
            {
                int stationNumA = int.Parse(Console.ReadLine());
                int stationNumB = int.Parse(Console.ReadLine());

            }
        }

        private static void AddStation()
        {
            throw new NotImplementedException();
        }

        private static void AddBusLine()
        {
            BusLine busLine= getRandomBusLine();
            Console.WriteLine(busLine);
            AllBusLines.AddBusLine(busLine);
        }

        #region Create Random data
        private static BusLine getRandomBusLine()
        {
            int busLineNum = rand.Next(100);
            BusStation first = getRandomBusStation();
            BusStation last = getRandomBusStation();
            Area area = (Area) rand.Next(Enum.GetNames(typeof(Area)).Length);
            return new BusLine(busLineNum, first, last, area);
        }

        private static BusStation getRandomBusStation()
        {
            int stationCode = rand.Next(100000, 200000);
            Double latitude = rand.Next(31,33) + rand.NextDouble();
            Double longitude = rand.Next(34, 35) + rand.NextDouble();
            return new BusStation(stationCode, latitude, longitude);
        }

        private static void example()
        {
            BusStation busStation1 = new BusStation(123456, 31.766101, 35.192826);
            BusStation busStation2 = new BusStation(123457, 31.767201, 35.192826);

            AllBusLines.AddBusLine(new BusLine(39, busStation1, busStation2, Area.Jerusalem));

            Console.WriteLine(busStation1.Distance(busStation2));
        }

        #endregion

    }
}
