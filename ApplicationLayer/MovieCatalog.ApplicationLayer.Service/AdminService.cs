using MovieCatalog.Application.Service;
using MovieCatalog.Domain.Model;
using MovieCatalog.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieCatalog.ApplicationLayer.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _movieRepository;

        public AdminService(IAdminRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Task<MovieSearch> AddMovieSearchAsync(MovieSearch searchRequest)
        {
            return _movieRepository.AddMovieSearchAsync(searchRequest);
        }
        public Task<List<MovieSearch>> GetAllMovieSearchRequestsAsync()
        {
            return _movieRepository.GetAllMovieSearchRequestsAsync();
        }

        public Task<MovieSearch> GetByIdAsync(string Id)
        {
            return _movieRepository.GetByIdAsync(Id);
        }

        public Task<MovieSearch> GetBySearchTokenAsync(string searchToken)
        {
            return _movieRepository.GetBySearchTokenAsync(searchToken);
        }

        public Task<List<MovieSearch>> GetAllRequestForGivenDurationAsync(DateTime fromDate, DateTime toDate)
        {
            return _movieRepository.GetAllRequestForGivenDurationAsync(fromDate, toDate);
        }

        public Task DeleteAsync(string id)
        {
            return _movieRepository.DeleteAsync(id);
        }

        public int NumberOfRequestOnGivenDate(DateTime date)
        {
           return _movieRepository.NumberOfRequestOnGivenDate(date);
        }
    }
}
