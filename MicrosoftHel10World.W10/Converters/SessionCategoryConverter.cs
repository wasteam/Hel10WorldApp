using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace MicrosoftHel10World.Converters
{
    class SessionCategoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var sessionCategory = value as string;
            var opacity = GetOpacity(parameter);

            if (!string.IsNullOrWhiteSpace(sessionCategory))
            {
                switch (sessionCategory.ToLowerInvariant())
                {
                    case "universal windows platform":
                        return new SolidColorBrush(Windows.UI.Color.FromArgb(opacity, 129, 167, 81));
                    case "universal windows plaform & enterprise":
                        return new SolidColorBrush(Windows.UI.Color.FromArgb(opacity, 68, 142, 205));
                    case "universal windows platform, iot & cloud":
                        return new SolidColorBrush(Windows.UI.Color.FromArgb(opacity, 234, 185, 58));
                    case "windows 10 for it professionals":
                        return new SolidColorBrush(Windows.UI.Color.FromArgb(opacity, 249, 156, 112));
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        private static byte GetOpacity(object parameter)
        {
            byte opacity;
            var stringParameter = parameter as string;

            if (!string.IsNullOrWhiteSpace(stringParameter))
            {
                if(byte.TryParse(stringParameter, out opacity))
                {
                    return opacity;
                }
            }
            return byte.MaxValue;
        }
    }
}
