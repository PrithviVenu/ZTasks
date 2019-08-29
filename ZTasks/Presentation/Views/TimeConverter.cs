using System;
using System.Diagnostics;
using Windows.UI.Xaml.Data;

namespace ZTasks.Presentation.Views
{
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //Debug.WriteLine(value);
        
                return new DateTimeOffset(((DateTime)value).ToUniversalTime());

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ((DateTimeOffset)value).DateTime;
        }
    }
}
