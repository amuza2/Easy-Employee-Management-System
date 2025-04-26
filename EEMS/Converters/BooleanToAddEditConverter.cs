using System.Globalization;
using System.Windows.Data;

namespace EEMS.UI.Converters;

public class BooleanToAddEditConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value ? "Update" : "Add";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
