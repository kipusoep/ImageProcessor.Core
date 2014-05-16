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
    public class ImageProcessorVignetteParameter : IImageProcessorParameter
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public ImageProcessorVignetteParameter()
        {
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("vignette", true.ToString());

            return parameters.ToQueryString();
        }
    }
}
