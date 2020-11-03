using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class Program
    {
        enum MenuOption { Add, Delete, Search, Show}

        static BusLines AllBusLines;

        static void Main(string[] args)
        {
            AllBusLines = new BusLines();

            BusStation busStation1 = new BusStation(123456, 31.766101, 35.192826);
            BusStation busStation2 = new BusStation(123457, 31.767201, 35.192826);

            AllBusLines.AddBusLine(new BusLine(39, busStation1, busStation2,Area.Jerusalem));

            Console.WriteLine(busStation1.Distance(busStation2));
        }
    }
}
