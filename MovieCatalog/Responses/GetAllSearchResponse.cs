using Microsoft.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;

namespace MovieCatalog.Application.Api.Responses
{
    public class GetAllSearchResponse
    {
        public IEnumerable<GetSearchResponse> GetAllSearchResult { get; set; }
    }
}
