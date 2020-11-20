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
    public class BusService
    {
        #region *** private fields ***
        private DateTime lastServiceDate;
        private int odometer;
        #endregion

        #region *** constructors ***
        /// <summary>
        /// Initializes a new instance of Bus Service entity to the specified
        ///  last service date.
        /// </summary>
        /// <param name="lastServiceDate">the last service date</param>
        public BusService(DateTime lastServiceDate, int odometer)
        {
            this.lastServiceDate = lastServiceDate;
            this.odometer = odometer;
        }
        #endregion

        #region *** public properties ***
        /// <summary>
        /// Gets and sets the last service date represented by this Bus Service instance
        /// </summary>
        public DateTime LastServiceDate { get => lastServiceDate; set => lastServiceDate = value; }

        /// <summary>
        /// Gets and sets the odometer value represented by this Bus Service instance
        /// </summary>
        public int Odometer { get => odometer; set => odometer = value; }
        #endregion
    }
}
