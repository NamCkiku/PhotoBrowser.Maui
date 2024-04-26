using FFImageLoading.Maui;
using Microsoft.Maui.LifecycleEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoBrowsers
{
    public static class Extensions
    {
        public static MauiAppBuilder ConfigurePhotoBrowser(this MauiAppBuilder builder)
        {
#if ANDROID
            builder.Services.AddSingleton<IPhotoBrowser, PhotoBrowsers.Platforms.Android.PhotoBrowserImplementation>();

#elif IOS
            builder.Services.AddSingleton<IPhotoBrowser, PhotoBrowsers.Platforms.iOS.PhotoBrowserImplementation>();
#endif
            builder.Services.AddSingleton<IMauiInitializeService, ServiceHelpers>();
            builder.UseFFImageLoading();
            return builder;
        }
    }
}
    