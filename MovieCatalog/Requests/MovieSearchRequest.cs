using System;

namespace MovieCatalog.Application.Api.Requests
{
    public class MovieSearchRequest
    {
        public string SearchToken { get; set; }
        public string ImdbID { get; set; }
        public int ProcessingTimeMs { get; set; }
        public DateTime TimeStamp { get; set; }
        public string IpAddress { get; set; }
    }
}
