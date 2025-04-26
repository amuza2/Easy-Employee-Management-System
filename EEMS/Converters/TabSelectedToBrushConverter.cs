using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace EEMS.UI.Converters;

public class TabSelectedToBrushConverter : IValueConverter
{
    public Brush SelectedBrush { get; set; } = Brushes.Blue;
    public Brush DefaultBrush { get; set; } = Brushes.Transparent;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || parameter == null)
            return DefaultBrush;

        string selectedTab = value.ToString();
        string thisTab = parameter.ToString();

        return selectedTab == thisTab ? SelectedBrush : DefaultBrush;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
