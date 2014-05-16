using InfoCaster.ImageProcessor.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Models
{
    /// <summary>
    /// The parameter class for the saturation processor
    /// </summary>
    public class ImageProcessorSaturationParameter : IImageProcessorParameter
    {
        /// <summary>
        /// The saturation percentage
        /// </summary>
        public int SaturationPercentage { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="saturationPercentage">The saturation percentage</param>
        public ImageProcessorSaturationParameter(int saturationPercentage)
        {
            SaturationPercentage = saturationPercentage;
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("saturation", SaturationPercentage.ToString());

            return parameters.ToQueryString();
        }
    }
}
