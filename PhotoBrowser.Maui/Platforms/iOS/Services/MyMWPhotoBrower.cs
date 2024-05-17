using MWPhotoBrowserBinding;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Platform;
using PhotoBrowsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace PhotoBrowsers.Platforms.iOS
{
    public class MyMWPhotoBrower : PhotoBrowserDelegate
    {
        protected PhotoBrowser _photoBrowser;

        protected List<PhotoBrowserPhoto> _photos = new List<PhotoBrowserPhoto>();

        public MyMWPhotoBrower(PhotoBrowser photoBrowser)
        {
            _photoBrowser = photoBrowser;
        }

        public void Show()
        {
            _photos = new List<PhotoBrowserPhoto>();

            foreach (Photo p in _photoBrowser.Photos)
            {
                PhotoBrowserPhoto mp = PhotoBrowserPhoto.FromUrl(new Foundation.NSUrl(p.URL));

                if (!string.IsNullOrWhiteSpace(p.Title))
                    mp.Caption = p.Title;

                _photos.Add(mp);
            }

            MWPhotoBrowser browser = new MWPhotoBrowser(this)
            {
                EnableGrid = false,
                ZoomPhotosToFill = true,
                DisplaySelectionButtons = false,
                DisplayActionButton = true,
                AlwaysShowControls = true,
                DisplayNavArrows=true,
            };

            browser.EnableSwipeToDismiss = false;

            browser.CurrentIndex = (nuint)_photoBrowser.StartIndex;


            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            while (vc.PresentedViewController != null)
            {
                vc = vc.PresentedViewController;
            }

            vc.PresentViewController(new UINavigationController(browser), true, null);
        }

        public override PhotoBrowserPhoto GetPhoto(MWPhotoBrowser photoBrowser, nuint index) => _photos[(int)index];

        public override nuint GetPhotoCount(MWPhotoBrowser photoBrowser) => (nuint)_photos.Count;

        public override IPhoto GetThumbnail(MWPhotoBrowser photoBrowser, nuint index)
        {
            return base.GetThumbnail(photoBrowser, index);
        }

        public override bool IsPhotoSelected(MWPhotoBrowser photoBrowser, nuint index)
        {
            return base.IsPhotoSelected(photoBrowser, index);
        }

        public override void OnSelectedChanged(MWPhotoBrowser photoBrowser, nuint index, bool selected)
        {
            Console.WriteLine("Photo at index {0} selected ? {1}.", index, selected);
        }

        public override void DidDisplayPhoto(MWPhotoBrowser photoBrowser, nuint index)
        {
            Console.WriteLine("Did start viewing photo at index {0}.", index);
        }

        public void Close()
        {
            UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
        }
    }
}
