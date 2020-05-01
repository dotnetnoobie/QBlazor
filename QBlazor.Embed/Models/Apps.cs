namespace QBlazor.Embed.Models
{
    public class Apps : IApps
    {
        public App IPhone { get; set; }

        public App IPad { get; set; }

        public App GooglePlay { get; set; }

        public Apps()
        {
            this.IPad = new App();
            this.IPhone = new App();
            this.GooglePlay = new App();
        }
    }
}