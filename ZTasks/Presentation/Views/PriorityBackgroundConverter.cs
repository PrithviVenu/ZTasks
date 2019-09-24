using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace ZTasks.Presentation.Views
{
    public class PriorityBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;
            int data = (int)value;
            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, 136, 136, 136));
            switch (data)
            {
                case 2:
                    {
                        brush = new SolidColorBrush(Color.FromArgb(255, 217, 72, 59));
                        break;
                    }
                case 3:
                    {
                        brush = new SolidColorBrush(Color.FromArgb(255, 93, 188, 210));
                        break;
                    }
                case 4:
                    {
                        brush = new SolidColorBrush(Color.FromArgb(255, 136, 136, 136));
                        break;
                    }
            }
            return brush;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
