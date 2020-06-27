namespace QBlazor.Embed.Models
{
    public interface IMedia
    {
        string Url { get; set; }

        string Type { get; set; }

        string Height { get; set; }

        string Width { get; set; }
    }
}