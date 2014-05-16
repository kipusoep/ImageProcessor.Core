using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace InfoCaster.ImageProcessor.Core.Extensions
{
    /// <summary>
    /// Provides extension methods for collections
    /// </summary>
    internal static class CollectionExtensions
    {
        /// <summary>
        /// Returns the query string representation of a NameValueCollection
        /// </summary>
        /// <param name="parameters">The NameValueCollection</param>
        /// <returns>The query string</returns>
        public static string ToQueryString(this NameValueCollection parameters)
        {
            List<string> items = new List<string>();

            foreach (string name in parameters)
                items.Add(string.Concat(name, "=", System.Web.HttpUtility.UrlEncode(parameters[name])));

            return string.Join("&", items.ToArray());
        }
    }
}
