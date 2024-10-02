using MyTasker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasker.Mobile.Converters
{
    public class WidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var model = Enum.GetName(typeof(MyTaskStatus), value);
            var result = (model.Length - 1) * 10;

            return result < 40 ? 40 : (result > 70 ? 70 : (result - 5));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
