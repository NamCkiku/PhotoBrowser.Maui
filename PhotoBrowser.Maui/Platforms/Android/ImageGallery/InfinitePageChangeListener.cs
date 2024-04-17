using AndroidX.ViewPager.Widget;
using JObject = Java.Lang.Object;

namespace PhotoBrowser.Maui.Platforms.Android.ImageGallery
{
    public class InfinitePageChangeListener : JObject, ViewPager.IOnPageChangeListener
    {
        private readonly ViewPager _viewPager;

        public InfinitePageChangeListener(ViewPager viewPager)
        {
            _viewPager = viewPager;
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
        }

        public void OnPageSelected(int position)
        {
        }

        public void OnPageScrollStateChanged(int state)
        {
            if (state == ViewPager.ScrollStateIdle)
            {
                var adapter = (InfiniteViewPagerAdapter)_viewPager.Adapter;
                var position = _viewPager.CurrentItem;
                var realPosition = adapter.ToRealPosition(position);

                if (position == 0 || position == adapter.Count - 1)
                {
                    _viewPager.SetCurrentItem(realPosition + 1, false);
                }
            }
        }
    }
}