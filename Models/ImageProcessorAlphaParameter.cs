using InfoCaster.ImageProcessor.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Models
{
    /// <summary>
    /// The parameter class for the alpha processor
    /// </summary>
    public class ImageProcessorAlphaParameter : IImageProcessorParameter
    {
        /// <summary>
        /// The alpha percentage
        /// </summary>
        public int AlphaPercentage { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="alphaPercentage">The alpha percentage</param>
        public ImageProcessorAlphaParameter(int alphaPercentage)
        {
            AlphaPercentage = alphaPercentage;
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("alpha", AlphaPercentage.ToString());

            return parameters.ToQueryString();
        }
    }
}
