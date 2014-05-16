using InfoCaster.ImageProcessor.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Models
{
    /// <summary>
    /// The parameter class for the rotate processor
    /// </summary>
    public class ImageProcessorRotateParameter : IImageProcessorParameter
    {
        /// <summary>
        /// The angle
        /// </summary>
        public int Angle { get; set; }
        /// <summary>
        /// The background color (Hex without the number sign, e.g. 'fff')
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="angle">The angle</param>
        /// <param name="backgroundColor">The background color (Hex without the number sign, e.g. 'fff')</param>
        public ImageProcessorRotateParameter(int angle, string backgroundColor = null)
        {
            Angle = angle;
            BackgroundColor = backgroundColor;
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            string angle = Angle.ToString();
            if (!string.IsNullOrEmpty(BackgroundColor))
                angle = string.Format("angle-{0},bgcolor-{1}", Angle.ToString(), BackgroundColor);
            parameters.Add("rotate", angle);

            return parameters.ToQueryString();
        }
    }
}
