using System.Globalization;
using System.Windows.Data;

namespace EEMS.UI.Converters;

public class BoolToRadioButtonConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
            return boolValue;
        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is bool isChecked && isChecked ? true : (bool?)null;
    }
}
