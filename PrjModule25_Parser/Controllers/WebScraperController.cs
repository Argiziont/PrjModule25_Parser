﻿using System;
using System.Collections.Concurrent;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.Mvc;
using PrjModule25_Parser.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PrjModule25_Parser.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebScraperController : ControllerBase
    {
        private static async Task<CarAdvert> FindDataInsideProductPageAsync(IBrowsingContext context,string subUrl)
        {
            var id = Guid.NewGuid().ToString();

            var product = await context.OpenAsync(subUrl);

            var title = product.QuerySelector("*[data-qaid='product_name']")?.InnerHtml ?? "";
            var companyName = product.QuerySelector("*[data-qaid='company_name']")?.InnerHtml ?? "";

            var sku = product.QuerySelector("span[data-qaid='product-sku']")?.InnerHtml ?? "";

            var presence = product.QuerySelector("span[data-qaid='product_presence']")?.FirstElementChild?.InnerHtml ?? "";

            var descriptionChildren = product.QuerySelector("div[data-qaid='descriptions']")?.Children;
            var description = UnScrubDiv(descriptionChildren).Replace(@"&nbsp;", "");

            var priceSelector = (IHtmlSpanElement)product.QuerySelector("span[data-qaid='product_price']");
            var fullPriceSelector = (IHtmlSpanElement)product.QuerySelector("span[data-qaid='price_without_discount']");
            var optPriceSelector = (IHtmlSpanElement)product.QuerySelector("span[data-qaid='opt_price']");
            var shortCompanyRating = (IHtmlDivElement)product.QuerySelector("div[data-qaid='short_company_rating']");


            var price = priceSelector?.Dataset["qaprice"] ?? "";
            var currency = priceSelector?.Dataset["qacurrency"] ?? "";

            var fullPrice = fullPriceSelector?.Dataset["qaprice"] ?? "";
            var fullCurrency = fullPriceSelector?.Dataset["qacurrency"] ?? "";

            var optPrice = optPriceSelector?.Dataset["qaprice"] ?? "";
            var optCurrency = optPriceSelector?.Dataset["qacurrency"] ?? "";

            var posPercent = shortCompanyRating?.Dataset["qapositive"]+"%";
            var lastYrReply = shortCompanyRating?.Dataset["qacount"] ?? "";


            //Picking image list
            var imageSrcList = product.QuerySelector("div[data-qaid='image_block']")//<Upper div>
                ?.Children//<Lower divs>
                ?.First(m => m.ClassList
                    .Contains("ek-grid__item_width_expand") == false) //<Lower div with thumbnails>
                ?.Children//<Ul>
                ?.First()
                ?.Children//<Li>
                ?.Select(i => ((IHtmlImageElement)i//<Img>
                    .QuerySelector("img[data-qaid='image_thumb']"))?.Source)//Src="Urls"
                .ToList();

            return new CarAdvert()
            {
                Currency = currency,
                Price = price,
                FullCurrency = fullCurrency,
                FullPrice = fullPrice,
                OptCurrency = optCurrency,
                OptPrice = optPrice,
                Description = description,
                Presence = presence,
                ScuCode = sku,
                Title = title,
                CompanyName = companyName,
                ImageUrls = imageSrcList,
                PositivePercent = posPercent,
                RatingsPerLastYear = lastYrReply,
                AdvertId = id
            };
        }

        private static IList<CarAdvert> ParallelParsing(IBrowsingContext context, IEnumerable<string> linksToProducts)
        {
            var parallelElements = new ConcurrentBag<CarAdvert>();

            Parallel.ForEach(linksToProducts, link =>
            {
                try
                {
                    var productInfo =FindDataInsideProductPageAsync(context, link).Result;
                    parallelElements.Add(productInfo);
                    
                }
                catch
                {
                    // ignored
                }
            });
           
            return parallelElements.ToList();
        }
        
        private static string UnScrubDiv(IEnumerable<IElement> divElements)
        {
            var unScrubText = "";
            foreach (var div in divElements)
            {
                if (div.Children.Length > 0)
                    unScrubText += UnScrubDiv(div.Children);
                else
                    unScrubText += "\n" + div.InnerHtml;
            }

            return unScrubText;
        }

        [Route("Get")]
        [HttpGet]
        [ProducesResponseType(typeof(List<CarAdvert>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Get(string url = "https://prom.ua/Sportivnye-kostyumy")
        {
            try
            {
                var config = Configuration.Default.WithDefaultLoader();
                var context = BrowsingContext.New(config);
                var document = await context.OpenAsync(url);

                // Debug
                var linksToProducts = document.All
                    .Where(m => m.LocalName == "a" && m.ClassList
                        .Contains("productTile__tileLink--204An"))
                    .Select(m => ((IHtmlAnchorElement)m).Href)
                    .ToList();

                var elements = ParallelParsing(context, linksToProducts);

                return Ok(elements);

            }
            catch (Exception e)
            {
                return  BadRequest(e);
            }
        }
    }

}
//https://prom.ua/Sportivnye-kostyumy
//data-qaid="variation_block"
//data-qaid="image_block"
