using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DocumentGenerator
{
    [ValueConversion(typeof(string), typeof(string))]
    public class StringToButtonImageConverters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case "Report":
                    return "/Images/Report.png";
                case "Settings":
                    return "/Images/Settings.png";
                default:
                    return "/Images/Default.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
