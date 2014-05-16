using InfoCaster.ImageProcessor.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Models
{
    /// <summary>
    /// The parameter class for the format processor
    /// </summary>
    public class ImageProcessorFormatParameter : IImageProcessorParameter
    {
        /// <summary>
        /// The format
        /// </summary>
        public ImageProcessorFormat Format { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="format">The format</param>
        public ImageProcessorFormatParameter(ImageProcessorFormat format)
        {
            Format = format;
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("format", Format.ToString().ToLower());

            return parameters.ToQueryString();
        }
    }

    /// <summary>
    /// The formats
    /// </summary>
    public enum ImageProcessorFormat
    {
        Jpg,
        Bmp,
        Gif,
        Png,
        Png8,
        Tif,
    }
}
