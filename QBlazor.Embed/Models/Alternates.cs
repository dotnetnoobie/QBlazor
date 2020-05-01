using System.Collections.Generic;

namespace QBlazor.Embed.Models
{
    public class Alternates : IAlternates
    {
        public List<string> Rss { get; set; }

        public List<string> Atom { get; set; }
    }
}