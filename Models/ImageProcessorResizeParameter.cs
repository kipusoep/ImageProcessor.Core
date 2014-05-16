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
    public class ImageProcessorResizeParameter : IImageProcessorParameter
    {
        /// <summary>
        /// The new width
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// The new height
        /// </summary>
        public int? Height { get; set; }
        /// <summary>
        /// The resize mode
        /// </summary>
        public ImageProcessorResizeMode? ResizeMode { get; set; }
        /// <summary>
        /// The background color (applies to ResizeMode.Pad) (Hex without the number sign, e.g. 'fff')
        /// </summary>
        public string BackgroundColor { get; set; }
        /// <summary>
        /// The anchor position color (applies to ResizeMode.Crop)
        /// </summary>
        public ImageProcessorAnchorPosition? AnchorPosition { get; set; }
        /// <summary>
        /// To turn off upscaling (this does not affect stretched images)
        /// </summary>
        public bool? Upscale { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <param name="resizeMode">The resize mode (default: ResizeMode.Pad)</param>
        /// <param name="backgroundColor">The background color (applies to ResizeMode.Pad) (Hex without the number sign, e.g. 'fff')</param>
        /// <param name="anchorPosition">The anchor position color (applies to ResizeMode.Crop)</param>
        /// <param name="upscale">To turn off upscaling (this does not affect stretched images)</param>
        public ImageProcessorResizeParameter(int? width = null, int? height = null, ImageProcessorResizeMode? resizeMode = null, string backgroundColor = "", ImageProcessorAnchorPosition? anchorPosition = null, bool? upscale = null)
        {
            if (!width.HasValue && !height.HasValue)
                throw new ArgumentNullException("At least width or height is required");

            Width = width;
            Height = height;
            ResizeMode = resizeMode;
            BackgroundColor = backgroundColor;
            AnchorPosition = anchorPosition;
            Upscale = upscale;
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            if (Width.HasValue)
                parameters.Add("width", Width.Value.ToString());
            if (Height.HasValue)
                parameters.Add("height", Height.Value.ToString());
            if (ResizeMode.HasValue)
                parameters.Add("mode", ResizeMode.Value.ToString().ToLower());
            if (!string.IsNullOrEmpty(BackgroundColor))
                parameters.Add("bgcolor", BackgroundColor);
            if (AnchorPosition.HasValue)
                parameters.Add("anchor", AnchorPosition.Value.ToString().ToLower());
            if (Upscale.HasValue)
                parameters.Add("upscale", Upscale.Value.ToString().ToLower());

            return parameters.ToQueryString();
        }
    }

    /// <summary>
    /// See http://jimbobsquarepants.github.io/ImageProcessor/imageprocessor-web/resize.html for examples of the resize modes
    /// </summary>
    public enum ImageProcessorResizeMode
    {
        Pad,
        Crop,
        Max,
        Stretch
    }

    /// See http://jimbobsquarepants.github.io/ImageProcessor/imageprocessor-web/resize.html for examples of the anchor positions
    public enum ImageProcessorAnchorPosition
    {
        Center,
        Top,
        Right,
        Bottom,
        Left,
    }
}
