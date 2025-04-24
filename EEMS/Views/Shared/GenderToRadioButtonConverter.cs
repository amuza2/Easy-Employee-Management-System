using System.Globalization;
using System.Windows.Data;

namespace EEMS.UI.Views.Shared;

class GenderToRadioButtonConverter : IValueConverter
{
    // Converts the bound value to IsChecked
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string gender && parameter is string radioButtonValue)
            return gender.Equals(radioButtonValue, StringComparison.OrdinalIgnoreCase);
        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool isChecked && isChecked && parameter is string radioButtonValue)
            return radioButtonValue;
        return Binding.DoNothing;
    }
}
