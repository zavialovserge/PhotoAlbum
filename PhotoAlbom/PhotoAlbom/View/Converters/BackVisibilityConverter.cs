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
    /// <summary>
    /// Reprezent Visibility converter fo SengleImageView
    /// </summary>
    [ValueConversion (typeof(bool),typeof(Visibility))]
    public class BackVisibilityConverter:AbstractVisibilityConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Collapsed : Visibility.Visible;
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(Visibility.Collapsed);
        }
    }
}
