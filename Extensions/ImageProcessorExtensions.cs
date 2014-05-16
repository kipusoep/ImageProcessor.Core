using InfoCaster.ImageProcessor.Core.Models;
using InfoCaster.ImageProcessor.Core.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Extensions
{
    /// <summary>
    /// Extension methods for ImageProcessor
    /// </summary>
    public static class ImageProcessorExtensions
    {
        /// <summary>
        /// Get the ImageProcessor URL for the given image URL and ImageProcessorParameters
        /// </summary>
        /// <param name="imageUrl">The image URL</param>
        /// <param name="imageProcessorParameters">The ImageProcessorParameters</param>
        /// <returns>The ImageProcessor URL</returns>
        public static string GetImageProcessorUrl(this Uri imageUrl, params IImageProcessorParameter[] imageProcessorParameters)
        {
            return string.Concat(imageUrl, "?", imageProcessorParameters.ToImageProcessorParametersQueryString());
        }

        /// <summary>
        /// Get the ImageProcessor URL for the given remote image URL and ImageProcessorParameters
        /// </summary>
        /// <param name="imageUrl">The remote image URL</param>
        /// <param name="imageProcessorParameters">The ImageProcessorParameters</param>
        /// <returns>The ImageProcessor URL</returns>
        public static string GetImageProcessorRemoteUrl(this Uri imageUrl, params IImageProcessorParameter[] imageProcessorParameters)
        {
            CheckSafeUrlLocation(imageUrl);
            return string.Concat(ImageProcessorSettings.ImageProcessorRemotePrefix, "?", GetImageProcessorUrl(imageUrl, imageProcessorParameters));
        }

        /// <summary>
        /// Get the ImageProcessor resize URL for the given image URL
        /// </summary>
        /// <param name="imageUrl">The image URL</param>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <param name="resizeMode">The resize mode (default: ResizeMode.Pad)</param>
        /// <returns>The ImageProcessor resize URL</returns>
        public static string GetImageProcessorResizeUrl(this Uri imageUrl, int? width = null, int? height = null, ImageProcessorResizeMode? resizeMode = null)
        {
            return imageUrl.GetImageProcessorUrl(new ImageProcessorResizeParameter(width, height, resizeMode));
        }

        /// <summary>
        /// Get the ImageProcessor URL for the given image URL and ImageProcessorParameters
        /// </summary>
        /// <param name="imageUrl">The image URL</param>
        /// <param name="imageProcessorParameters">The ImageProcessorParameters</param>
        /// <returns>The ImageProcessor URL</returns>
        public static string GetImageProcessorUrl(this string imageUrl, params IImageProcessorParameter[] imageProcessorParameters)
        {
            return string.Concat(imageUrl, "?", imageProcessorParameters.ToImageProcessorParametersQueryString());
        }

        /// <summary>
        /// Get the ImageProcessor URL for the given remote image URL and ImageProcessorParameters
        /// </summary>
        /// <param name="imageUrl">The remote image URL</param>
        /// <param name="imageProcessorParameters">The ImageProcessorParameters</param>
        /// <returns>The ImageProcessor URL</returns>
        public static string GetImageProcessorRemoteUrl(this string imageUrl, params IImageProcessorParameter[] imageProcessorParameters)
        {
            Uri imageUri;
            if (!Uri.TryCreate(imageUrl, UriKind.RelativeOrAbsolute, out imageUri))
                throw new UriFormatException(string.Format("Invalid URI: The format of the URI could not be determined ({0})", imageUrl));

            CheckSafeUrlLocation(imageUri);
            return string.Concat(ImageProcessorSettings.ImageProcessorRemotePrefix, "?", GetImageProcessorUrl(imageUrl, imageProcessorParameters));
        }

        /// <summary>
        /// Get the ImageProcessor resize URL for the given image URL
        /// </summary>
        /// <param name="imageUrl">The image URL</param>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <param name="resizeMode">The resize mode (default: ResizeMode.Pad)</param>
        /// <returns>The ImageProcessor resize URL</returns>
        public static string GetImageProcessorResizeUrl(this string imageUrl, int? width = null, int? height = null, ImageProcessorResizeMode? resizeMode = null)
        {
            return imageUrl.GetImageProcessorUrl(new ImageProcessorResizeParameter(width, height, resizeMode));
        }

        static string ToImageProcessorParametersQueryString(this IImageProcessorParameter[] imageProcessorParameters)
        {
            string paramsString = string.Empty;
            foreach (IImageProcessorParameter param in imageProcessorParameters)
            {
                paramsString = string.Concat(paramsString, param.ToQueryString(), "&");
            }
            return paramsString.Trim('&');
        }

        static void CheckSafeUrlLocation(Uri url)
        {
            if (ImageProcessorSettings.AcceptRemoteRelativeUrls)
                return;
            if (!url.IsAbsoluteUri)
                throw new InvalidOperationException("The provided URL should be absolute, or set ImageProcessorSettings.AcceptRemoteRelativeUrls to true");
            if (!ImageProcessorSettings.ImageProcessorRemoteFileWhiteList.Any(item => item.Host.ToUpperInvariant() == url.Host.ToUpperInvariant()))
                throw new SecurityException(string.Format("Application is not configured to allow remote file downloads from this domain ({0}://{1})", url.Scheme, url.Host));
        }
    }
}
