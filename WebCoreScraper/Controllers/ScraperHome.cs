using Microsoft.AspNetCore.Mvc;

namespace WebCoreScraper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScraperHomeController : ControllerBase
    {
        public ScraperHomeController()
        {
        }

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

        [HttpGet("GetScrapeInfo/{id}")]
        public string GetScrapeInfo(string id)
        {
            return $"You asked id {id}";
        }
    }
}
