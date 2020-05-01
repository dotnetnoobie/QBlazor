using System;
using System.Collections.Generic;

namespace QBlazor.Embed.Models
{ 
    public class MetaData : IMetaData
    {
        public string CharSet { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        //public string Audio { get; set; }

        //public string Video { get; set; }

        public string Author { get; set; }

        public string Url { get; set; }

        public string Image { get; set; }

        public DateTimeOffset Timestamp { get; set; }
         
        public IAlternates Alternates { get; set; }

        public List<string> Keywords { get; set; }

        public string Canonical { get; set; }

        public IOEmbed OEmbed { get; set; }

        public IApps Apps { get; set; }

        public IMedia Media { get; set; }

        public string Encoding { get; set; }

        public string Viewport { get; set; }

        public MetaData()
        {
            this.Alternates = new Alternates();
            this.OEmbed = new OEmbed();
            this.Apps = new Apps();
            this.Media = new Media();
        }
    }
}