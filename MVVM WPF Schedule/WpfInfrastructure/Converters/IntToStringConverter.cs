using System.Globalization;
using System.Windows.Data;

namespace MVVM_WPF_Schedule.WpfInfrastructure.Converters;

public class IntToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Преобразование int в string
        if (value is int intValue)
        {
            return intValue.ToString();
        }
        return value; // Если значение не int, просто возвращаем его
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Преобразование string в int
        if (int.TryParse(value as string, out int result))
        {
            return result;
        }
        return 0; // Если не удалось преобразовать строку в int, возвращаем значение без изменений
    }
}