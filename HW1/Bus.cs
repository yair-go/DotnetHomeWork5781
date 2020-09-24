using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Bus
    {
        private int registrationNum;
        private DateTime firstRegDate;
        private BusService lastService;
        private int odometer;
        private int trip;

       
        public Bus(int regNum, DateTime regDate, DateTime serviceDate)
        {
            this.registrationNum = regNum;
            this.firstRegDate = regDate;
            this.lastService = new BusService(serviceDate);
        }

        public String RegistrationNum { 
            get {
                if (firstRegDate < new DateTime(2018, 1, 1))
                    return registrationNum.ToString("00-000-00");
                else
                    return registrationNum.ToString("000-00-000");
            } }
        public DateTime FirstRegDate { get => firstRegDate; set => firstRegDate = value; }
        public int Trip { get => trip; set => trip = value; }
        public int Odometer { get => odometer;  }
        internal BusService LastService { get => lastService; set => lastService = value; }
        public bool CheckRegNum(int regNum)
        {
            return this.registrationNum == regNum;
        }

        internal void DoRide(int km)
        {
            this.Trip += km;
            this.odometer += km;
        }
    }
}
