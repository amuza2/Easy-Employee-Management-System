﻿using System.Globalization;
using System.Windows.Data;

namespace EEMS.UI.Views.Shared;

public class InverseBoolToRadioButtonConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is false;
    }
}
