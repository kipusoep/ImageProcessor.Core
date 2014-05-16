using InfoCaster.ImageProcessor.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Models
{
    /// <summary>
    /// The parameter class for the preset processor
    /// </summary>
    public class ImageProcessorPresetParameter : IImageProcessorParameter
    {
        /// <summary>
        /// The preset
        /// </summary>
        public string Preset { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="preset">The preset</param>
        public ImageProcessorPresetParameter(string preset)
        {
            Preset = preset;
        }

        /// <summary>
        /// Returns the query string representation of this processor's values
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("preset", Preset);

            return parameters.ToQueryString();
        }
    }
}
