using System;
using AppStudio.Uwp;

namespace MicrosoftHel10World.ViewModels
{
    public class PrivacyViewModel : ObservableBase
    {
        public Uri Url
        {
            get
            {
                return new Uri(UrlText, UriKind.RelativeOrAbsolute);
            }
        }
        public string UrlText
        {
            get
            {
                return "https://www.desarrollaconmicrosoft.com/Windows10Hel10World";
            }
        }
    }
}

