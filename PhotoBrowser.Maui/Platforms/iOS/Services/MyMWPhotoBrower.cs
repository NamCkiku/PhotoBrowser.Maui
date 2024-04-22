using IDMPhotoBrowserBindings;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Platform;
using MWPhotoBrowsers;
using PhotoBrowsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace PhotoBrowsers.Platforms.iOS
{
    public class MyMWPhotoBrower : IDMPhotoBrowserDelegate
    {
        protected PhotoBrowser _photoBrowser;

        protected List<IDMPhoto> _photos = new List<IDMPhoto>();

        public MyMWPhotoBrower(PhotoBrowser photoBrowser)
        {
            _photoBrowser = photoBrowser;
        }

        public void Show()
        {
            _photos = new List<IDMPhoto>();

            foreach (Photo p in _photoBrowser.Photos)
            {
                IDMPhoto mp =new IDMPhoto(new Foundation.NSUrl(p.URL));

                _photos.Add(mp);
            }

            IDMPhotoBrowser browser = new IDMPhotoBrowser(_photos.ToArray());
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            while (vc.PresentedViewController != null)
            {
                vc = vc.PresentedViewController;
            }

            vc.PresentViewController(new UINavigationController(browser), true, null);
        }
        public override void OnDismissed(IDMPhotoBrowser controller, nuint index)
        {
            base.OnDismissed(controller, index);
        }

        //public override MWPhoto GetPhoto(MWPhotoBrowser photoBrowser, nuint index) => _photos[(int)index];

        //public override nuint NumberOfPhotosInPhotoBrowser(MWPhotoBrowser photoBrowser) => (nuint)_photos.Count;
 
        public void Close()
        {
            UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
        }
    }
}
