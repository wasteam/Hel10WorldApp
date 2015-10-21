using AppStudio.Uwp;
using Windows.ApplicationModel;

namespace MicrosoftHel10World.ViewModels
{
    public class AboutThisAppViewModel : PageViewModel
    {
        public string Publisher
        {
            get
            {
                return "innovega";
            }
        }

        public string AppVersion
        {
            get
            {
                return string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            }
        }

        public string AboutText
        {
            get
            {
                return "Información sobre el evento Hel10 World de Microsoft el día 22 de Octubre en Madr" +
    "id.";
            }
        }
    }
}

