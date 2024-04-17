using AndroidX.ViewPager.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoBrowser.Maui.Platforms.Android.ImageGallery
{
    public abstract class InfiniteViewPagerAdapter : PagerAdapter
    {
        // Since we want to put 2 additional pages at left & right,
        // the actual size will plus 2.
        public override int Count => RealCount == 0 ? 0 : RealCount + 2;

        public abstract int RealCount { get; }

        public int ToRealPosition(int position)
        {
            var realCount = RealCount;

            if (realCount == 0)
            {
                return 0;
            }

            // Put last page model to the first position.
            if (position == 0)
            {
                return realCount - 1;
            }

            // Put first page model to the last position.
            if (position >= realCount + 1)
            {
                return 0;
            }

            return position - 1;
        }
    }
}