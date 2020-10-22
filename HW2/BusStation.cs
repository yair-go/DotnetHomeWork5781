using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class BusStation
    {
        #region *** private fields ***

        private int stationCode;
        private Double latitude;
        private Double longitude;
        #endregion

        #region *** constructors ***
        public BusStation(int stationCode, Double latitude, Double longitude)
        {
            this.stationCode = stationCode;
            this.latitude = latitude;
            this.longitude = longitude;
        }


        #endregion

        #region *** properties ***
        public int StationCode { get => stationCode;  }
        public Double Latitude { get => latitude;  }
        public Double Longitude { get => longitude; }

        #endregion

        public override string ToString()
        {
            return $"Bus Station Code: {stationCode} {latitude}N {longitude}E";
        }

    }
}
