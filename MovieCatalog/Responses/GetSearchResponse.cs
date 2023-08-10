using System;

namespace MovieCatalog.Application.Api.Responses
{
    public class GetSearchResponse
    {
        public int Id { get; set; }
        public string SearchToken { get; set; }
        public string ImdbID { get; set; }
        public int ProcessingTimeMs { get; set; }
        public DateTime TimeStamp { get; set; }
        public string IpAddress { get; set; }
    }
}
