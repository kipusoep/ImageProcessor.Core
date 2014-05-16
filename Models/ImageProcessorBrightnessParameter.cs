using InfoCaster.ImageProcessor.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Models
{
    /// <summary>
    /// The parameter class for the brightness processor
    /// </summary>
    public class ImageProcessorBrightnessParameter : IImageProcessorParameter
    {
        /// <summary>
        /// The brightness percentage
        /// </summary>
        public int BrightnessPercentage { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="brightnessPercentage">The brightness percentage</param>
        public ImageProcessorBrightnessParameter(int brightnessPercentage)
        {
            BrightnessPercentage = brightnessPercentage;
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("brightness", BrightnessPercentage.ToString());

            return parameters.ToQueryString();
        }
    }
}
