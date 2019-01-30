using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using XamlAnimatedGif;

namespace WpfApp7
{
    public class ImageContentResult
    {
        public string ContentType { get; set; }
        public bool IsAvailable { get; set; }

        public ImageContentResult(string contentType, bool isAvailable)
        {
            ContentType = contentType;
            IsAvailable = isAvailable;
        }

        public static ImageContentResult NotAvailableContent => new ImageContentResult("", false);
    }

    public static class ImageHelper
    {
        private static readonly List<Image> _img = new List<Image>();

        public static Image Create(string imageUri, Size? imgSize)
        {
            var image = new Image();
            AnimationBehavior.SetSourceUri(image, new Uri(imageUri));
            _img?.Add(image);
            return image;
        }

        public static void Dispose()
        {
            if (_img?.Count == 0) return;
            if (_img != null) AnimationBehavior.SetSourceUri(_img[0], null);
        }
    }
}
