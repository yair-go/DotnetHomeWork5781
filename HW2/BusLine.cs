using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class BusLine : IComparable
    {
        private List<BusLineStation> stations;
        private int busLineNum;
        private BusStation firstStation;
        private BusStation lastStation;
        private Area area;

       

        public BusLine( int busLineNum, BusStation firstStation, BusStation lastStation, Area area)
        {
            this.stations = new List<BusLineStation>();
            stations.Add(new BusLineStation(firstStation));
            stations.Add(new BusLineStation(lastStation,0, new TimeSpan(0, 12, 0)));
            this.busLineNum = busLineNum;
            this.firstStation = firstStation;
            this.lastStation = lastStation;
            this.area = area;
        }

        public int BusLineNum { get => busLineNum; set => busLineNum = value; }
        public Area Area { get => area; set => area = value; }
        public List<BusLineStation> Stations { get => stations; set => stations = value; }
        internal BusStation FirstStation
        {
            get
            {
                return firstStation;
            }
            set
            {
                firstStation = value;
                Stations[0] = new BusLineStation(firstStation);
            }
        }
        internal BusStation LastStation
        {
            get
            {
                return lastStation;
            }
            set
            {
                lastStation = value;
                Stations.Add(new BusLineStation(lastStation));
                // TODO : update values between two busLineStaion, maybe set should be avoided
            }
        }

        public void AddStation(BusStation busStation, int distance, int minute)
        {
            BusLineStation busLineStation = new BusLineStation(busStation, distance, new TimeSpan(0, minute, 0));
            stations.Insert(stations.Count - 1, busLineStation);
        }

        public void InsertStation(BusStation busStation, int pos, int distance, int minute)
        {
            BusLineStation busLineStation = new BusLineStation(busStation, distance, new TimeSpan(0, minute, 0));
            stations.Insert(pos, busLineStation);
        }

        public void RemoveStation(BusStation busStation)
        {
            BusLineStation busLineStation = stations.Find(bls => bls.BusStaionCode == busStation.StationCode);
            stations.Remove(busLineStation);
        }

        private int routePosition(BusStation busStation)
        {
            for (int i = 0; i < stations.Count; i++)
            {
                if (stations[i].BusStaionCode == busStation.StationCode)
                    return i;
            }
            return -1;
        }

        public int DistanceBetweenStations(BusStation busStationA, BusStation busStationB)
        {
            int stationAPosition = routePosition(busStationA);
            int stationBPosition = routePosition(busStationB);

            // TODO : stationAPosition < stationBPosition

            int distance = 0;
            if ((stationAPosition != -1) && (stationBPosition != -1))
                for (int i = stationAPosition + 1; i < stationBPosition; i++)
                {
                    distance += stations[i].DistanceFromPrevStation;
                }
            return distance;
        }

        public Double TimeBetweenStations(BusStation busStationA, BusStation busStationB)
        {
            int stationAPosition = routePosition(busStationA);
            int stationBPosition = routePosition(busStationB);

            // TODO : stationAPosition < stationBPosition

            TimeSpan time = new TimeSpan();
            if ((stationAPosition != -1) && (stationBPosition != -1))
                for (int i = stationAPosition + 1; i < stationBPosition; i++)
                {
                    time += stations[i].TimeFromPrevStation;
                }
            return time.TotalMinutes;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"Line : {BusLineNum} Area : {Area}\n");
            foreach (var bls in stations)
            {
                sb.Append($"{bls.BusStaionCode} ");
            }
            return sb.ToString();
        }

        public Double TotalTime() 
        {
            return TimeBetweenStations(FirstStation, LastStation);
        }

        public int CompareTo(object obj)
        {
            return TotalTime().CompareTo((obj as BusLine).TotalTime());
        }

        public BusLine SubRoute(BusStation busStationA, BusStation busStationB)
        {
            //TODO: implement Sub Route 
            return new BusLine(this.busLineNum, this.firstStation, this.lastStation, this.area);
        }
        public override bool Equals(object obj)
        {
            return this.busLineNum.Equals((obj as BusLine).busLineNum );
        }

        public bool Contain(int stationCode)
        {
            foreach (var station in stations)
            {
                if (station.BusStaionCode == stationCode)
                    return true;
            }
            return false;
        }
    }
}
