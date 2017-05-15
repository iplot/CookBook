using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace CookBook.Utils
{
    public static class Extensions
    {
        public static string EncodeSpecialCharacters(this string target)
        {
            return WebUtility.HtmlEncode(target);
        }

        public static string DecodeSpecialCharacters(this string target)
        {
            return WebUtility.HtmlDecode(target);
        }

        public static string CleanFromHTML(this string target)
        {
            return Regex.Replace(target, "<[^>]*>", string.Empty);
        }
    }
}