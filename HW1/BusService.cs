using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class BusService
    {
        private DateTime lastServiceDate;

        public BusService(DateTime lastServiceDate)
        {
            this.lastServiceDate = lastServiceDate;
        }

        private int odometer;

        public DateTime LastServiceDate { get => lastServiceDate; set => lastServiceDate = value; }
        public int Odometer { get => odometer; set => odometer = value; }
    }
}
