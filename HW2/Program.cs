using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            BusStation busStation = new BusStation(123456, 31.766101, 35.192826);

            Console.WriteLine(busStation);
        }
    }
}
