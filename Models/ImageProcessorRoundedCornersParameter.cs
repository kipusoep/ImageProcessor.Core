using InfoCaster.ImageProcessor.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Models
{
    /// <summary>
    /// The parameter class for the resize processor
    /// </summary>
    public class ImageProcessorRoundedCornersParameter : IImageProcessorParameter
    {
        /// <summary>
        /// The radius
        /// </summary>
        public int Radius { get; set; }
        /// <summary>
        /// The background color (Hex without the number sign, e.g. 'fff')
        /// </summary>
        public string BackgroundColor { get; set; }
        /// <summary>
        /// Whether or not to round the top left corner
        /// </summary>
        public bool? TopLeft { get; set; }
        /// <summary>
        /// Whether or not to round the top right corner
        /// </summary>
        public bool? TopRight { get; set; }
        /// <summary>
        /// Whether or not to round the bottom left corner
        /// </summary>
        public bool? BottomLeft { get; set; }
        /// <summary>
        /// Whether or not to round the bottom right corner
        /// </summary>
        public bool? BottomRight { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <param name="backgroundColor">The background color (Hex without the number sign, e.g. 'fff')</param>
        /// <param name="topLeft">Whether or not to round the top left corner</param>
        /// <param name="topRight">Whether or not to round the top right corner</param>
        /// <param name="bottomLeft">Whether or not to round the bottom left corner</param>
        /// <param name="bottomRight">Whether or not to round the bottom right corner</param>
        public ImageProcessorRoundedCornersParameter(int radius, string backgroundColor = null, bool? topLeft = null, bool? topRight = null, bool? bottomLeft = null, bool? bottomRight = null)
        {
            Radius = radius;
            BackgroundColor = backgroundColor;
            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            string radius = Radius.ToString();
            if (!string.IsNullOrEmpty(BackgroundColor) || TopLeft.HasValue || TopRight.HasValue || BottomLeft.HasValue || BottomRight.HasValue)
            {
                radius = string.Concat("radius-", Radius.ToString());
                if (!string.IsNullOrEmpty(BackgroundColor))
                    radius = string.Concat(radius, "|bgcolor-", BackgroundColor);
                if (TopLeft.HasValue)
                    radius = string.Concat(radius, "|tl-", TopLeft.Value.ToString().ToLower());
                if (TopRight.HasValue)
                    radius = string.Concat(radius, "|tr-", TopRight.Value.ToString().ToLower());
                if (BottomLeft.HasValue)
                    radius = string.Concat(radius, "|bl-", BottomLeft.Value.ToString().ToLower());
                if (BottomRight.HasValue)
                    radius = string.Concat(radius, "|br-", BottomRight.Value.ToString().ToLower());
            }
            parameters.Add("roundedcorners", radius);

            return parameters.ToQueryString();
        }
    }
}
