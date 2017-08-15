using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PhotoAlbom.View.Converters
{
    [ValueConversion (typeof(bool),typeof(Visibility))]
    public abstract class AbstractVisibilityConverter :  IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
          
            return value.Equals(Visibility.Visible);
        }
    }
}
