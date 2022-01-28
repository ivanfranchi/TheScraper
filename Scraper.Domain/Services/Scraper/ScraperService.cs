using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Scraper.Domain.Services.Scraper
{
    public class ScraperService : IScraperService
    {
        public async Task<string> ScrapeAsync(string urlToScrape, string textToFind)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler { UseCookies = false };
            var cookieContainer = new CookieContainer();
            var theCookie = new Cookie("CONSENT", "YES+shp.gws-20220120-0-RC1.en+FX+515");
            var uri = new Uri("https://www.google.com");
            cookieContainer.Add(uri, theCookie);
            httpClientHandler.CookieContainer = cookieContainer;
            HttpClient client = new HttpClient(httpClientHandler);
            var message = new HttpRequestMessage(HttpMethod.Get, urlToScrape);
            message.Headers.Add("Cookie", "CONSENT=YES+shp.gws-20220120-0-RC1.en+FX+515");

            HttpResponseMessage response = await client.SendAsync(message); //canc token
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;

            //if (File.Exists(filePath))
            //{
            //    //var text = File.ReadAllText("allPageReturn.txt");

            //    XPathNavigator nav;
            //    XPathDocument docNav;
            //    string xPath;

            //    docNav = new XPathDocument(filePath); //"c:\\books.xml"
            //    nav = docNav.CreateNavigator();
            //    xPath = "/Cell/CellContent/Para/ParaLine/String/text()";
            //    //div[@id="search"][1]/div[1]/div[1]//div/div[1]/div[1]/div[1]/a[1]/@href

            //    string val = nav.SelectSingleNode(xPath).Value;

            //}
        }

        public async Task<string> ScrapeAsync2(
            string urlToScrape,
            string textToFind)
        {
            //static file on disk
            //string filePath = "C:\\allPageReturn.txt";
            string filePath = "..\\Scraper.Domain\\Resources\\allPageReturn.txt";
            if (File.Exists(filePath))
            {
                var test = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

                using (StreamReader sr = new StreamReader(filePath))
                {
                    XPathNavigator nav;
                    XPathDocument docNav;
                    string xPath;

                    docNav = new XPathDocument(sr.BaseStream);
                    nav = docNav.CreateNavigator();
                    xPath = "/div[@id='search'][1]/div[1]/div[1]//div/div[1]/div[1]/div[1]/a[1]/@href";
                    //div[@id='search'][1]/div[1]/div[1]//div/div[1]/div[1]/div[1]/a[1]/@href

                    //string val = nav.Select SelectSingleNode(xPath).Value;
                }
            }


            return "could not get the scrape";
        }
    }
}
