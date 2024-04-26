//using Com.Davemorrissey.Labs.Subscaleview;
//using FFImageLoading.Drawables;
//using FFImageLoading.Work;

//namespace PhotoBrowser.Maui.Platforms.Android.ImageGallery
//{
//    public class SImageViewTarget : ITarget<SelfDisposingBitmapDrawable, Com.Davemorrissey.Labs.Subscaleview.SubsamplingScaleImageView>
//    {
//        public SImageViewTarget(Com.Davemorrissey.Labs.Subscaleview.SubsamplingScaleImageView imageView)
//        {
//            Control = imageView;
//        }

//        public Com.Davemorrissey.Labs.Subscaleview.SubsamplingScaleImageView Control { get; }

//        public bool IsValid => true;

//        public object TargetControl => Control;

//        public void Set(IImageLoaderTask task, SelfDisposingBitmapDrawable image, bool animated)
//        {
//            var source = Com.Davemorrissey.Labs.Subscaleview.ImageSource.ForBitmap(image.Bitmap);
//            Control.SetImage(source);
//        }

//        public void SetAsEmpty(IImageLoaderTask task)
//        {
//        }
//    }
//}