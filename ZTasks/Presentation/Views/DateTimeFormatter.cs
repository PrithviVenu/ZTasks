using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ZTasks.Presentation.Views
{
    class DateTimeFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {

            if (value == null)
                return null;

            return ((DateTimeOffset)value);

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;
            return (DateTimeOffset)(((DateTimeOffset)value).DateTime.Date);
        }
    }
}
