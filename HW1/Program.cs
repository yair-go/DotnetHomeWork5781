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

        private static int FindRegNum(List<Bus> FleetList, int regNum)
        {
            for (int i = 0; i < FleetList.Count; i++)
            {
                if (FleetList[i].CheckRegNum(regNum))
                {
                    return i;
                }
            }
            return -1;
        }
        private static string ShowMenu()
        {
            string choice;
            Console.WriteLine("menu :");
            Console.WriteLine("a : Insert new bus.");
            Console.WriteLine("b : Do ride.");
            Console.WriteLine("c : Do Service.");
            Console.WriteLine("d : Show Traveled.");
            Console.WriteLine("e: Exit");
            choice = Console.ReadLine();
            return choice;
        }
        static void Main(string[] args)
        {

            List<Bus> FleetList = new List<Bus>();
            string choice;
            int regNum;
            do
            {
                choice = ShowMenu();
                switch (choice)
                {
                    case "a":
                        Console.WriteLine("Insert new bus, Registration Number, Date of registration(DD/MM/YYYY) : ");
                        regNum = int.Parse(Console.ReadLine());
                        DateTime regDate = DateTime.Parse((Console.ReadLine()));
                        FleetList.Add(new Bus(regNum, regDate, DateTime.Now));
                        break;
                    case "b":
                        regNum = int.Parse(Console.ReadLine());
                        int i = FindRegNum(FleetList, regNum);
                        if (i != -1)
                        {
                            int km = r.Next(10, 200);
                            FleetList[i].DoRide(km);
                        }
                        else
                        {
                            Console.WriteLine("The bus does not exist!");
                        }
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
                        Console.WriteLine("The value you selected is not a valid choice");
                        break;
                }
            } while (choice != "e");
        }
    }
}
