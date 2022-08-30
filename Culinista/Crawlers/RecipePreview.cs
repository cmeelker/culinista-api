using HtmlAgilityPack;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Culinista.Crawlers
{
    public class RecipePreview
    {
        public string Title { get; set; }
        public string[] Images { get; set; }
        public string Favicon { get; set; }

        public RecipePreview() { }

        public async Task CrawlRecipePreview(string url)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            this.GetTitle(htmlDocument);
            this.GetImages(htmlDocument);
            this.GetFavicon(htmlDocument);
        }

        private void GetTitle(HtmlDocument htmlDocument)
        {
            var titleXPath = "//h1";
            var title = htmlDocument.DocumentNode.SelectSingleNode(titleXPath).InnerText;
            this.Title = HttpUtility.HtmlDecode(title);
        }

        private void GetImages(HtmlDocument htmlDocument)
        {
            var urls = htmlDocument.DocumentNode.Descendants("img")
                                .Select(e => e.GetAttributeValue("src", null))
                                .Where(s => !string.IsNullOrEmpty(s));


            var filteredUrls = urls.Distinct().Where(url => url.EndsWith(".jpg") | url.EndsWith(".png")).ToArray();

            this.Images = filteredUrls;
        }

        private void GetFavicon(HtmlDocument htmlDocument)
        {
            var favicon = htmlDocument.DocumentNode.SelectSingleNode("/html/head/link[@rel='icon' and @href]");
            if (favicon != null)
            {
                this.Favicon = favicon.Attributes["href"].Value;
            }
        }
    }
}
