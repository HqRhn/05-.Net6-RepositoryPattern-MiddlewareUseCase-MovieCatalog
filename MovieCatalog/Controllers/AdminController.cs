using Microsoft.AspNetCore.Mvc;
using MovieCatalog.Application.Service;
using System.Threading.Tasks;
using System;
using MovieCatalog.Common.Authentication;

namespace MovieCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
       
        [HttpGet, Route("GetAllSearchResult")]
        public async Task<IActionResult> GetAllSearchResult()
        {
            return Ok(await _adminService.GetAllMovieSearchRequestsAsync().ConfigureAwait(false));
        }

        [HttpGet(), Route("GetSearchResultById")]
        public async Task<IActionResult> GetSearchResultById(string Id)
        {
            var movie = await _adminService.GetByIdAsync(Id).ConfigureAwait(false);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet("{searchToken:minlength(3)}")]
        public async Task<IActionResult> GetSearchResultBySearchToken(string searchToken)
        {
            var movie = await _adminService.GetBySearchTokenAsync(searchToken).ConfigureAwait(false);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet, Route("GetAllRequestForGivenDuration")]
        public async Task<IActionResult> GetAllRequestForGivenDurationAsync(DateTime fromDate, DateTime toDate)
        {
            //add validation for input dates.
            return Ok(await _adminService.GetAllRequestForGivenDurationAsync(fromDate, toDate).ConfigureAwait(false));
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var movie = await _adminService.GetByIdAsync(id).ConfigureAwait(false);
            if (movie == null)
            {
                return NotFound();
            }
            await _adminService.DeleteAsync(movie.Id).ConfigureAwait(false);
            return NoContent();
        }

        [HttpGet, Route("GetNumberOfRequestOnGivenDate")]
        public int GetNumberOfRequestOnGivenDate(DateTime date)
        {
            // add validation for input date
            var count = _adminService.NumberOfRequestOnGivenDate(date);
            return count;
        }
    }
}
