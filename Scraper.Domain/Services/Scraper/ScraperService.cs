using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Scraper.Application.Services.Scraper
{
    public class ScraperService : IScraperService
    {
        public async Task<IEnumerable<int>> ScrapeAsync(
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

            return ParseXml(responseBody, textToFind);
        }

        private IEnumerable<int> ParseXml(string xml, string textToFind)
        {
            //Tried with xpath
            // //div[@id="search"][1]/div[1]/div[1]/div/div[1]/div[1]/div[1]/a/@href
            // but the tags change and couldn't get to a minimum working solution

            var result = new List<int>();
            var document = new HtmlDocument();
            document.LoadHtml(xml);

            HtmlNode root = document.DocumentNode;
            var rows = document.DocumentNode
                .SelectNodes("//body//text()")
                .Select(node => node.InnerText);

            var counter = 1;
            var goodRows = rows.Where(x => x.ToLower().StartsWith("www.")).Distinct().Skip(4);
            foreach (var line in goodRows)
            {
                if (line.ToLower().Contains(textToFind.ToLower()))
                {
                    result.Add(counter);
                }
                counter++;
            }

            if (result.Count == 0)
            {
                result.Add(0);
                return result;
            }
            else
            {
                return result;
            }
        }
    }
}
