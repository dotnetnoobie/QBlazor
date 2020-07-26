using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using QBlazor.Embed.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace QBlazor.Embed
{
    public class EmbedClient
    {
        private readonly HttpClient http;

        public EmbedClient(HttpClient http)
        {
            this.http = http;
        }

        public async Task<T> Embed<T>(string url) where T : IMetaData, new()
        {
            var html = await http.GetStringAsync(url);
            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(html);

            var rel = document.Head.QuerySelectorAll("link")
                .Where(x => x.HasAttribute("rel")).ToList();

            var alternates = rel.Where(x => x.HasAttribute("type") && x.HasAttribute("href")).ToList();

            var metaTags = document.Head.QuerySelectorAll("meta")
                .Where(x => x.HasAttribute("property") || x.HasAttribute("name"))
                .Select(x => new MetaDataItem { Name = x.Attributes["name"]?.Value ?? x.Attributes["property"]?.Value, Value = x.Attributes["content"]?.Value }).ToList();

            var twitter = metaTags.Where(x => x.Name.StartsWith("twitter:"))
                .Select(x => new MetaDataItem { Name = x.Name.Replace("twitter:", null), Value = x.Value });

            var opengraph = metaTags.Where(x => x.Name.StartsWith("og:"))
                .Select(x => new MetaDataItem { Name = x.Name.Replace("og:", null), Value = x.Value });


            IMetaData metaData = new T();

            return (T)metaData;
        }

        private void SetAlternates(ref IMetaData metaData, ref List<IElement> alternates)
        {
            var atom = alternates.Where(x => x.Attributes["type"].Value.EndsWith("atom+xml"))?.Select(x => x.Attributes["href"]?.Value).ToList();
            var rss = alternates.Where(x => x.Attributes["type"].Value.EndsWith("rss+xml"))?.Select(x => x.Attributes["href"]?.Value).ToList();

            if ((atom != null && atom.Any()) || (rss != null && rss.Any()))
            {
                metaData.Alternates = new Alternates();
                metaData.Alternates.Atom = atom.Any() ? atom : null;
                metaData.Alternates.Rss = rss.Any() ? rss : null;
            } 
        }

        private void SetOEmbed(ref IMetaData metaData, ref List<IElement> alternates)
        {
            var json = alternates.FirstOrDefault(x => x.Attributes["type"].Value.EndsWith("json+oembed"))?.Attributes["href"]?.Value;
            var xml = alternates.FirstOrDefault(x => x.Attributes["type"].Value.EndsWith("xml+oembed"))?.Attributes["href"]?.Value;

            if ((json != null && json.Any()) || (xml != null && xml.Any()))
            {
                metaData.OEmbed = new OEmbed();
                metaData.OEmbed.Json = string.IsNullOrEmpty(json) ? null : json;
                metaData.OEmbed.Xml = string.IsNullOrEmpty(xml) ? null : xml;
            } 
        }
    }
}
