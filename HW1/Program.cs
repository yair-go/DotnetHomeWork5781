using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Program
    {
        static Random r = new Random(DateTime.Now.Millisecond);
        static void Main(string[] args)
        {

            List<Bus> FleetList = new List<Bus>();
            string choice;
            do
            {
                Console.WriteLine("menu :");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "a":
                        Console.WriteLine("Insert new bus : ");
                        int regNum = int.Parse(Console.ReadLine());
                        DateTime regDate = DateTime.Parse((Console.ReadLine()));
                        FleetList.Add(new Bus(regNum, regDate));
                        break;
                    case "b":

                        break;
                    case "c":

                        break;
                    case "d":
                        foreach (var bus in FleetList)
                        {
                            Console.WriteLine(bus.RegistrationNum + "  " + bus.Odometer);
                        }
                        break;
                    case "e":
                        break;
                    default:
                        break;
                }


            } while (choice != "e");
        }
    }
}
