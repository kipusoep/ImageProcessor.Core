using InfoCaster.ImageProcessor.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Models
{
    /// <summary>
    /// The parameter class for the contrast processor
    /// </summary>
    public class ImageProcessorContrastParameter : IImageProcessorParameter
    {
        /// <summary>
        /// The contrast percentage
        /// </summary>
        public int ContrastPercentage { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="contrastPercentage">The contrast percentage</param>
        public ImageProcessorContrastParameter(int contrastPercentage)
        {
            ContrastPercentage = contrastPercentage;
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("contrast", ContrastPercentage.ToString());

            return parameters.ToQueryString();
        }
    }
}
