using System.Net.Http;
using System.Threading.Tasks;

namespace Scraper.Domain.Services.Scraper
{
    public class ScraperService : IScraperService
    {
        public async Task<string> ScrapeAsync(string urlToScrape, string textToFind)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(urlToScrape);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}
