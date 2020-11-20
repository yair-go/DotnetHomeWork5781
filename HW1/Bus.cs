using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    /// <summary>
    /// Represents a bus entity in the bus lines management system
    /// </summary>
    public class Bus
    {
        #region *** private fields ***
        private int registrationNum;
        private DateTime firstRegDate;
        private int trip;
        private int odometer;
        private BusService lastService;
        #endregion

        #region *** constructors ***
        /// <summary>
        /// Initializes a new instance of Bus entity to the specified
        ///  registration number, date of registration, and last service.
        /// </summary>
        /// <param name="regNum">the bus vehicle registration number of 8 or
        /// 9 digits, depending on the registration date</param>
        /// <param name="regDate">the date of the bus vehicle registration</param>
        /// <param name="serviceDate">the date of the bus service</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public Bus(int regNum, DateTime regDate, DateTime serviceDate, int serviceOdo)
        {
            this.registrationNum = regNum;
            this.firstRegDate = regDate;
            this.lastService = new BusService(serviceDate, serviceOdo);
        }
        #endregion

        #region *** properties ***
        /// <summary>
        /// Gets the registration number represented by this Bus instance.
        /// Returns:
        ///    The registration number in approriate format depending on the registration
        ///    date: <br /> if the registration date is before 1/01/2018 -
        ///    the format is ##-###-##, else - the format is ###-##-###
        /// </summary>
        public String RegistrationNum
        {
            get => registrationNum.ToString(
                firstRegDate < new DateTime(2018, 1, 1) ? "00-000-00" : "000-00-000");
        }

        /// <summary>
        /// Gets and sets the registration date represented by this Bus instance
        /// </summary>
        public DateTime FirstRegDate { get => firstRegDate; set => firstRegDate = value; }

        /// <summary>
        /// Gets and sets the trip represented by this Bus instance
        /// </summary>
        public int Trip { get => trip; set => trip = value; }


        /// <summary>
        /// Gets the odometer measurement represented by this Bus instance
        /// </summary>
        public int Odometer { get => odometer; }

        /// <summary>
        /// Gets and sets the last service represented by this Bus instance
        /// </summary>
        public BusService LastService { get => lastService; set => lastService = value; }
        #endregion

        #region *** operations ***
        /// <summary>
        /// Checks whether the registration number represented by the instance
        /// is the same as the specified registration number 
        /// </summary>
        /// <param name="regNum">the registration number for comparison</param>
        /// <returns>true if the registration numbers are the same, elser returns false</returns>
        public bool CheckRegNum(int regNum)
        {
            return this.registrationNum == regNum;
        }

        /// <summary>
        /// Updates the attributes represented by the instance with the specified trip
        /// distance
        /// </summary>
        /// <param name="km">the trip distance in km</param>
        internal void DoRide(int km)
        {
            this.Trip += km;
            this.odometer += km;
        }
        #endregion

        public override string ToString()
        {
            return RegistrationNum;
        }
    }
}
