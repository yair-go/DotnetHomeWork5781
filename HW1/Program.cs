using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    /// <summary>
    /// Represents main module for testing the bus lines management system
    /// </summary>
    class Program
    {
        private static Random r = new Random(DateTime.Now.Millisecond);

        #region *** private helper functions ***
        /// <summary>
        /// Searches for a bus entity in the fleet (list of bus entities) by 
        /// registration number
        /// </summary>
        /// <param name="FleetList">the list of buses in the fleet</param>
        /// <param name="regNum">the registration number we are looking for</param>
        /// <returns>The bus entity index if it was found, else returns -1</returns>
        private static int FindRegNum(List<Bus> FleetList, int regNum)
        {
            for (int i = 0; i < FleetList.Count; i++)
                if (FleetList[i].CheckRegNum(regNum))
                    return i;

            return -1;
        }

        /// <summary>
        /// Shows UI menu on the console
        /// </summary>
        /// <returns>the option that was chosen by the user</returns>
        private static string ShowMenu()
        {
            string choice;
            Console.WriteLine("Menu:");
            Console.WriteLine("a: Insert new bus.");
            Console.WriteLine("b: Do ride.");
            Console.WriteLine("c: Do Service.");
            Console.WriteLine("d: Show Traveled.");
            Console.WriteLine("e: Exit");
            choice = Console.ReadLine();
            return choice;
        }
        #endregion

        /// <summary>
        /// Represents the main program function, where the tests are called from
        /// </summary>
        /// <param name="args">the command line arguments</param>
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
                    case "a": // add a bus
                        Console.WriteLine("Insert new bus, Registration Number, Date of registration(DD/MM/YYYY) : ");
                        Boolean s = int.TryParse(Console.ReadLine(), out regNum);
                        //regNum = int.Parse(Console.ReadLine());
                        DateTime regDate = DateTime.Parse((Console.ReadLine()));
                        FleetList.Add(new Bus(regNum, regDate, DateTime.Now, 0));
                        break;

                    case "b": // find a bus and send it to a trip
                        regNum = int.Parse(Console.ReadLine());
                        int i = FindRegNum(FleetList, regNum);
                        if (i != -1)
                        {
                            int km = r.Next(10, 200);
                            FleetList[i].DoRide(km);
                        }
                        else
                            Console.WriteLine("The bus does not exist!");
                        break;

                    case "c": // TODO
                        break;

                    case "d": // Print all the buses with their odometer measurements
                        foreach (var bus in FleetList)
                            Console.WriteLine(bus.RegistrationNum + "  " + bus.Odometer);
                        break;

                    case "e": // end running the program
                        break;

                    default:
                        Console.WriteLine("The value you selected is not a valid choice");
                        break;
                }
            } while (choice != "e");
        }
    }
}
