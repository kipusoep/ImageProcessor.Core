using InfoCaster.ImageProcessor.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Models
{
    /// <summary>
    /// The parameter class for the gaussian blur processor
    /// </summary>
    public class ImageProcessorGaussianBlurParameter : IImageProcessorParameter
    {
        /// <summary>
        /// The blur
        /// </summary>
        public int Blur { get; set; }
        /// <summary>
        /// The sigma
        /// </summary>
        public double? Sigma { get; set; }
        /// <summary>
        /// The threshold
        /// </summary>
        public int? Threshold { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="blur">The blur</param>
        /// <param name="sigma">The sigma</param>
        /// <param name="threshold">The threshold</param>
        public ImageProcessorGaussianBlurParameter(int blur, int? sigma = null, int? threshold = null)
        {
            Blur = blur;
            Sigma = sigma;
            Threshold = threshold;
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            string blur = Blur.ToString();
            if (Sigma.HasValue)
                blur = string.Concat(blur, ",sigma-", Sigma.Value.ToString(CultureInfo.InvariantCulture));
            if (Threshold.HasValue)
                blur = string.Concat(blur, ",threshold-", Threshold.Value.ToString());
            parameters.Add("blur", blur);

            return parameters.ToQueryString();
        }
    }
}
