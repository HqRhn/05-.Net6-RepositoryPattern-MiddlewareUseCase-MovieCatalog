using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalog.Domain.Model
{
    public class MovieSearch
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("search_token")]
        public string SearchToken { get; set; }

        [BsonElement("imdbID")]
        public string ImdbID { get; set; }

        [BsonElement("processing_time_ms")]
        public long ProcessingTimeMs { get; set; }

        [BsonElement("timestamp")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime TimeStamp { get; set; }

        [BsonElement("ip_address")]
        public string IpAddress { get; set; }
    }
}
