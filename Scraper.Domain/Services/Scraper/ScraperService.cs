using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Scraper.Application.Services.Scraper
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

            var xy = ParseXml(responseBody);
            return responseBody;
        }

        private List<int> ParseXml(string xml)
        {
            var result = new List<int>();

            xml = xml.Replace("doctype", "DOCTYPE");
            xml = xml.Replace("UTF-8", "UTF-16");

            xml = xml.Replace("&apos;", "'")
                .Replace("&quot;", "\"")
                //.Replace("&gt;", ">")
                //.Replace("&lt;", "<")
                .Replace("&", "&amp;");

            XmlDocument xreader = new XmlDocument();
            xreader.LoadXml(xml);
            XmlNode root = xreader.DocumentElement;
            XmlNodeList xnList =
                   xreader.SelectNodes("/div[1]/div[1]/a ");
            XmlNodeList xnList1 =
                   xreader.SelectNodes("/html/div[1]");

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
