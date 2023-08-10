using MovieCatalog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Infrastructure.Repository
{
    public interface IAdminRepository
    {
        Task<MovieSearch> AddMovieSearchAsync(MovieSearch movieSearch);

        Task<List<MovieSearch>> GetAllMovieSearchRequestsAsync();

        Task<MovieSearch> GetByIdAsync(string Id);

        Task<MovieSearch> GetBySearchTokenAsync(string searchToken);

        Task<List<MovieSearch>> GetAllRequestForGivenDurationAsync(DateTime fromDate, DateTime toDate);

        Task DeleteAsync(string id);

        int NumberOfRequestOnGivenDate(DateTime date);
    }
}
