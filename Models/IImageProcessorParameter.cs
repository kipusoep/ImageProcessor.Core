using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Models
{
    /// <summary>
    /// Interface for ImageProcessor parameters
    /// </summary>
    public interface IImageProcessorParameter
    {
        /// <summary>
        /// Returns the query string representation of this processor's value(s)
        /// </summary>
        /// <returns></returns>
        string ToQueryString();
    }
}
