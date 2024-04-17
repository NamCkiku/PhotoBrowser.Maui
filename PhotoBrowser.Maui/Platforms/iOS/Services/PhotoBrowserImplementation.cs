using Foundation;
using IDMPhotoBrowserBindings;
using UIKit;

namespace PhotoBrowsers.Platforms.iOS
{
    public class PhotoBrowserImplementation : IPhotoBrowser
    {
        protected static MyMWPhotoBrower _mainBrowser;
        public void Show(PhotoBrowser photoBrowser)
        {
            _mainBrowser = new MyMWPhotoBrower(photoBrowser);
            _mainBrowser.Show();
        }
        public void Close()
        {
            if (_mainBrowser != null)
            {
                _mainBrowser.Close();
                _mainBrowser = null;
            }
        }
    }
}