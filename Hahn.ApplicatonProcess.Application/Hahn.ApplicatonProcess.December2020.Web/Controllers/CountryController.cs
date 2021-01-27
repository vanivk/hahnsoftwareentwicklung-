using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Domain.Services.CountryService;
using Microsoft.AspNetCore.Mvc;

namespace Hahn.ApplicationProcess.December2020.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController: ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// Returns a country by name [if exists]
        /// </summary>
        /// <returns></returns>
        [HttpGet("country/{countryName}")]
        public async Task<IActionResult> GetCountryName(string countryName)
        {
            var result = await _countryService.GetCountryByNameAsync(countryName);
            return Ok(result);
        }

        /// <summary>
        /// Returns list of all countries
        /// </summary>
        /// <returns></returns>
        [HttpGet("all-countries")]
        public async Task<IActionResult> GetAllValidCountries()
        {
            var result = await _countryService.GetAllCountriesAsync();
            var namesOnly = result.Select(x => 
                new
                {
                    x.Name, 
                    x.NativeName
                }).ToList();
            return Ok(namesOnly);
        }
    }
}