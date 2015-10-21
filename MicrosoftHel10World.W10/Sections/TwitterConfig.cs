using System;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.Twitter;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;
using MicrosoftHel10World.Config;
using MicrosoftHel10World.ViewModels;

namespace MicrosoftHel10World.Sections
{
    public class TwitterConfig : SectionConfigBase<TwitterDataConfig, TwitterSchema>
    {
        public override DataProviderBase<TwitterDataConfig, TwitterSchema> DataProvider
        {
            get
            {
                return new TwitterDataProvider(new TwitterOAuthTokens
                {
                    ConsumerKey = "AKm10AzfofZDXSfUvnv0S6oBz",
                    ConsumerSecret = "oY59S3OSMyOeDdqbk7PDUXBhPhQK7e2wldCVtBW1rGTwx4RXcc",
                    AccessToken = "3030137542-MjaSBhjI8ZqmjALxtsioSZFzZHlCCTBm2i9jEdk",
                    AccessTokenSecret = "MozAnyXioHYf6qeEcCrwRe87eT2mJDZOIun0BNMgkBPk0"
                });
            }
        }

        public override TwitterDataConfig Config
        {
            get
            {
                return new TwitterDataConfig
                {
                    QueryType = TwitterQueryType.Search,
                    Query = @"#Hel10World"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("TwitterListPage");
            }
        }

        public override ListPageConfig<TwitterSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<TwitterSchema>
                {
                    Title = "Twitter",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.UserName.ToSafeString();
                        viewModel.SubTitle = item.Text.ToSafeString();
                        viewModel.Description = null;
                        viewModel.Image = item.UserProfileImageUrl.ToSafeString();
                    },
                    NavigationInfo = (item) =>
                    {
                        return new NavigationInfo
                        {
                            NavigationType = NavigationType.DeepLink,
                            TargetUri = new Uri(item.Url)
                        };
                    }
                };
            }
        }

        public override DetailPageConfig<TwitterSchema> DetailPage
        {
            get { return null; }
        }

        public override string PageTitle
        {
            get { return "Twitter"; }
        }
    }
}
