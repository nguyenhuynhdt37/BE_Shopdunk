using System;
using BE_Shopdunk.Service;

namespace BE_Shopdunk.Utils
{
    public static class MyLibrary
    {
        private static UrlService? _urlService;

        public static void Initialize(UrlService urlService)
        {
            _urlService = urlService;
        }

        public static string? GetLinkImage(string? image)
        {
            if (_urlService == null)
            {
                throw new InvalidOperationException("MyLibrary is not initialized. Call Initialize() method first.");
            }
            if (image == null) return null;
            return $"{_urlService.GetHostUrl()}{image}";
        }


    }
}