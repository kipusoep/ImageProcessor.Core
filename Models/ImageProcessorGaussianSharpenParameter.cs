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
    /// The parameter class for the gaussian sharpen processor
    /// </summary>
    public class ImageProcessorGaussianSharpenParameter : IImageProcessorParameter
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
        public ImageProcessorGaussianSharpenParameter(int blur, int? sigma = null, int? threshold = null)
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
            string sharpen = Blur.ToString();
            if (Sigma.HasValue)
                sharpen = string.Concat(sharpen, ",sigma-", Sigma.Value.ToString(CultureInfo.InvariantCulture));
            if (Threshold.HasValue)
                sharpen = string.Concat(sharpen, ",threshold-", Threshold.Value.ToString());
            parameters.Add("sharpen", sharpen);

            return parameters.ToQueryString();
        }
    }
}
