using HtmlAgilityPack;
using System.Net.Http;
using System.Threading.Tasks;

namespace SunCalender.Services;

public static class DollarPriceExtractor
{
    private static readonly string url = "https://alanchand.com/currencies-price/usd";

    public static int ExtractPrice()
    {
        var web = new HtmlWeb();
        var doc = web.Load(url);

        var priceNode = doc.DocumentNode.SelectSingleNode("//input[@id='convertInput']");

        if (priceNode != null)
        {
            var price = priceNode.Attributes.First(at => at.Name == "value").Value;
            return Convert.ToInt32(price);
        }

        return -1;
    }
}
