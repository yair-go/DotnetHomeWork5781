using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class BusLines : IEnumerable
    {
        List<BusLine> busLines;

        public List<BusLine> GetBusLines { get => busLines;  }

        public List<int> BusLinesNums 
        { 
            get 
            {
                return busLines.Select(busLine => busLine.BusLineNum).ToList();
            } 
        }
        public BusLines()
        {
            busLines = new List<BusLine>();
        }
        public IEnumerator GetEnumerator()
        {
           return busLines.GetEnumerator();
        }

        public BusLine this[int busLineNum]
        {
            get
            {
                return busLines.FirstOrDefault(busLine => busLine.BusLineNum == busLineNum);
            }
        }

        public BusLine this[int busLineNum, Area area]
        {
            get
            {
                return busLines.Find(busLine => busLine.BusLineNum == busLineNum && busLine.Area == area);
            }
        }

        public void AddBusLine(BusLine busLine)
        {
            busLines.Add(busLine);
        }
    }
}
