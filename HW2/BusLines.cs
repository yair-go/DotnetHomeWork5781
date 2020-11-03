using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class BusLines : IEnumerable
    {
        List<BusLine> busLines;

        public BusLines()
        {
            busLines = new List<BusLine>();
        }
        public IEnumerator GetEnumerator()
        {
           return busLines.GetEnumerator();
        }

        internal void AddBusLine(BusLine busLine)
        {
            busLines.Add(busLine);
        }
    }
}
