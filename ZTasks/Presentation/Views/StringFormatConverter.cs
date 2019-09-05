using System;
using System.Diagnostics;
using Windows.UI.Xaml.Data;

namespace ZTasks.Presentation.Views
{
    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //Debug.WriteLine(value);

            //   return new DateTimeOffset(((DateTime)value).ToUniversalTime());
            if (value == null)
                return null;

            DateTime dt = DateTime.Parse(value.ToString());
            return dt.ToString("ddd MMM dd");

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ((DateTimeOffset)value).DateTime;
        }
    }
}
