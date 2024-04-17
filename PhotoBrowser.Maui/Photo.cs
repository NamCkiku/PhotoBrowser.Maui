namespace PhotoBrowsers
{
    public interface IPhotoBrowser
    {
        void Show(PhotoBrowser photoBrowser);

        void Close();
    }

    // All the code in this file is included in all platforms.
    public class Photo
    {
        public string URL { get; set; }

        public string Title { get; set; }
    }

    public class PhotoBrowser
    {
        public List<Photo> Photos { get; set; }

        public void Show()
        {
            ServiceHelpers.GetService<IPhotoBrowser>().Show(this);
        }

        public static void Close()
        {
            ServiceHelpers.GetService<IPhotoBrowser>().Close();
        }
    }
}