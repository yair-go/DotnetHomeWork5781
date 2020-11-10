using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class BusStation
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
        /// <summary>
        /// 
        /// </summary>
        public int StationCode { get => stationCode;  }
        public Double Latitude { get => latitude;  }
        public Double Longitude { get => longitude; }

        #endregion

        public Double Distance(BusStation other)
        {
            int R = 6371 * 1000; // metres
            Double phi1 = this.latitude * Math.PI / 180; // φ, λ in radians
            Double phi2 = other.latitude * Math.PI / 180;
            Double deltaPhi = (other.latitude - this.latitude) * Math.PI / 180;
            Double deltaLambda = (other.longitude - this.longitude) * Math.PI / 180;

            Double a = Math.Sin(deltaPhi / 2) * Math.Sin(deltaPhi / 2) +
                      Math.Cos(phi1) * Math.Cos(phi2) *
                      Math.Sin(deltaLambda / 2) * Math.Sin(deltaLambda / 2);
            Double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            Double d = R * c / 1000; // in kilometres
            return d;
        }
        public override string ToString()
        {
            return $"Bus Station Code: {stationCode} {latitude:F6}°N {longitude:F6}°E";
        }


    }
}
