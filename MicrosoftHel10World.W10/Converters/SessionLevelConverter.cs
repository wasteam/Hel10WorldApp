using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace MicrosoftHel10World.Converters
{
    class SessionLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var sessionLevel = value as string;
            if (!string.IsNullOrWhiteSpace(sessionLevel))
            {
                switch (sessionLevel.ToLowerInvariant())
                {
                    case "newbie":
                        return new SolidColorBrush(Windows.UI.Color.FromArgb(255, 92, 184, 92));
                    case "medium":
                        return new SolidColorBrush(Windows.UI.Color.FromArgb(255, 240, 173, 78));
                    case "advanced":
                        return new SolidColorBrush(Windows.UI.Color.FromArgb(255, 217, 83, 79));
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
