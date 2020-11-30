using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using HW2;

namespace HW3B
{
    class BusStatusToBGColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BusStatus busStatus = (BusStatus)value;
            if (busStatus == BusStatus.Ready)
                return Brushes.LightSeaGreen;
            if (busStatus == BusStatus.OnRefueling)
                return Brushes.Yellow;
            if (busStatus == BusStatus.DuringTrip)
                return Brushes.DimGray;
            if (busStatus == BusStatus.InService)
                return Brushes.Orange;
            return Brushes.White;


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
