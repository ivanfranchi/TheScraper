using Microsoft.AspNetCore.Mvc;
using Scraper.Domain.Services.Scraper;
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

        [HttpGet("GetScrapeInfo/{textToFind}/{keywordsToSearch}")]
        public async Task<string> GetScrapeInfo(
            string textToFind,
            string keywordsToSearch,
            CancellationToken cancellationToken)
        {
            var howMany = 20;
            keywordsToSearch = string.Join('+', keywordsToSearch.Split(' '));
            var url = $"https://www.google.co.uk/search?num={howMany}&q={keywordsToSearch}";

            var res = await _scraperService.ScrapeAsync(url, textToFind, cancellationToken);

            return res;
        }
    }
}
