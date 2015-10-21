using AppStudio.DataProviders.TouchDevelop;

namespace MicrosoftHel10World.Config
{
    public abstract class TouchDevelopConfigBase : ConfigBase<TouchDevelopDataConfig, TouchDevelopSchema>
    {
        public abstract string Title { get; }
    }
}
