using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieCatalog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.Infrastructure.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IMongoCollection<MovieSearch> _collection;
        private readonly DbConfiguration _settings;

        public AdminRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<MovieSearch>(_settings.CollectionName);
        }
        public async Task<MovieSearch> AddMovieSearchAsync(MovieSearch movieSearch)
        {
            await _collection.InsertOneAsync(movieSearch).ConfigureAwait(false);
            return movieSearch;
        }

        public Task<List<MovieSearch>> GetAllMovieSearchRequestsAsync()
        {
            return _collection.Find(m => true).ToListAsync();
        }

        public Task<MovieSearch> GetByIdAsync(string Id)
        {
            return _collection.Find(m => m.Id == Id).FirstOrDefaultAsync();
        }

        public Task<MovieSearch> GetBySearchTokenAsync(string searchToken)
        {
            return _collection.Find(m => m.SearchToken == searchToken).FirstOrDefaultAsync();
        }

        public Task<List<MovieSearch>> GetAllRequestForGivenDurationAsync(DateTime fromDate, DateTime toDate)
        {
            return _collection.Find(m => m.TimeStamp > fromDate && m.TimeStamp < toDate).ToListAsync();
        }
        public Task DeleteAsync(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }

        public int NumberOfRequestOnGivenDate (DateTime date)
        {
            var startDay = date.Date;
            var endDay = date.Date.AddDays(1);
            return _collection.Aggregate().Match(m => m.TimeStamp >= startDay && m.TimeStamp < endDay).ToList().Count();
        }
    }
}
