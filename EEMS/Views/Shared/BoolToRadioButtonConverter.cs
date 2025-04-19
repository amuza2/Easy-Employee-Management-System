using System.Globalization;
using System.Windows.Data;

namespace EEMS.UI.Views.Shared;

public class BoolToRadioButtonConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is true;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is true;
    }
}
