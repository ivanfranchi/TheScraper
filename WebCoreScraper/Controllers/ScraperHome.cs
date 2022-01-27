using Microsoft.AspNetCore.Mvc;
using Scraper.Domain.Services.Scraper;
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

        //public ScraperHomeController()
        //{
        //}

        [HttpGet]
        public string Get()
        {
            return "Welcome Scraper (backend)";
        }

        [HttpGet("GetScrapeInformation")]
        public string GetScrapeInformation()
        {
            string id = "ciao";
            return $"You asked id {id}";
        }

        [HttpGet("GetScrapeInfo/{textToFind}")]
        public async Task<string> GetScrapeInfo(string textToFind, string keywordsToSearch)
        {
            var url = "https://www.google.co.uk/search?num=100&q=land+registry+search";


            var res = await _scraperService.ScrapeAsync(url, textToFind);

            return res;
        }
    }
}
