using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    /// <summary>
    /// Represents a Bus Service entity in the bus lines management system
    /// </summary>
    class BusService
    {
        /// <summary>
        /// Initializes a new instance of Bus Service entity to the specified
        ///  last service date.
        /// </summary>
        /// <param name="lastServiceDate">the last service date</param>
        public BusService(DateTime lastServiceDate)
        {
            this.lastServiceDate = lastServiceDate;
        }


        private DateTime lastServiceDate;
        /// <summary>
        /// Gets and sets the last service date represented by this Bus Service instance
        /// </summary>
        public DateTime LastServiceDate { get => lastServiceDate; set => lastServiceDate = value; }

        /// <summary>
        /// Gets and sets the odometer value represented by this Bus Service instance
        /// </summary>
        private int odometer;
        public int Odometer { get => odometer; set => odometer = value; }
    }
}
