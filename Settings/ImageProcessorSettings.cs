using ImageProcessor.Web.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoCaster.ImageProcessor.Core.Settings
{
    public static class ImageProcessorSettings
    {
        internal static string ImageProcessorRemotePrefix
        {
            get
            {
                return ImageProcessorConfig.Instance.RemotePrefix;
            }
        }

        internal static Uri[] ImageProcessorRemoteFileWhiteList
        {
            get
            {
                return ImageProcessorConfig.Instance.RemoteFileWhiteList;
            }
        }

        /// <summary>
        /// Set to true to accept remote relative URLs (for instance, when the relative URL gets rewritten by a ResponseFilter afterwards)
        /// </summary>
        public static bool AcceptRemoteRelativeUrls = false;
    }
}
