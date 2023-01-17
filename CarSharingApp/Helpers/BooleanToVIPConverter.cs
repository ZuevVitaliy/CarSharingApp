using CarSharingApp.Models.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CarSharingApp.Helpers
{
    internal class BooleanToVIPConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vip = (Vip)value;
            return vip == Vip.Vip? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool vip = (bool)value;
            return vip ? Vip.Vip : Vip.Common;
        }
    }
}
