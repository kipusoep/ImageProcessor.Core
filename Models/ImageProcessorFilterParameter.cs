using InfoCaster.ImageProcessor.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Models
{
    /// <summary>
    /// The parameter class for the filter processor
    /// </summary>
    public class ImageProcessorFilterParameter : IImageProcessorParameter
    {
        /// <summary>
        /// The filter
        /// </summary>
        public ImageProcessorFilter Filter { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="filter">The filter</param>
        public ImageProcessorFilterParameter(ImageProcessorFilter filter)
        {
            Filter = filter;
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("filter", Filter.ToString().ToLower());

            return parameters.ToQueryString();
        }
    }

    /// <summary>
    /// See http://jimbobsquarepants.github.io/ImageProcessor/imageprocessor-web/filter.html for examples of the filters
    /// </summary>
    public enum ImageProcessorFilter
    {
        BlackWhite,
        Comic,
        Lomograph,
        Greyscale,
        Polaroid,
        Sepia,
        Gotham,
        Hisatch,
        Losatch,
        Invert,
    }
}
