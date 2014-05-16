using InfoCaster.ImageProcessor.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Models
{
    /// <summary>
    /// The parameter class for the crop processor
    /// </summary>
    public class ImageProcessorCropParameter : IImageProcessorParameter
    {
        /// <summary>
        /// The new topleft's x coordinate
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// The new topleft's y coordinate
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// The new width
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// The new height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="x">The new topleft's x coordinate</param>
        /// <param name="y">The new topleft's y coordinate</param>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        public ImageProcessorCropParameter(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("crop", string.Join(",", new string[] {
                X.ToString(),
                Y.ToString(),
                Width.ToString(),
                Height.ToString()
            }));

            return parameters.ToQueryString();
        }
    }
}
