using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.ViewPager.Widget;
using PhotoBrowser.Maui.Platforms.Android.ImageGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource = Microsoft.Maui.Resource;

namespace GPSMobile.BA
{
    [Activity(Label = "")]
    public class GallerySlideActivity : Activity
    {
        private GallerySlidePageAdapter _adapter;
        private ViewPager _viewPager;

        protected Android.Widget.ImageButton btnAction;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var uiOptions =
                        SystemUiFlags.HideNavigation |
                        SystemUiFlags.LayoutHideNavigation |
                        SystemUiFlags.LayoutFullscreen |
                        SystemUiFlags.Fullscreen |
                        SystemUiFlags.LayoutStable |
                        SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;

            SetContentView(Resource.Layout.gallery_slide);
            Intent myIntent = this.Intent;
            var items = myIntent.GetStringArrayListExtra("PhotoBrowser");
            if (items != null && items.Count > 0)
            {
                InitComponents(items.ToList());
            }
        }

        protected void InitComponents(List<string> urls)
        {

            _adapter = new GallerySlidePageAdapter(this, urls);
            _viewPager = FindViewById<ViewPager>(Resource.Id.pager);
            _viewPager.Adapter = _adapter;
            _viewPager.SetCurrentItem(3, false); // start item
            _viewPager.OffscreenPageLimit = 10;
            _viewPager.PageSelected += OnPageSelected;
            _viewPager.PageScrollStateChanged += ViewPager_PageScrollStateChanged;

            btnAction = FindViewById<Android.Widget.ImageButton>(Resource.Id.btnclose);

            btnAction.Click += (o, e) =>
            {
                Finish();
            };
        }

        private void ViewPager_PageScrollStateChanged(object sender, ViewPager.PageScrollStateChangedEventArgs e)
        {
            //if (e.State == ViewPager.ScrollStateIdle) // pseudo-infinite sliding
            //{
            //    var adapter = (InfiniteViewPagerAdapter)_viewPager.Adapter;
            //    var position = _viewPager.CurrentItem;
            //    var realPosition = adapter.ToRealPosition(position);

            //    if (position == 0 || position == adapter.Count - 1)
            //    {
            //        _viewPager.SetCurrentItem(realPosition + 1, false);
            //    }
            //}
        }

        private void OnPageSelected(object s, ViewPager.PageSelectedEventArgs e)
        {
        }
    }
}