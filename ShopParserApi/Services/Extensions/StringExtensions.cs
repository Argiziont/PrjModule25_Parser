﻿using System;
using System.Collections.Generic;
using System.Linq;
using ShopParserApi.Models;

namespace ShopParserApi.Services.Extensions
{
    public static class StringExtensions
    {
        public static string SubstringJson(this string value, string start, string end)
        {
            var startIndex = value.IndexOf(start, StringComparison.Ordinal) + start.Length;
            var endIndex = value.IndexOf(end, StringComparison.Ordinal) - startIndex;

            var result = value.Substring(startIndex, endIndex).Trim();
            return result.Remove(result.Length - 1);
        }

        public static string CategoryToString(this IEnumerable<CategoryData> categories)
        {
            var categoryString = categories.Aggregate("", (current, category) => current + category.Name + " > ");
            return categoryString.Remove(categoryString.Length - 3);
        }

        public static string SplitCompanyUrl(this string value)
        {
            return value.Split("/").Last().Split('-').First().Replace("c", "");
        }

        public static string SplitProductUrl(this string value)
        {
            return value.Split("/").Last().Split('-').First().Replace("p", "");
        }
    }
}