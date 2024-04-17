using Foundation;
using IDMPhotoBrowserBindings;
using UIKit;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace PhotoBrowsers.Platforms.iOS
{
    public class PhotoBrowserImplementation : IPhotoBrowser
    {
        public void Show(PhotoBrowser photoBrowser)
        {
            var photos = photoBrowser.Photos.Select(x => new IDMPhoto(NSUrl.FromString(x.URL)!)).ToArray();
            var browser = new IDMPhotoBrowser(photos);
            browser.Title = "";
            browser.UsePopAnimation = true;
            browser.UsePopAnimation = true;
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            while (vc.PresentedViewController != null)
            {
                vc = vc.PresentedViewController;
            }

            vc.PresentViewController(new UINavigationController(browser), true, null);
        }
        public void Close()
        {
            UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
        }
    }
}