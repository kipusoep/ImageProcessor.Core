using InfoCaster.ImageProcessor.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Models
{
    /// <summary>
    /// The parameter class for the flip processor
    /// </summary>
    public class ImageProcessorFlipParameter : IImageProcessorParameter
    {
        /// <summary>
        /// The flip
        /// </summary>
        public ImageProcessorFlip Flip { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="flip">The flip</param>
        public ImageProcessorFlipParameter(ImageProcessorFlip flip)
        {
            Flip = flip;
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("flip", Flip.ToString().ToLower());

            return parameters.ToQueryString();
        }
    }

    /// <summary>
    /// The flip modes
    /// </summary>
    public enum ImageProcessorFlip
    {
        Horizontal,
        Vertical,
        Both
    }
}
