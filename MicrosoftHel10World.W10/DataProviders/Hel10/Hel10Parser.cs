using AppStudio.DataProviders;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Syndication;

namespace MicrosoftHel10World.DataProviders.Hel10
{
    public class Hel10Parser : IParser<Hel10Schema>
    {
        public IEnumerable<Hel10Schema> Parse(string data)
        {
            var feed = new SyndicationFeed();

            feed.Load(data);

            return feed.Items
                            .Select(i => new Hel10Schema
                            {
                                _id = i.Id,
                                Title = i.Title.Text,
                                Summary = i.Summary.Text,
                                StartDateTime = i.PublishedDate.UtcDateTime,
                                EndDateTime = i.PublishedDate.UtcDateTime.AddMinutes(50),
                                Category = i.Categories[0].Term,
                                Author = GetAuthor(i),
                                Level = GetLevel(i),
                                Room = GetRoom(i)
                            })
                            .ToList();
        }

        private static string GetAuthor(SyndicationItem item)
        {
            return item.ElementExtensions[0].NodeValue;
        }
        private static string GetLevel(SyndicationItem item)
        {
            return GetPropertyFromContent(item, "Nivel");
        }

        private static string GetRoom(SyndicationItem item)
        {
            return GetPropertyFromContent(item, "Lugar");
        }

        private static string GetPropertyFromContent(SyndicationItem item, string elementName)
        {
            var content = item.ElementExtensions[3].NodeValue;
            var node = HtmlNode.CreateNode(content);
            var text = node.ChildNodes
                                .FirstOrDefault(n => n.Name == "p" && n.InnerText.StartsWith($"{elementName}:"));
            if (text != null)
            {
                return text.InnerText
                                .Replace($"{elementName}:", string.Empty)
                                .Trim();
            }
            return "";
        }
    }
}
