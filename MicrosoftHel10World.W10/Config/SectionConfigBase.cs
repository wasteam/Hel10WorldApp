using AppStudio.DataProviders;
using AppStudio.Uwp.Navigation;

namespace MicrosoftHel10World.Config
{
    public abstract class SectionConfigBase<TConfig, TSchema> : ConfigBase<TConfig, TSchema> where TSchema : SchemaBase
    {
        public abstract string PageTitle { get; }
        public abstract NavigationInfo ListNavigationInfo { get; }
        public abstract ListPageConfig<TSchema> ListPage { get; }
        public abstract DetailPageConfig<TSchema> DetailPage { get; }
    }
}
