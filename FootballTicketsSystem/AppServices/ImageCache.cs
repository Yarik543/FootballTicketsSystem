using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace FootballTicketsSystem.Helpers
{
    public static class ImageCache
    {
        private static readonly Dictionary<string, Image> _cache = new Dictionary<string, Image>();
        private static readonly object _lock = new object();

        public static Image GetImage(string url)
        {
            if (string.IsNullOrEmpty(url)) return null;

            lock (_lock)
            {
                if (_cache.TryGetValue(url, out Image cachedImage))
                {
                    // Возвращаем копию, чтобы избежать конфликтов Dispose
                    return new Bitmap(cachedImage);
                }
            }
            return null;
        }

        public static void AddImage(string url, Image image)
        {
            if (string.IsNullOrEmpty(url) || image == null) return;

            lock (_lock)
            {
                if (!_cache.ContainsKey(url))
                {
                    _cache[url] = new Bitmap(image);
                }
            }
        }

        public static void Clear()
        {
            lock (_lock)
            {
                foreach (var img in _cache.Values)
                {
                    img?.Dispose();
                }
                _cache.Clear();
            }
        }
    }
}