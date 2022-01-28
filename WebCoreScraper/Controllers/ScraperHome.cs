using Microsoft.AspNetCore.Mvc;
using Scraper.Application.Services.Scraper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WebCoreScraper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScraperHomeController : ControllerBase
    {
        private readonly IScraperService _scraperService;

        public ScraperHomeController(IScraperService scraperService)
        {
            _scraperService = scraperService;
        }

        [HttpGet]
        public string Get()
        {
            return "Welcome Scraper (backend)";
        }

        [HttpGet("GetScrapeInfo/{textToFind}/{keywordsToSearch}/{howMany}")]
        public async Task<IEnumerable<int>> GetScrapeInfo(
            string textToFind,
            string keywordsToSearch,
            string howMany,
            CancellationToken cancellationToken)
        {
            int howManyInt = int.TryParse(howMany, out howManyInt) ? howManyInt : 7;
            keywordsToSearch = string.Join('+', keywordsToSearch.Split(' '));
            var url = $"https://www.google.co.uk/search?num={howManyInt}&q={keywordsToSearch}";

            var res = await _scraperService.ScrapeAsync(url, textToFind, cancellationToken);
            return res;
        }
    }
}
