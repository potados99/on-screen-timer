using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace on_screen_timer
{
    class IntToFormatedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int num = Int32.Parse(value.ToString());
            string outputString = num.ToString();

            if (num  < 10)
            {
                outputString = string.Concat("0", outputString);
            }

            return outputString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
