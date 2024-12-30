using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace disaster_management.Views.Converters
{
    class NumberToVisibilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int number && parameter is string targetNumber)
            {
                // Kiểm tra nếu số khớp với parameter
                if (int.TryParse(targetNumber, out int target))
                {
                    return number == target ? Visibility.Visible : Visibility.Collapsed;
                }
            }

            // Mặc định là Collapsed nếu không khớp
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("ConvertBack is not implemented.");
        }
    }
}
