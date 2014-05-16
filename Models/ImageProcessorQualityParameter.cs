using InfoCaster.ImageProcessor.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Models
{
    /// <summary>
    /// The parameter class for the quality processor
    /// </summary>
    /// <remarks>
    /// This processor will only effect the output quality of jpeg images
    /// </remarks>
    public class ImageProcessorQualityParameter : IImageProcessorParameter
    {
        /// <summary>
        /// The quality
        /// </summary>
        public int Quality { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="quality">The quality</param>
        public ImageProcessorQualityParameter(int quality)
        {
            Quality = quality;
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("quality", Quality.ToString());

            return parameters.ToQueryString();
        }
    }
}
