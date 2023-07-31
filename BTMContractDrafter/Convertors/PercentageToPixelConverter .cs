using System.Globalization;
using System;
using System.Windows.Data;

namespace BTMContractDrafter.Convertors;

public class PercentageToPixelConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length == 2 && values[0] is double percentage && values[1] is double totalWidth)
        {
            return percentage * totalWidth;
        }

        return 0;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}