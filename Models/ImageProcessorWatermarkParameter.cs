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
    public class ImageProcessorWatermarkParameter : IImageProcessorParameter
    {
        /// <summary>
        /// The text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// The color (Hex without the number sign, e.g. 'fff')
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// The font size in pixels
        /// </summary>
        public int? Size { get; set; }
        /// <summary>
        /// The font family (must be installed on the server)
        /// </summary>
        public string FontFamily { get; set; }
        /// <summary>
        /// The opacity (1-100)
        /// </summary>
        public int? Opacity { get; set; }
        /// <summary>
        /// The font style (regular by default)
        /// </summary>
        public ImageProcessorWatermarkFontStyle FontStyle { get; set; }
        /// <summary>
        /// Indicates if the text has shadow
        /// </summary>
        public bool? Shadow { get; set; }
        /// <summary>
        /// The position
        /// </summary>
        public ImageProcessorWatermarkPosition Position { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="color">The color (Hex without the number sign, e.g. 'fff')</param>
        /// <param name="size">The font size in pixels</param>
        /// <param name="fontFamily"> font family (must be installed on the server)</param>
        /// <param name="opacity">The opacity (1-100)</param>
        /// <param name="fontStyle">The font style (regular by default)</param>
        /// <param name="shadow">Indicates if the text has shadow</param>
        /// <param name="position">The position</param>
        public ImageProcessorWatermarkParameter(string text, string color = null, int? size = null, string fontFamily = null, int? opacity = null, ImageProcessorWatermarkFontStyle? fontStyle = null, bool? shadow = null, ImageProcessorWatermarkPosition position = null)
        {
            Text = text;
            Color = color;
            Size = size;
            FontFamily = fontFamily;
            Opacity = opacity;
            if (fontStyle.HasValue)
                FontStyle = fontStyle.Value;
            Shadow = shadow;
            Position = position;
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            string watermark = Text;
            if (!string.IsNullOrEmpty(Color))
                watermark = string.Concat(watermark, ",color-", Color);
            if (Size.HasValue)
                watermark = string.Concat(watermark, ",size-", Size.Value.ToString());
            if (!string.IsNullOrEmpty(FontFamily))
                watermark = string.Concat(watermark, ",font-", FontFamily);
            if (Opacity.HasValue)
                watermark = string.Concat(watermark, ",opacity-", Opacity.Value.ToString());
            watermark = string.Concat(watermark, ",style-", FontStyle.ToString().ToLower());
            if (Shadow.HasValue)
                watermark = string.Concat(watermark, ",shadow-", Shadow.Value.ToString().ToLower());
            if (Position != null)
                watermark = string.Concat(watermark, ",position-", Position.X, ",", Position.Y);
            parameters.Add("watermark", watermark);

            return parameters.ToQueryString();
        }
    }

    /// <summary>
    /// The watermark text styles
    /// </summary>
    public enum ImageProcessorWatermarkFontStyle
    {
        Regular,
        Bold,
        Italic,
        Strikeout,
        Underline
    }

    /// <summary>
    /// The watermark position
    /// </summary>
    public class ImageProcessorWatermarkPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public ImageProcessorWatermarkPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
