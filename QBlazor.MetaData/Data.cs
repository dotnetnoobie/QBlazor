using System;

namespace QBlazor
{
    public class Data : IData
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        public string Image { get; set; }

        public string Audio { get; set; }

        public string Video { get; set; }

        public string Url { get; set; }

        public string Favicon { get; set; }

        public DateTimeOffset Timestamp { get; set; }
    }
}
