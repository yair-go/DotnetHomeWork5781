using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HW2;

namespace HW1
{
    public delegate void RefuelingCompletedEventHandler();

    /// <summary>
    /// Represents a bus entity in the bus lines management system
    /// </summary>
    public class Bus : INotifyPropertyChanged
    {
        #region *** private fields ***
        private int registrationNum;
        private DateTime firstRegDate;
        private int trip;
        private int odometer;
        private BusService lastService;
        private BusStatus busStatus;
        private static readonly int fullFuel = 1200;
        #endregion  

        #region Events
        private BackgroundWorker refuelWorker;

        public event RefuelingCompletedEventHandler RefuelingCompleted = null;
        public event PropertyChangedEventHandler PropertyChanged;
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
        public Bus(int regNum = 1, DateTime regDate = default(DateTime), DateTime serviceDate = default(DateTime), int serviceOdo = 0, int odometer = 0)
        {
            this.registrationNum = regNum;
            this.firstRegDate = regDate;
            this.lastService = new BusService(serviceDate, serviceOdo);
            this.odometer = odometer;
            this.trip = fullFuel;
            this.BusStatus = BusStatus.Ready;
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
        public int Trip 
        { 
            get => trip;
            set
            {
                trip = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Trip"));
                }
            }
        }


        /// <summary>
        /// Gets the odometer measurement represented by this Bus instance
        /// </summary>
        public int Odometer { get => odometer; }

        /// <summary>
        /// Gets and sets the last service represented by this Bus instance
        /// </summary>
        public BusService LastService { get => lastService; set => lastService = value; }
        /// <summary>
        ///  Gets and sets the Bus Status represented by this Bus instance
        /// </summary>
        public BusStatus BusStatus
        {
            get => busStatus;
            set
            { 
                busStatus = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BusStatus")); 
                }
            }
        }
        public BackgroundWorker RefuelWorker { get => refuelWorker; }
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

        public BackgroundWorker Refueling()
        {
            refuelWorker = new BackgroundWorker();
            refuelWorker.DoWork += RefuelWorker_DoWork;
            refuelWorker.RunWorkerCompleted += RefuelWorker_RunWorkerCompleted;
            refuelWorker.ProgressChanged += RefuelWorker_ProgressChanged;
            refuelWorker.WorkerReportsProgress = true;
            refuelWorker.RunWorkerAsync();
            return refuelWorker;
        }

        private void RefuelWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Trip += e.ProgressPercentage;
        }

        public void RefuelingWithEvevt()
        {
            this.busStatus = BusStatus.OnRefueling;
            new Thread(
                () =>
                {
                    Thread.Sleep(4000); // From students required 12000
                    handleRefuelingCompleted();
                }
            ).Start();
        }

        private void handleRefuelingCompleted()
        {
            this.busStatus = BusStatus.Ready;
            if (RefuelingCompleted != null)
            {
                RefuelingCompleted();
            }
        }

        private void RefuelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           // this.trip = fullFuel;
            this.BusStatus = BusStatus.Ready;
        }

        private void RefuelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.busStatus = BusStatus.OnRefueling;
            e.Result = this;
            int lack = fullFuel - trip;
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(600);
                refuelWorker.ReportProgress(lack / 10);
            }
            //Thread.Sleep(6000); // From students required 12000
        }

        /// <summary>
        /// Updates the attributes represented by the instance with the specified trip
        /// distance
        /// </summary>
        /// <param name="km">the trip distance in km</param>
        public void DoRide(int km)
        {
            this.trip -= km;
            this.odometer += km;
        }
        #endregion

        public override string ToString()
        {
            return RegistrationNum;
        }
    }
}
