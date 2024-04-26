using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Com.Davemorrissey.Labs.Subscaleview;
using System.Net;
using JObject = Java.Lang.Object;

namespace PhotoBrowser.Maui.Platforms.Android.ImageGallery
{
    public class GallerySlidePageAdapter : InfiniteViewPagerAdapter
    {
        private const int MaxZoom = 10;

        private readonly IList<string> _pages;
        private readonly LayoutInflater _inflater;
        public GallerySlidePageAdapter(Context context, IList<string> images)
        {
            _pages = images;
            _inflater = LayoutInflater.From(context);
        }

        public override int RealCount => _pages.Count;

        public override bool IsViewFromObject(global::Android.Views.View view, JObject obj)
        {
            return view == obj;
        }

        public override JObject InstantiateItem(ViewGroup container, int position)
        {
            var listPosition = ToRealPosition(position);

            global::Android.Views.View convertView;
            {
                convertView = _inflater.Inflate(Resource.Layout.gallery_image, null);
                BindView(convertView, listPosition);
                container.AddView(convertView);
            }

            return convertView;
        }

        public override void DestroyItem(ViewGroup container, int position, JObject view)
        {
            container.RemoveView((global::Android.Views.View)view);
        }

        private async void BindView(global::Android.Views.View view, int listPosition)
        {
            var galleryImageView = view.FindViewById<Com.Davemorrissey.Labs.Subscaleview.SubsamplingScaleImageView>(Resource.Id.galleryImageView);
            galleryImageView.SetMinimumDpi(MaxZoom);

            var imageUrl = _pages[listPosition];
            var bitmap = await GetImageBitmapFromUrl(imageUrl);
            galleryImageView.SetImage(Com.Davemorrissey.Labs.Subscaleview.ImageSource.ForBitmap(bitmap));
            var activityIndicatorView = view.FindViewById<global::Android.Widget.ProgressBar>(Resource.Id.activityIndicatorView);
            if (!galleryImageView.IsImageLoaded)
            {
                activityIndicatorView.Visibility = ViewStates.Visible;
            }
            galleryImageView.ImageLoaded += (s, e) =>
            {
                if (galleryImageView.IsImageLoaded)
                {
                    activityIndicatorView.Visibility = ViewStates.Gone;
                }
            };
            galleryImageView.Click += GalleryImageView_Click;
        }

        private async Task<Bitmap> GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new HttpClient())
            {
                var imageBytes = await webClient.GetByteArrayAsync(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        private void GalleryImageView_Click(object sender, EventArgs e)
        {

        }
    }
}
