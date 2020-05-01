using System;
using System.Collections.Generic;

namespace QBlazor.Embed.Models
{
    public interface IMetaData
    {
        string CharSet { get; set; }

        IAlternates Alternates { get; set; }

        IOEmbed OEmbed { get; set; }

        string Canonical { get; set; }

        string Author { get; set; }

        string Description { get; set; }

        string Encoding { get; set; }

        string Viewport { get; set; }

        string Image { get; set; }

        List<string> Keywords { get; set; }

        DateTimeOffset Timestamp { get; set; }

        string Title { get; set; }

        string Url { get; set; }

        IMedia Media { get; set; }

        //string Video { get; set; }

        //string Audio { get; set; }
    }
}