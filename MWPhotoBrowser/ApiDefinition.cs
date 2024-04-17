using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using Photos;
using UIKit;

namespace MWPhotoBrowser
{
    // @protocol MWPhoto <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IMWPhoto
    {
        // @required @property (nonatomic, strong) UIImage * underlyingImage;
        [Abstract]
        [Export("underlyingImage", ArgumentSemantic.Strong)]
        UIImage UnderlyingImage { get; set; }

        // @required -(void)loadUnderlyingImageAndNotify;
        [Abstract]
        [Export("loadUnderlyingImageAndNotify")]
        void LoadUnderlyingImageAndNotify();

        // @required -(void)performLoadUnderlyingImageAndNotify;
        [Abstract]
        [Export("performLoadUnderlyingImageAndNotify")]
        void PerformLoadUnderlyingImageAndNotify();

        // @required -(void)unloadUnderlyingImage;
        [Abstract]
        [Export("unloadUnderlyingImage")]
        void UnloadUnderlyingImage();

        // @optional @property (nonatomic) BOOL emptyImage;
        [Export("emptyImage")]
        bool EmptyImage { get; set; }

        // @optional @property (nonatomic) BOOL isVideo;
        [Export("isVideo")]
        bool IsVideo { get; set; }

        // @optional -(void)getVideoURL:(void (^)(NSURL *))completion;
        [Export("getVideoURL:")]
        void GetVideoURL(Action<NSUrl> completion);

        // @optional -(NSString *)caption;
        [Export("caption")]
        string Caption { get; }

        // @optional -(void)cancelAnyLoading;
        [Export("cancelAnyLoading")]
        void CancelAnyLoading();
    }

    // @interface MWPhoto : NSObject <MWPhoto>
    [BaseType(typeof(NSObject))]
    interface MWPhoto : IMWPhoto
    {
        // @property (nonatomic, strong) NSString * caption;
        [Export("caption", ArgumentSemantic.Strong)]
        string Caption { get; set; }

        // @property (nonatomic, strong) NSURL * videoURL;
        [Export("videoURL", ArgumentSemantic.Strong)]
        NSUrl VideoURL { get; set; }

        // @property (nonatomic) BOOL emptyImage;
        [Export("emptyImage")]
        bool EmptyImage { get; set; }

        // @property (nonatomic) BOOL isVideo;
        [Export("isVideo")]
        bool IsVideo { get; set; }

        // +(MWPhoto *)photoWithImage:(UIImage *)image;
        [Static]
        [Export("photoWithImage:")]
        MWPhoto FromImage(UIImage image);

        // +(MWPhoto *)photoWithURL:(NSURL *)url;
        [Static]
        [Export("photoWithURL:")]
        MWPhoto FromUrl(NSUrl url);

        // +(MWPhoto *)photoWithAsset:(PHAsset *)asset targetSize:(CGSize)targetSize;
        [Static]
        [Export("photoWithAsset:targetSize:")]
        MWPhoto FromPhotoAsset(PHAsset asset, CGSize targetSize);

        // +(MWPhoto *)videoWithURL:(NSURL *)url;
        [Static]
        [Export("videoWithURL:")]
        MWPhoto FromVideoUrl(NSUrl url);
    }

    // @protocol MWPhotoBrowserDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MWPhotoBrowserDelegate
    {
        // @required -(NSUInteger)numberOfPhotosInPhotoBrowser:(MWPhotoBrowser *)photoBrowser;
        [Abstract]
        [Export("numberOfPhotosInPhotoBrowser:")]
        nuint NumberOfPhotosInPhotoBrowser(MWPhotoBrowser photoBrowser);

        // @required -(id<MWPhoto>)photoBrowser:(MWPhotoBrowser *)photoBrowser photoAtIndex:(NSUInteger)index;
        [Abstract]
        [Export("photoBrowser:photoAtIndex:")]
        MWPhoto GetPhoto(MWPhotoBrowser photoBrowser, nuint index);

        // @optional -(id<MWPhoto>)photoBrowser:(MWPhotoBrowser *)photoBrowser thumbPhotoAtIndex:(NSUInteger)index;
        [Export("photoBrowser:thumbPhotoAtIndex:")]
        MWPhoto GetThumbnail(MWPhotoBrowser photoBrowser, nuint index);

        // @optional -(MWCaptionView *)photoBrowser:(MWPhotoBrowser *)photoBrowser captionViewForPhotoAtIndex:(NSUInteger)index;
        [Export("photoBrowser:captionViewForPhotoAtIndex:")]
        MWCaptionView GetCaptionViewForPhoto(MWPhotoBrowser photoBrowser, nuint index);

        // @optional -(NSString *)photoBrowser:(MWPhotoBrowser *)photoBrowser titleForPhotoAtIndex:(NSUInteger)index;
        [Export("photoBrowser:titleForPhotoAtIndex:")]
        string GetTitleForPhoto(MWPhotoBrowser photoBrowser, nuint index);

        // @optional -(void)photoBrowser:(MWPhotoBrowser *)photoBrowser didDisplayPhotoAtIndex:(NSUInteger)index;
        [Export("photoBrowser:didDisplayPhotoAtIndex:")]
        void DidDisplayPhoto(MWPhotoBrowser photoBrowser, nuint index);

        // @optional -(void)photoBrowser:(MWPhotoBrowser *)photoBrowser actionButtonPressedForPhotoAtIndex:(NSUInteger)index;
        [Export("photoBrowser:actionButtonPressedForPhotoAtIndex:")]
        void OnActionButtonPressed(MWPhotoBrowser photoBrowser, nuint index);

        // @optional -(BOOL)photoBrowser:(MWPhotoBrowser *)photoBrowser isPhotoSelectedAtIndex:(NSUInteger)index;
        [Export("photoBrowser:isPhotoSelectedAtIndex:")]
        bool IsPhotoSelected(MWPhotoBrowser photoBrowser, nuint index);

        // @optional -(void)photoBrowser:(MWPhotoBrowser *)photoBrowser photoAtIndex:(NSUInteger)index selectedChanged:(BOOL)selected;
        [Export("photoBrowser:photoAtIndex:selectedChanged:")]
        void OnSelectedChanged(MWPhotoBrowser photoBrowser, nuint index, bool selected);

        // @optional -(void)photoBrowserDidFinishModalPresentation:(MWPhotoBrowser *)photoBrowser;
        [Export("photoBrowserDidFinishModalPresentation:")]
        void DidFinishModalPresentation(MWPhotoBrowser photoBrowser);

        // @optional -(void)showActivityViewController:(id)items;
        [Export("showActivityViewController:")]
        void ShowActivityViewController(NSObject items);
    }

    partial interface IMWPhotoBrowserDelegate { }

    // @interface MWPhotoBrowser : UIViewController <UIScrollViewDelegate, UIActionSheetDelegate>
    [BaseType(typeof(UIViewController))]
    interface MWPhotoBrowser : IUIScrollViewDelegate, IUIActionSheetDelegate
    {
        [Wrap("WeakDelegate")]
        MWPhotoBrowserDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MWPhotoBrowserDelegate> delegate __attribute__((iboutlet));
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic) UIColor * browserBackgroundColor;
        [Export("browserBackgroundColor", ArgumentSemantic.Assign)]
        UIColor BrowserBackgroundColor { get; set; }

        // @property (nonatomic) BOOL zoomPhotosToFill;
        [Export("zoomPhotosToFill")]
        bool ZoomPhotosToFill { get; set; }

        // @property (nonatomic) BOOL displayNavArrows;
        [Export("displayNavArrows")]
        bool DisplayNavArrows { get; set; }

        // @property (nonatomic) BOOL displayActionButton;
        [Export("displayActionButton")]
        bool DisplayActionButton { get; set; }

        // @property (nonatomic) BOOL displaySelectionButtons;
        [Export("displaySelectionButtons")]
        bool DisplaySelectionButtons { get; set; }

        // @property (nonatomic) BOOL alwaysShowControls;
        [Export("alwaysShowControls")]
        bool AlwaysShowControls { get; set; }

        // @property (nonatomic) BOOL enableGrid;
        [Export("enableGrid")]
        bool EnableGrid { get; set; }

        // @property (nonatomic) BOOL enableSwipeToDismiss;
        [Export("enableSwipeToDismiss")]
        bool EnableSwipeToDismiss { get; set; }

        // @property (nonatomic) BOOL startOnGrid;
        [Export("startOnGrid")]
        bool StartOnGrid { get; set; }

        // @property (nonatomic) BOOL autoPlayOnAppear;
        [Export("autoPlayOnAppear")]
        bool AutoPlayOnAppear { get; set; }

        // @property (nonatomic) NSUInteger delayToHideElements;
        [Export("delayToHideElements")]
        nuint DelayToHideElements { get; set; }

        // @property (readonly, nonatomic) NSUInteger currentIndex;
        [Export("currentIndex")]
        nuint CurrentIndex { get; }

        // @property (nonatomic, strong) NSString * customImageSelectedIconName;
        [Export("customImageSelectedIconName", ArgumentSemantic.Strong)]
        string CustomImageSelectedIconName { get; set; }

        // @property (nonatomic, strong) NSString * customImageSelectedSmallIconName;
        [Export("customImageSelectedSmallIconName", ArgumentSemantic.Strong)]
        string CustomImageSelectedSmallIconName { get; set; }

        // -(id)initWithPhotos:(NSArray *)photosArray;
        [Export("initWithPhotos:")]
        IntPtr Constructor(MWPhoto[] photosArray);

        // -(id)initWithDelegate:(id<MWPhotoBrowserDelegate>)delegate;
        [Export("initWithDelegate:")]
        IntPtr Constructor(IMWPhotoBrowserDelegate @delegate);

        // -(void)reloadData;
        [Export("reloadData")]
        void ReloadData();

        // -(void)setCurrentPhotoIndex:(NSUInteger)index;
        [Export("setCurrentPhotoIndex:")]
        void SetCurrentPhoto(nuint index);

        // -(void)showNextPhotoAnimated:(BOOL)animated;
        [Export("showNextPhotoAnimated:")]
        void ShowNextPhoto(bool animated);

        // -(void)showPreviousPhotoAnimated:(BOOL)animated;
        [Export("showPreviousPhotoAnimated:")]
        void ShowPreviousPhoto(bool animated);
    }

    // @interface MWGridViewController : UICollectionViewController
    [BaseType(typeof(UICollectionViewController))]
    interface MWGridViewController
    {
        // @property (assign, nonatomic) MWPhotoBrowser * browser;
        [Export("browser", ArgumentSemantic.Assign)]
        MWPhotoBrowser Browser { get; set; }

        // @property (nonatomic) BOOL selectionMode;
        [Export("selectionMode")]
        bool SelectionMode { get; set; }

        // @property (nonatomic) CGPoint initialContentOffset;
        [Export("initialContentOffset", ArgumentSemantic.Assign)]
        CGPoint InitialContentOffset { get; set; }

        // -(void)adjustOffsetsAsRequired;
        [Export("adjustOffsetsAsRequired")]
        void AdjustOffsetsAsRequired();
    }

    // @interface MWTapDetectingImageView : UIImageView
    [BaseType(typeof(UIImageView))]
    interface MWTapDetectingImageView
    {
        [Wrap("WeakTapDelegate")]
        IMWTapDetectingImageViewDelegate TapDelegate { get; set; }

        // @property (nonatomic, weak) id<MWTapDetectingImageViewDelegate> tapDelegate;
        [NullAllowed, Export("tapDelegate", ArgumentSemantic.Weak)]
        NSObject WeakTapDelegate { get; set; }
    }

    // @protocol MWTapDetectingImageViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IMWTapDetectingImageViewDelegate
    {
        // @optional -(void)imageView:(UIImageView *)imageView singleTapDetected:(UITouch *)touch;
        [Export("imageView:singleTapDetected:")]
        void SingleTapDetected(UIImageView imageView, UITouch touch);

        // @optional -(void)imageView:(UIImageView *)imageView doubleTapDetected:(UITouch *)touch;
        [Export("imageView:doubleTapDetected:")]
        void DoubleTapDetected(UIImageView imageView, UITouch touch);

        // @optional -(void)imageView:(UIImageView *)imageView tripleTapDetected:(UITouch *)touch;
        [Export("imageView:tripleTapDetected:")]
        void TripleTapDetected(UIImageView imageView, UITouch touch);
    }

    // @interface MWTapDetectingView : UIView
    [BaseType(typeof(UIView))]
    interface MWTapDetectingView
    {
        [Wrap("WeakTapDelegate")]
        IMWTapDetectingViewDelegate TapDelegate { get; set; }

        // @property (nonatomic, weak) id<MWTapDetectingViewDelegate> tapDelegate;
        [NullAllowed, Export("tapDelegate", ArgumentSemantic.Weak)]
        NSObject WeakTapDelegate { get; set; }
    }

    // @protocol MWTapDetectingViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IMWTapDetectingViewDelegate
    {
        // @optional -(void)view:(UIView *)view singleTapDetected:(UITouch *)touch;
        [Export("view:singleTapDetected:")]
        void SingleTapDetected(UIView view, UITouch touch);

        // @optional -(void)view:(UIView *)view doubleTapDetected:(UITouch *)touch;
        [Export("view:doubleTapDetected:")]
        void DoubleTapDetected(UIView view, UITouch touch);

        // @optional -(void)view:(UIView *)view tripleTapDetected:(UITouch *)touch;
        [Export("view:tripleTapDetected:")]
        void TripleTapDetected(UIView view, UITouch touch);
    }

    // @interface MWZoomingScrollView : UIScrollView <UIScrollViewDelegate, MWTapDetectingImageViewDelegate, MWTapDetectingViewDelegate>
    [BaseType(typeof(UIScrollView))]
    interface MWZoomingScrollView : IUIScrollViewDelegate, IMWTapDetectingImageViewDelegate, IMWTapDetectingViewDelegate
    {
        // @property NSUInteger index;
        [Export("index")]
        nuint Index { get; set; }

        // @property (nonatomic) id<MWPhoto> photo;
        [Export("photo", ArgumentSemantic.Assign)]
        MWPhoto Photo { get; set; }

        // @property (nonatomic, weak) MWCaptionView * captionView;
        [Export("captionView", ArgumentSemantic.Weak)]
        MWCaptionView CaptionView { get; set; }

        // @property (nonatomic, weak) UIButton * selectedButton;
        [Export("selectedButton", ArgumentSemantic.Weak)]
        UIButton SelectedButton { get; set; }

        // @property (nonatomic, weak) UIButton * playButton;
        [Export("playButton", ArgumentSemantic.Weak)]
        UIButton PlayButton { get; set; }

        // @property (nonatomic) MWTapDetectingView * tapView;
        [Export("tapView", ArgumentSemantic.Assign)]
        MWTapDetectingView TapView { get; set; }

        // @property (nonatomic) MWTapDetectingImageView * photoImageView;
        [Export("photoImageView", ArgumentSemantic.Assign)]
        MWTapDetectingImageView PhotoImageView { get; set; }

        // -(id)initWithPhotoBrowser:(MWPhotoBrowser *)browser;
        [Export("initWithPhotoBrowser:")]
        IntPtr Constructor(MWPhotoBrowser browser);

        // -(void)displayImage;
        [Export("displayImage")]
        void DisplayImage();

        // -(void)displayImageFailure;
        [Export("displayImageFailure")]
        void DisplayImageFailure();

        // -(void)setMaxMinZoomScalesForCurrentBounds;
        [Export("setMaxMinZoomScalesForCurrentBounds")]
        void SetMaxMinZoomScalesForCurrentBounds();

        // -(void)prepareForReuse;
        [Export("prepareForReuse")]
        void PrepareForReuse();

        // -(BOOL)displayingVideo;
        [Export("displayingVideo")]
        bool DisplayingVideo { get; }

        // -(void)setImageHidden:(BOOL)hidden;
        [Export("setImageHidden:")]
        void SetImageHidden(bool hidden);
    }

    // @interface MWPhotoBrowser (UIImage)
    //[BaseType(typeof(NSObject))]
    //interface UIImage
    //{
    //    // +(UIImage *)imageForResourcePath:(NSString *)path ofType:(NSString *)type inBundle:(NSBundle *)bundle;
    //    [Static]
    //    [Export("imageForResourcePath:ofType:inBundle:")]
    //    UIImage ImageForResourcePath(string path, string type, NSBundle bundle);

    //    // +(UIImage *)clearImageWithSize:(CGSize)size;
    //    [Static]
    //    [Export("clearImageWithSize:")]
    //    UIImage ClearImageWithSize(CGSize size);
    //}

    // @interface MWCaptionView : UIToolbar
    [BaseType(typeof(UIToolbar))]
    interface MWCaptionView
    {
        // -(id)initWithPhoto:(id<MWPhoto>)photo;
        [Export("initWithPhoto:")]
        IntPtr Constructor(IMWPhoto photo);

        // -(void)setupCaption;
        [Export("setupCaption")]
        void SetupCaption();

        // -(CGSize)sizeThatFits:(CGSize)size;
        [Override]
        [Export("sizeThatFits:")]
        CGSize SizeThatFits(CGSize size);
    }
}
