using System.Threading;
using System.Threading.Tasks;

namespace Scraper.Domain.Services.Scraper
{
    public interface IScraperService
    {
        Task<string> ScrapeAsync(
            string urlToScrape,
            string textToFind,
            CancellationToken cancellationToken);
    }
}
