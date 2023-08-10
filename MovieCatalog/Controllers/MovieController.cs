using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieCatalog.Application.Service;
using MovieCatalog.Responses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public IConfiguration _configuration;
        HttpClient httpClient;
        public MovieController(IConfiguration configuration)
        { 
            _configuration = configuration;
        }

        [HttpGet, Route("GetMovieDetailByTitle")]
        public async Task<SearchByTitleResponse> GetMovie(string title)
        {            
            httpClient = new HttpClient();
            var omdbApiKey = _configuration.GetSection("Keys").GetSection("OmdbApiKey").Value;
            var response = await httpClient.GetAsync($"http://www.omdbapi.com/?apikey={omdbApiKey}&t={title}");
            var jsonString = await response.Content.ReadAsStringAsync();
            SearchByTitleResponse movie = JsonConvert.DeserializeObject<SearchByTitleResponse>(jsonString);
            return movie;
        }

    }
}
