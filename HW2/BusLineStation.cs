using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class BusLineStation
    {
        private BusStation busStation;
        private int distanceFromPrevStation;
        private TimeSpan timeFromPrevStation;

        public BusLineStation(BusStation busStation, int distanceFromPrevStation = 0, TimeSpan timeFromPrevStation = default(TimeSpan))
        {
            this.busStation = busStation;
            this.DistanceFromPrevStation = distanceFromPrevStation;
            this.TimeFromPrevStation = timeFromPrevStation;
        }

        public int BusStaionCode
        {
            get
            {
                return BusStation.StationCode;
            }
        }

        public int DistanceFromPrevStation { get => distanceFromPrevStation; set => distanceFromPrevStation = value; }
        public TimeSpan TimeFromPrevStation { get => timeFromPrevStation; set => timeFromPrevStation = value; }
        public BusStation BusStation { get => busStation; }
    }
}
