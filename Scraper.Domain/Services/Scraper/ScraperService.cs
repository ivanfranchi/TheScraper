using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Scraper.Domain.Services.Scraper
{
    public class ScraperService : IScraperService
    {
        public async Task<string> ScrapeAsync(
            string urlToScrape,
            string textToFind,
            CancellationToken cancellationToken)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler
            {
                UseCookies = false
            };
            HttpClient client = new HttpClient(httpClientHandler);

            var message = new HttpRequestMessage(HttpMethod.Get, urlToScrape);
            message.Headers.Add("Cookie", "CONSENT=YES+shp.gws-20220120-0-RC1.en+FX+515");

            HttpResponseMessage response = await client.SendAsync(message, cancellationToken);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
