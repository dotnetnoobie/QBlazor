using System.Collections.Generic;

namespace QBlazor.Embed.Models
{
    public interface IAlternates
    {
        List<string> Atom { get; set; }

        List<string> Rss { get; set; } 
    }
}