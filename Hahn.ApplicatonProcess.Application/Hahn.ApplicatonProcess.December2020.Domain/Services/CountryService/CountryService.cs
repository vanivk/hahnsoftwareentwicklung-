using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Hahn.ApplicationProcess.December2020.Domain.Configuration;
using Hahn.ApplicationProcess.December2020.Domain.Entities;
using Hahn.ApplicationProcess.December2020.Domain.Infrastructure;
using Hahn.ApplicationProcess.December2020.Domain.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicationProcess.December2020.Domain.Services.CountryService
{
    public class CountryService : BaseService, ICountryService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CountryService> _logger;
        private readonly ICacheManagement _cacheManagement;

        public CountryService(IConfiguration configuration,ILogger<CountryService> logger,ICacheManagement cacheManagement)
        {
            _configuration = configuration;
            _logger = logger;
            _cacheManagement = cacheManagement;
        } 

        public async Task<Country> GetCountryByNameAsync(string countryName)
        {
            var apiUrl = _configuration.GetValue<string>(AppConst.ExternalApis.CountryCheck.Url);
            _logger.LogInformation("started calling api for country by name: {countryName}", countryName);
            var response = await apiUrl
                .AllowAnyHttpStatus()
                .AppendPathSegment(countryName)
                .SetQueryParam("fullText", true)
                .GetAsync();
            _logger.LogInformation("fetched data from api for country by name: {countryName}", countryName);

            if (response.StatusCode < 300)
            {
                _logger.LogInformation("api response looks normal, countryName: {countryName}", countryName);
                var result = await response.GetJsonAsync<List<Country>>();
                
                return result.FirstOrDefault();
            }
            else if (response.StatusCode < 500)
            {
                _logger.LogWarning("api response status code is {statusCode}, countryName: {countryName}", response.StatusCode, countryName);
                var error = await response.GetJsonAsync<ExternalServiceHttpResponse>();
            }
            else
            {
                _logger.LogWarning("api response status code is {statusCode}, countryName: {countryName}", response.StatusCode, countryName);
                var error = await response.GetJsonAsync<ExternalServiceHttpResponse>();
            }
            return null;
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            var cachedList = _cacheManagement.GetValue<List<Country>>(AppConst.Cache.CountryList);
            if (cachedList != null && cachedList.Any())
            {
                return cachedList;
            }
            return _cacheManagement.CacheCall(
                AppConst.Cache.CountryList,
                AppConst.Cache.DefaultTimeoutInSeconds,
                await GetAllCountriesFromApi());
        }

        private async Task<List<Country>> GetAllCountriesFromApi()
        {
            var apiUrl = _configuration.GetValue<string>(AppConst.ExternalApis.CountryCheck.Url);
            _logger.LogInformation("api call started here");
            var response = await apiUrl
                .AllowAnyHttpStatus()
                .GetAsync();
            _logger.LogInformation("data got from api for all countries");
            if (response.StatusCode < 300)
            {
                _logger.LogInformation("country list api response received");
                var result = await response.GetJsonAsync<List<Country>>();
                return result.ToList();
            }
            else if (response.StatusCode < 500)
            {
                _logger.LogWarning("response code is {statusCode}", response.StatusCode);
                var error = await response.GetJsonAsync<ExternalServiceHttpResponse>();
            }
            else
            {
                _logger.LogWarning("response code is {statusCode}", response.StatusCode);
                var error = await response.GetJsonAsync<ExternalServiceHttpResponse>();
            }
            return null;
        }

    }
}
