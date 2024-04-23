using System;
using UIKit;
using Foundation;
using ObjCRuntime;

namespace IDMPhotoBrowserBindings
{

    [BaseType(typeof(NSObject))]
    interface IDMPhoto
    {
        [Export("initWithURL:")]
        IntPtr Constructor(NSUrl url);
    }

    [BaseType(typeof(UIViewController))]
    interface IDMPhotoBrowser
    {
        [Export("initWithPhotos:animatedFromView:")]
        IntPtr Constructor(IDMPhoto[] photos, UIView view);

        [Export("initWithPhotos:")]
        IntPtr Constructor(IDMPhoto[] photos);

        [Export("displayToolbar")]
        bool DisplayToolbar { get; set; }

        [Export("usePopAnimation")]
        bool UsePopAnimation { get; set; }

        [Export("setInitialPageIndex:")]
        void SetInitialPageIndex(uint index);

        [Export("disableVerticalSwipe")]
        bool DisableVerticalSwipe { get; set; }

        [Export("displayDoneButton")]
        bool DisplayDoneButton { get; set; }

        [Wrap("WeakDelegate")]
        IDMPhotoBrowserDelegate Delegate { get; set; }

        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }
    }

    [Model, Protocol, BaseType(typeof(NSObject))]
    interface IDMPhotoBrowserDelegate
    {
        [Export("photoBrowser:didDismissAtPageIndex:")]
        void OnDismissed(IDMPhotoBrowser controller, nuint index);

        [Export("photoBrowser:willDismissAtPageIndex:")]
        void WillDismiss(IDMPhotoBrowser controller, nuint index);

        [Export("willDisappearPhotoBrowser:")]
        void WillDisappearPhotoBrowser(IDMPhotoBrowser controller);
    }
}
