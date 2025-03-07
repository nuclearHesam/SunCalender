﻿using HtmlAgilityPack;

namespace Services;

public static class DollarPriceExtractor
{
    private static readonly string url = "https://alanchand.com/currencies-price/usd";

    public async static Task<int> ExtractPrice()
    {
        var web = new HtmlWeb();
        var doc = await web.LoadFromWebAsync(url);

        var priceNode = doc.DocumentNode.SelectSingleNode("//input[@id='convertInput']");

        if (priceNode != null)
        {
            var price = priceNode.Attributes.First(at => at.Name == "value").Value;
            return Convert.ToInt32(price);
        }

        return -1;
    }
}
