using AppStudio.DataProviders;
using AppStudio.DataProviders.Rss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftHel10World.DataProviders.Hel10
{
    public class Hel10DataProvider : DataProviderBase<RssDataConfig, Hel10Schema>
    {
        public override Task<IEnumerable<Hel10Schema>> LoadDataAsync(RssDataConfig config)
        {
            return LoadDataAsync(config, new Hel10Parser());
        }

        public override async Task<IEnumerable<Hel10Schema>> LoadDataAsync(RssDataConfig config, IParser<Hel10Schema> parser)
        {
            var httpClient = new HttpClient();

            var rssContent = await httpClient.GetStringAsync(config.Url);
            return parser.Parse(rssContent);
        }
    }
}
