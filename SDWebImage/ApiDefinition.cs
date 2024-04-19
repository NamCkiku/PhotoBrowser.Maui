using System;
using CoreFoundation;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace SDWebImage.iOS
{
    // typedef void (^SDWebImageNoParamsBlock)();
    delegate void SDWebImageNoParamsBlock();

    [Static]
    partial interface Constants
    {
        // extern NSString *const SDWebImageErrorDomain;
        [Field("SDWebImageErrorDomain", "__Internal")]
        NSString SDWebImageErrorDomain { get; }

        // extern NSString *const _Nonnull SDWebImageDownloadStartNotification;
        [Field("SDWebImageDownloadStartNotification", "__Internal")]
        NSString SDWebImageDownloadStartNotification { get; }

        // extern NSString *const _Nonnull SDWebImageDownloadReceiveResponseNotification;
        [Field("SDWebImageDownloadReceiveResponseNotification", "__Internal")]
        NSString SDWebImageDownloadReceiveResponseNotification { get; }

        // extern NSString *const _Nonnull SDWebImageDownloadStopNotification;
        [Field("SDWebImageDownloadStopNotification", "__Internal")]
        NSString SDWebImageDownloadStopNotification { get; }

        // extern NSString *const _Nonnull SDWebImageDownloadFinishNotification;
        [Field("SDWebImageDownloadFinishNotification", "__Internal")]
        NSString SDWebImageDownloadFinishNotification { get; }

        // extern NSString *const _Nonnull SDWebImageCoderScaleDownLargeImagesKey;
        [Field("SDWebImageCoderScaleDownLargeImagesKey", "__Internal")]
        NSString SDWebImageCoderScaleDownLargeImagesKey { get; }

        // extern NSString *const _Nonnull SDWebImageInternalSetImageInGlobalQueueKey;
        [Field("SDWebImageInternalSetImageInGlobalQueueKey", "__Internal")]
        NSString SDWebImageInternalSetImageInGlobalQueueKey { get; }
    }

    // @interface SDImageCacheConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface SDImageCacheConfig
    {
        // @property (assign, nonatomic) BOOL shouldDecompressImages;
        [Export("shouldDecompressImages")]
        bool ShouldDecompressImages { get; set; }

        // @property (assign, nonatomic) BOOL shouldDisableiCloud;
        [Export("shouldDisableiCloud")]
        bool ShouldDisableiCloud { get; set; }

        // @property (assign, nonatomic) BOOL shouldCacheImagesInMemory;
        [Export("shouldCacheImagesInMemory")]
        bool ShouldCacheImagesInMemory { get; set; }

        // @property (assign, nonatomic) NSDataReadingOptions diskCacheReadingOptions;
        [Export("diskCacheReadingOptions", ArgumentSemantic.Assign)]
        NSDataReadingOptions DiskCacheReadingOptions { get; set; }

        // @property (assign, nonatomic) NSInteger maxCacheAge;
        [Export("maxCacheAge")]
        nint MaxCacheAge { get; set; }

        // @property (assign, nonatomic) NSUInteger maxCacheSize;
        [Export("maxCacheSize")]
        nuint MaxCacheSize { get; set; }
    }

    // typedef void (^SDCacheQueryCompletedBlock)(UIImage * _Nullable, NSData * _Nullable, SDImageCacheType);
    delegate void SDCacheQueryCompletedBlock([NullAllowed] UIImage arg0, [NullAllowed] NSData arg1, SDImageCacheType arg2);

    // typedef void (^SDWebImageCheckCacheCompletionBlock)(BOOL);
    delegate void SDWebImageCheckCacheCompletionBlock(bool arg0);

    // typedef void (^SDWebImageCalculateSizeBlock)(NSUInteger, NSUInteger);
    delegate void SDWebImageCalculateSizeBlock(nuint arg0, nuint arg1);

    // @interface SDImageCache : NSObject
    [DisableDefaultCtor]
    [BaseType(typeof(NSObject))]
    interface SDImageCache
    {
        // @property (readonly, nonatomic) SDImageCacheConfig * _Nonnull config;
        [Export("config")]
        SDImageCacheConfig Config { get; }

        // @property (assign, nonatomic) NSUInteger maxMemoryCost;
        [Export("maxMemoryCost")]
        nuint MaxMemoryCost { get; set; }

        // @property (assign, nonatomic) NSUInteger maxMemoryCountLimit;
        [Export("maxMemoryCountLimit")]
        nuint MaxMemoryCountLimit { get; set; }

        // +(instancetype _Nonnull)sharedImageCache;
        [Static]
        [Export("sharedImageCache")]
        SDImageCache SharedImageCache();

        // -(instancetype _Nonnull)initWithNamespace:(NSString * _Nonnull)ns;
        [Export("initWithNamespace:")]
        IntPtr Constructor(string ns);

        // -(instancetype _Nonnull)initWithNamespace:(NSString * _Nonnull)ns diskCacheDirectory:(NSString * _Nonnull)directory __attribute__((objc_designated_initializer));
        [Export("initWithNamespace:diskCacheDirectory:")]
        [DesignatedInitializer]
        IntPtr Constructor(string ns, string directory);

        // -(NSString * _Nullable)makeDiskCachePath:(NSString * _Nonnull)fullNamespace;
        [Export("makeDiskCachePath:")]
        [return: NullAllowed]
        string MakeDiskCachePath(string fullNamespace);

        // -(void)addReadOnlyCachePath:(NSString * _Nonnull)path;
        [Export("addReadOnlyCachePath:")]
        void AddReadOnlyCachePath(string path);

        // -(void)storeImage:(UIImage * _Nullable)image forKey:(NSString * _Nullable)key completion:(SDWebImageNoParamsBlock _Nullable)completionBlock;
        [Export("storeImage:forKey:completion:")]
        void StoreImage([NullAllowed] UIImage image, [NullAllowed] string key, [NullAllowed] SDWebImageNoParamsBlock completionBlock);

        // -(void)storeImage:(UIImage * _Nullable)image forKey:(NSString * _Nullable)key toDisk:(BOOL)toDisk completion:(SDWebImageNoParamsBlock _Nullable)completionBlock;
        [Export("storeImage:forKey:toDisk:completion:")]
        void StoreImage([NullAllowed] UIImage image, [NullAllowed] string key, bool toDisk, [NullAllowed] SDWebImageNoParamsBlock completionBlock);

        // -(void)storeImage:(UIImage * _Nullable)image imageData:(NSData * _Nullable)imageData forKey:(NSString * _Nullable)key toDisk:(BOOL)toDisk completion:(SDWebImageNoParamsBlock _Nullable)completionBlock;
        [Export("storeImage:imageData:forKey:toDisk:completion:")]
        void StoreImage([NullAllowed] UIImage image, [NullAllowed] NSData imageData, [NullAllowed] string key, bool toDisk, [NullAllowed] SDWebImageNoParamsBlock completionBlock);

        // -(void)storeImageDataToDisk:(NSData * _Nullable)imageData forKey:(NSString * _Nullable)key;
        [Export("storeImageDataToDisk:forKey:")]
        void StoreImageDataToDisk([NullAllowed] NSData imageData, [NullAllowed] string key);

        // -(void)diskImageExistsWithKey:(NSString * _Nullable)key completion:(SDWebImageCheckCacheCompletionBlock _Nullable)completionBlock;
        [Export("diskImageExistsWithKey:completion:")]
        void DiskImageExistsWithKey([NullAllowed] string key, [NullAllowed] SDWebImageCheckCacheCompletionBlock completionBlock);

        // -(NSOperation * _Nullable)queryCacheOperationForKey:(NSString * _Nullable)key done:(SDCacheQueryCompletedBlock _Nullable)doneBlock;
        [Export("queryCacheOperationForKey:done:")]
        [return: NullAllowed]
        NSOperation QueryCacheOperationForKey([NullAllowed] string key, [NullAllowed] SDCacheQueryCompletedBlock doneBlock);

        // -(UIImage * _Nullable)imageFromMemoryCacheForKey:(NSString * _Nullable)key;
        [Export("imageFromMemoryCacheForKey:")]
        [return: NullAllowed]
        UIImage ImageFromMemoryCacheForKey([NullAllowed] string key);

        // -(UIImage * _Nullable)imageFromDiskCacheForKey:(NSString * _Nullable)key;
        [Export("imageFromDiskCacheForKey:")]
        [return: NullAllowed]
        UIImage ImageFromDiskCacheForKey([NullAllowed] string key);

        // -(UIImage * _Nullable)imageFromCacheForKey:(NSString * _Nullable)key;
        [Export("imageFromCacheForKey:")]
        [return: NullAllowed]
        UIImage ImageFromCacheForKey([NullAllowed] string key);

        // -(void)removeImageForKey:(NSString * _Nullable)key withCompletion:(SDWebImageNoParamsBlock _Nullable)completion;
        [Export("removeImageForKey:withCompletion:")]
        void RemoveImageForKey([NullAllowed] string key, [NullAllowed] SDWebImageNoParamsBlock completion);

        // -(void)removeImageForKey:(NSString * _Nullable)key fromDisk:(BOOL)fromDisk withCompletion:(SDWebImageNoParamsBlock _Nullable)completion;
        [Export("removeImageForKey:fromDisk:withCompletion:")]
        void RemoveImageForKey([NullAllowed] string key, bool fromDisk, [NullAllowed] SDWebImageNoParamsBlock completion);

        // -(void)clearMemory;
        [Export("clearMemory")]
        void ClearMemory();

        // -(void)clearDiskOnCompletion:(SDWebImageNoParamsBlock _Nullable)completion;
        [Export("clearDiskOnCompletion:")]
        void ClearDiskOnCompletion([NullAllowed] SDWebImageNoParamsBlock completion);

        // -(void)deleteOldFilesWithCompletionBlock:(SDWebImageNoParamsBlock _Nullable)completionBlock;
        [Export("deleteOldFilesWithCompletionBlock:")]
        void DeleteOldFilesWithCompletionBlock([NullAllowed] SDWebImageNoParamsBlock completionBlock);

        // -(NSUInteger)getSize;
        [Export("getSize")]
        nuint Size { get; }

        // -(NSUInteger)getDiskCount;
        [Export("getDiskCount")]
        nuint DiskCount { get; }

        // -(void)calculateSizeWithCompletionBlock:(SDWebImageCalculateSizeBlock _Nullable)completionBlock;
        [Export("calculateSizeWithCompletionBlock:")]
        void CalculateSizeWithCompletionBlock([NullAllowed] SDWebImageCalculateSizeBlock completionBlock);

        // -(NSString * _Nullable)cachePathForKey:(NSString * _Nullable)key inPath:(NSString * _Nonnull)path;
        [Export("cachePathForKey:inPath:")]
        [return: NullAllowed]
        string CachePathForKey([NullAllowed] string key, string path);

        // -(NSString * _Nullable)defaultCachePathForKey:(NSString * _Nullable)key;
        [Export("defaultCachePathForKey:")]
        [return: NullAllowed]
        string DefaultCachePathForKey([NullAllowed] string key);
    }

    // @protocol SDWebImageCoder <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SDWebImageCoder
    {
        // @required -(BOOL)canDecodeFromData:(NSData * _Nullable)data;
        [Abstract]
        [Export("canDecodeFromData:")]
        bool CanDecodeFromData([NullAllowed] NSData data);

        // @required -(UIImage * _Nullable)decodedImageWithData:(NSData * _Nullable)data;
        [Abstract]
        [Export("decodedImageWithData:")]
        [return: NullAllowed]
        UIImage DecodedImageWithData([NullAllowed] NSData data);

        // @required -(UIImage * _Nullable)decompressedImageWithImage:(UIImage * _Nullable)image data:(NSData * _Nullable * _Nonnull)data options:(NSDictionary<NSString *,NSObject *> * _Nullable)optionsDict;
        [Abstract]
        [Export("decompressedImageWithImage:data:options:")]
        [return: NullAllowed]
        UIImage DecompressedImageWithImage([NullAllowed] UIImage image, [NullAllowed] out NSData data, [NullAllowed] NSDictionary<NSString, NSObject> optionsDict);

        // @required -(BOOL)canEncodeToFormat:(SDImageFormat)format;
        [Abstract]
        [Export("canEncodeToFormat:")]
        bool CanEncodeToFormat(SDImageFormat format);

        // @required -(NSData * _Nullable)encodedDataWithImage:(UIImage * _Nullable)image format:(SDImageFormat)format;
        [Abstract]
        [Export("encodedDataWithImage:format:")]
        [return: NullAllowed]
        NSData EncodedDataWithImage([NullAllowed] UIImage image, SDImageFormat format);
    }

    // @protocol SDWebImageProgressiveCoder <SDWebImageCoder>
    [Protocol, Model]
    interface SDWebImageProgressiveCoder : SDWebImageCoder
    {
        // @required -(BOOL)canIncrementallyDecodeFromData:(NSData * _Nullable)data;
        [Abstract]
        [Export("canIncrementallyDecodeFromData:")]
        bool CanIncrementallyDecodeFromData([NullAllowed] NSData data);

        // @required -(UIImage * _Nullable)incrementallyDecodedImageWithData:(NSData * _Nullable)data finished:(BOOL)finished;
        [Abstract]
        [Export("incrementallyDecodedImageWithData:finished:")]
        [return: NullAllowed]
        UIImage IncrementallyDecodedImageWithData([NullAllowed] NSData data, bool finished);
    }

    // @interface SDWebImageFrame : NSObject
    [BaseType(typeof(NSObject))]
    interface SDWebImageFrame
    {
        // @property (readonly, nonatomic, strong) UIImage * _Nonnull image;
        [Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; }

        // @property (readonly, assign, nonatomic) NSTimeInterval duration;
        [Export("duration")]
        double Duration { get; }

        // +(instancetype _Nonnull)frameWithImage:(UIImage * _Nonnull)image duration:(NSTimeInterval)duration;
        [Static]
        [Export("frameWithImage:duration:")]
        SDWebImageFrame FrameWithImage(UIImage image, double duration);
    }

    // @interface SDWebImageCoderHelper : NSObject
    [BaseType(typeof(NSObject))]
    interface SDWebImageCoderHelper
    {
        // +(UIImage * _Nullable)animatedImageWithFrames:(NSArray<SDWebImageFrame *> * _Nullable)frames;
        [Static]
        [Export("animatedImageWithFrames:")]
        [return: NullAllowed]
        UIImage AnimatedImageWithFrames([NullAllowed] SDWebImageFrame[] frames);

        // +(NSArray<SDWebImageFrame *> * _Nullable)framesFromAnimatedImage:(UIImage * _Nullable)animatedImage;
        [Static]
        [Export("framesFromAnimatedImage:")]
        [return: NullAllowed]
        SDWebImageFrame[] FramesFromAnimatedImage([NullAllowed] UIImage animatedImage);

        // +(UIImageOrientation)imageOrientationFromEXIFOrientation:(NSInteger)exifOrientation;
        [Static]
        [Export("imageOrientationFromEXIFOrientation:")]
        UIImageOrientation ImageOrientationFromEXIFOrientation(nint exifOrientation);

        // +(NSInteger)exifOrientationFromImageOrientation:(UIImageOrientation)imageOrientation;
        [Static]
        [Export("exifOrientationFromImageOrientation:")]
        nint ExifOrientationFromImageOrientation(UIImageOrientation imageOrientation);
    }

    // @interface SDWebImageCodersManager : NSObject <SDWebImageCoder>
    [BaseType(typeof(NSObject))]
    interface SDWebImageCodersManager : SDWebImageCoder
    {
        // +(instancetype _Nonnull)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        SDWebImageCodersManager SharedInstance();

        // @property (readwrite, nonatomic, strong) NSArray<SDWebImageCoder> * _Nullable coders;
        [NullAllowed, Export("coders", ArgumentSemantic.Strong)]
        NSObject[] Coders { get; set; }

        // -(void)addCoder:(id<SDWebImageCoder> _Nonnull)coder;
        [Export("addCoder:")]
        void AddCoder(SDWebImageCoder coder);

        // -(void)removeCoder:(id<SDWebImageCoder> _Nonnull)coder;
        [Export("removeCoder:")]
        void RemoveCoder(SDWebImageCoder coder);
    }

    // @protocol SDWebImageOperation <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SDWebImageOperation
    {
        // @required -(void)cancel;
        [Abstract]
        [Export("cancel")]
        void Cancel();
    }

    // typedef void (^SDWebImageDownloaderProgressBlock)(NSInteger, NSInteger, NSURL * _Nullable);
    delegate void SDWebImageDownloaderProgressBlock(nint arg0, nint arg1, [NullAllowed] NSUrl arg2);

    // typedef void (^SDWebImageDownloaderCompletedBlock)(UIImage * _Nullable, NSData * _Nullable, NSError * _Nullable, BOOL);
    delegate void SDWebImageDownloaderCompletedBlock([NullAllowed] UIImage arg0, [NullAllowed] NSData arg1, [NullAllowed] NSError arg2, bool arg3);

    // typedef SDHTTPHeadersDictionary * _Nullable (^SDWebImageDownloaderHeadersFilterBlock)(NSURL * _Nullable, SDHTTPHeadersDictionary * _Nullable);
    delegate NSDictionary<NSString, NSString> SDWebImageDownloaderHeadersFilterBlock([NullAllowed] NSUrl arg0, [NullAllowed] NSDictionary<NSString, NSString> arg1);

    // @interface SDWebImageDownloadToken : NSObject
    [BaseType(typeof(NSObject))]
    interface SDWebImageDownloadToken
    {
        // @property (nonatomic, strong) NSURL * _Nullable url;
        [NullAllowed, Export("url", ArgumentSemantic.Strong)]
        NSUrl Url { get; set; }

        // @property (nonatomic, strong) id _Nullable downloadOperationCancelToken;
        [NullAllowed, Export("downloadOperationCancelToken", ArgumentSemantic.Strong)]
        NSObject DownloadOperationCancelToken { get; set; }
    }

    // @interface SDWebImageDownloader : NSObject
    [DisableDefaultCtor]
    [BaseType(typeof(NSObject))]
    interface SDWebImageDownloader
    {
        // @property (assign, nonatomic) BOOL shouldDecompressImages;
        [Export("shouldDecompressImages")]
        bool ShouldDecompressImages { get; set; }

        // @property (assign, nonatomic) NSInteger maxConcurrentDownloads;
        [Export("maxConcurrentDownloads")]
        nint MaxConcurrentDownloads { get; set; }

        // @property (readonly, nonatomic) NSUInteger currentDownloadCount;
        [Export("currentDownloadCount")]
        nuint CurrentDownloadCount { get; }

        // @property (assign, nonatomic) NSTimeInterval downloadTimeout;
        [Export("downloadTimeout")]
        double DownloadTimeout { get; set; }

        // @property (readonly, nonatomic) NSURLSessionConfiguration * _Nonnull sessionConfiguration;
        [Export("sessionConfiguration")]
        NSUrlSessionConfiguration SessionConfiguration { get; }

        // @property (assign, nonatomic) SDWebImageDownloaderExecutionOrder executionOrder;
        [Export("executionOrder", ArgumentSemantic.Assign)]
        SDWebImageDownloaderExecutionOrder ExecutionOrder { get; set; }

        // +(instancetype _Nonnull)sharedDownloader;
        [Static]
        [Export("sharedDownloader")]
        SDWebImageDownloader SharedDownloader();

        // @property (nonatomic, strong) NSURLCredential * _Nullable urlCredential;
        [NullAllowed, Export("urlCredential", ArgumentSemantic.Strong)]
        NSUrlCredential UrlCredential { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable username;
        [NullAllowed, Export("username", ArgumentSemantic.Strong)]
        string Username { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable password;
        [NullAllowed, Export("password", ArgumentSemantic.Strong)]
        string Password { get; set; }

        // @property (copy, nonatomic) SDWebImageDownloaderHeadersFilterBlock _Nullable headersFilter;
        //[NullAllowed, Export("headersFilter", ArgumentSemantic.Copy)]
        //SDWebImageDownloaderHeadersFilterBlock HeadersFilter { get; set; }

        // -(instancetype _Nonnull)initWithSessionConfiguration:(NSURLSessionConfiguration * _Nullable)sessionConfiguration __attribute__((objc_designated_initializer));
        [Export("initWithSessionConfiguration:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] NSUrlSessionConfiguration sessionConfiguration);

        // -(void)setValue:(NSString * _Nullable)value forHTTPHeaderField:(NSString * _Nullable)field;
        [Export("setValue:forHTTPHeaderField:")]
        void SetValue([NullAllowed] string value, [NullAllowed] string field);

        // -(NSString * _Nullable)valueForHTTPHeaderField:(NSString * _Nullable)field;
        [Export("valueForHTTPHeaderField:")]
        [return: NullAllowed]
        string ValueForHTTPHeaderField([NullAllowed] string field);

        // -(void)setOperationClass:(Class _Nullable)operationClass;
        [Export("setOperationClass:")]
        void SetOperationClass([NullAllowed] Class operationClass);

        // -(SDWebImageDownloadToken * _Nullable)downloadImageWithURL:(NSURL * _Nullable)url options:(SDWebImageDownloaderOptions)options progress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDWebImageDownloaderCompletedBlock _Nullable)completedBlock;
        [Export("downloadImageWithURL:options:progress:completed:")]
        [return: NullAllowed]
        SDWebImageDownloadToken DownloadImageWithURL([NullAllowed] NSUrl url, SDWebImageDownloaderOptions options, [NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDWebImageDownloaderCompletedBlock completedBlock);

        // -(void)cancel:(SDWebImageDownloadToken * _Nullable)token;
        [Export("cancel:")]
        void Cancel([NullAllowed] SDWebImageDownloadToken token);

        // -(void)setSuspended:(BOOL)suspended;
        [Export("setSuspended:")]
        void SetSuspended(bool suspended);

        // -(void)cancelAllDownloads;
        [Export("cancelAllDownloads")]
        void CancelAllDownloads();

        // -(void)createNewSessionWithConfiguration:(NSURLSessionConfiguration * _Nonnull)sessionConfiguration;
        [Export("createNewSessionWithConfiguration:")]
        void CreateNewSessionWithConfiguration(NSUrlSessionConfiguration sessionConfiguration);
    }

    // @protocol SDWebImageDownloaderOperationInterface <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SDWebImageDownloaderOperationInterface
    {
        // @required -(instancetype _Nonnull)initWithRequest:(NSURLRequest * _Nullable)request inSession:(NSURLSession * _Nullable)session options:(SDWebImageDownloaderOptions)options;
        [Export("initWithRequest:inSession:options:")]
        IntPtr Constructor([NullAllowed] NSUrlRequest request, [NullAllowed] NSUrlSession session, SDWebImageDownloaderOptions options);

        // @required -(id _Nullable)addHandlersForProgress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDWebImageDownloaderCompletedBlock _Nullable)completedBlock;
        [Abstract]
        [Export("addHandlersForProgress:completed:")]
        [return: NullAllowed]
        NSObject AddHandlersForProgress([NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDWebImageDownloaderCompletedBlock completedBlock);

        // @required -(BOOL)shouldDecompressImages;
        // @required -(void)setShouldDecompressImages:(BOOL)value;
        [Abstract]
        [Export("shouldDecompressImages")]
        bool ShouldDecompressImages { get; set; }

        // @required -(NSURLCredential * _Nullable)credential;
        [Abstract]
        [Export("credential")]
        [return: NullAllowed]
        NSUrlCredential Credential();

        // @required -(void)setCredential:(NSURLCredential * _Nullable)value;
        [Abstract]
        [Export("setCredential:")]
        void SetCredential([NullAllowed] NSUrlCredential value);
    }

    // @interface SDWebImageDownloaderOperation : NSOperation <SDWebImageDownloaderOperationInterface, SDWebImageOperation, NSURLSessionTaskDelegate, NSURLSessionDataDelegate>
    [BaseType(typeof(NSOperation))]
    interface SDWebImageDownloaderOperation : SDWebImageDownloaderOperationInterface, SDWebImageOperation, INSUrlSessionTaskDelegate, INSUrlSessionDataDelegate
    {
        // @property (readonly, nonatomic, strong) NSURLRequest * _Nullable request;
        [NullAllowed, Export("request", ArgumentSemantic.Strong)]
        NSUrlRequest Request { get; }

        // @property (readonly, nonatomic, strong) NSURLSessionTask * _Nullable dataTask;
        [NullAllowed, Export("dataTask", ArgumentSemantic.Strong)]
        NSUrlSessionTask DataTask { get; }

        // @property (assign, nonatomic) BOOL shouldUseCredentialStorage __attribute__((deprecated("Property deprecated. Does nothing. Kept only for backwards compatibility")));
        [Export("shouldUseCredentialStorage")]
        bool ShouldUseCredentialStorage { get; set; }

        // @property (readonly, assign, nonatomic) SDWebImageDownloaderOptions options;
        [Export("options", ArgumentSemantic.Assign)]
        SDWebImageDownloaderOptions Options { get; }

        // @property (assign, nonatomic) NSInteger expectedSize;
        [Export("expectedSize")]
        nint ExpectedSize { get; set; }

        // @property (nonatomic, strong) NSURLResponse * _Nullable response;
        [NullAllowed, Export("response", ArgumentSemantic.Strong)]
        NSUrlResponse Response { get; set; }

        // -(BOOL)cancel:(id _Nullable)token;
        [Export("cancel:")]
        bool Cancel([NullAllowed] NSObject token);
    }

    // @interface SDWebImageGIFCoder : NSObject <SDWebImageCoder>
    [BaseType(typeof(NSObject))]
    interface SDWebImageGIFCoder : SDWebImageCoder
    {
        // +(instancetype _Nonnull)sharedCoder;
        [Static]
        [Export("sharedCoder")]
        SDWebImageGIFCoder SharedCoder();
    }

    // @interface SDWebImageImageIOCoder : NSObject <SDWebImageProgressiveCoder>
    [BaseType(typeof(NSObject))]
    interface SDWebImageImageIOCoder : SDWebImageProgressiveCoder
    {
        // +(instancetype _Nonnull)sharedCoder;
        [Static]
        [Export("sharedCoder")]
        SDWebImageImageIOCoder SharedCoder();
    }

    // typedef void (^SDExternalCompletionBlock)(UIImage * _Nullable, NSError * _Nullable, SDImageCacheType, NSURL * _Nullable);
    delegate void SDExternalCompletionBlock([NullAllowed] UIImage arg0, [NullAllowed] NSError arg1, SDImageCacheType arg2, [NullAllowed] NSUrl arg3);

    // typedef void (^SDInternalCompletionBlock)(UIImage * _Nullable, NSData * _Nullable, NSError * _Nullable, SDImageCacheType, BOOL, NSURL * _Nullable);
    delegate void SDInternalCompletionBlock([NullAllowed] UIImage arg0, [NullAllowed] NSData arg1, [NullAllowed] NSError arg2, SDImageCacheType arg3, bool arg4, [NullAllowed] NSUrl arg5);

    // typedef NSString * _Nullable (^SDWebImageCacheKeyFilterBlock)(NSURL * _Nullable);
    delegate string SDWebImageCacheKeyFilterBlock([NullAllowed] NSUrl arg0);

    // @protocol SDWebImageManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SDWebImageManagerDelegate
    {
        // @optional -(BOOL)imageManager:(SDWebImageManager * _Nonnull)imageManager shouldDownloadImageForURL:(NSURL * _Nullable)imageURL;
        [Export("imageManager:shouldDownloadImageForURL:")]
        bool ImageManager(SDWebImageManager imageManager, [NullAllowed] NSUrl imageURL);

        // @optional -(UIImage * _Nullable)imageManager:(SDWebImageManager * _Nonnull)imageManager transformDownloadedImage:(UIImage * _Nullable)image withURL:(NSURL * _Nullable)imageURL;
        [Export("imageManager:transformDownloadedImage:withURL:")]
        [return: NullAllowed]
        UIImage ImageManager(SDWebImageManager imageManager, [NullAllowed] UIImage image, [NullAllowed] NSUrl imageURL);
    }

    // @interface SDWebImageManager : NSObject
    [DisableDefaultCtor]
    [BaseType(typeof(NSObject))]
    interface SDWebImageManager
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        SDWebImageManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SDWebImageManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic, strong) SDImageCache * _Nullable imageCache;
        [NullAllowed, Export("imageCache", ArgumentSemantic.Strong)]
        SDImageCache ImageCache { get; }

        // @property (readonly, nonatomic, strong) SDWebImageDownloader * _Nullable imageDownloader;
        [NullAllowed, Export("imageDownloader", ArgumentSemantic.Strong)]
        SDWebImageDownloader ImageDownloader { get; }

        // @property (copy, nonatomic) SDWebImageCacheKeyFilterBlock _Nullable cacheKeyFilter;
        [NullAllowed, Export("cacheKeyFilter", ArgumentSemantic.Copy)]
        SDWebImageCacheKeyFilterBlock CacheKeyFilter { get; set; }

        // +(instancetype _Nonnull)sharedManager;
        [Static]
        [Export("sharedManager")]
        SDWebImageManager SharedManager();

        // -(instancetype _Nonnull)initWithCache:(SDImageCache * _Nonnull)cache downloader:(SDWebImageDownloader * _Nonnull)downloader __attribute__((objc_designated_initializer));
        [Export("initWithCache:downloader:")]
        [DesignatedInitializer]
        IntPtr Constructor(SDImageCache cache, SDWebImageDownloader downloader);

        // -(id<SDWebImageOperation> _Nullable)loadImageWithURL:(NSURL * _Nullable)url options:(SDWebImageOptions)options progress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDInternalCompletionBlock _Nullable)completedBlock;
        [Export("loadImageWithURL:options:progress:completed:")]
        [return: NullAllowed]
        SDWebImageOperation LoadImageWithURL([NullAllowed] NSUrl url, SDWebImageOptions options, [NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDInternalCompletionBlock completedBlock);

        // -(void)saveImageToCache:(UIImage * _Nullable)image forURL:(NSURL * _Nullable)url;
        [Export("saveImageToCache:forURL:")]
        void SaveImageToCache([NullAllowed] UIImage image, [NullAllowed] NSUrl url);

        // -(void)cancelAll;
        [Export("cancelAll")]
        void CancelAll();

        // -(BOOL)isRunning;
        [Export("isRunning")]
        bool IsRunning { get; }

        // -(void)cachedImageExistsForURL:(NSURL * _Nullable)url completion:(SDWebImageCheckCacheCompletionBlock _Nullable)completionBlock;
        [Export("cachedImageExistsForURL:completion:")]
        void CachedImageExistsForURL([NullAllowed] NSUrl url, [NullAllowed] SDWebImageCheckCacheCompletionBlock completionBlock);

        // -(void)diskImageExistsForURL:(NSURL * _Nullable)url completion:(SDWebImageCheckCacheCompletionBlock _Nullable)completionBlock;
        [Export("diskImageExistsForURL:completion:")]
        void DiskImageExistsForURL([NullAllowed] NSUrl url, [NullAllowed] SDWebImageCheckCacheCompletionBlock completionBlock);

        // -(NSString * _Nullable)cacheKeyForURL:(NSURL * _Nullable)url;
        [Export("cacheKeyForURL:")]
        [return: NullAllowed]
        string CacheKeyForURL([NullAllowed] NSUrl url);
    }

    // @protocol SDWebImagePrefetcherDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SDWebImagePrefetcherDelegate
    {
        // @optional -(void)imagePrefetcher:(SDWebImagePrefetcher * _Nonnull)imagePrefetcher didPrefetchURL:(NSURL * _Nullable)imageURL finishedCount:(NSUInteger)finishedCount totalCount:(NSUInteger)totalCount;
        [Export("imagePrefetcher:didPrefetchURL:finishedCount:totalCount:")]
        void DidPrefetchURL(SDWebImagePrefetcher imagePrefetcher, [NullAllowed] NSUrl imageURL, nuint finishedCount, nuint totalCount);

        // @optional -(void)imagePrefetcher:(SDWebImagePrefetcher * _Nonnull)imagePrefetcher didFinishWithTotalCount:(NSUInteger)totalCount skippedCount:(NSUInteger)skippedCount;
        [Export("imagePrefetcher:didFinishWithTotalCount:skippedCount:")]
        void DidFinishWithTotalCount(SDWebImagePrefetcher imagePrefetcher, nuint totalCount, nuint skippedCount);
    }

    // typedef void (^SDWebImagePrefetcherProgressBlock)(NSUInteger, NSUInteger);
    delegate void SDWebImagePrefetcherProgressBlock(nuint arg0, nuint arg1);

    // typedef void (^SDWebImagePrefetcherCompletionBlock)(NSUInteger, NSUInteger);
    delegate void SDWebImagePrefetcherCompletionBlock(nuint arg0, nuint arg1);

    // @interface SDWebImagePrefetcher : NSObject
    [DisableDefaultCtor]
    [BaseType(typeof(NSObject))]
    interface SDWebImagePrefetcher
    {
        // @property (readonly, nonatomic, strong) SDWebImageManager * _Nonnull manager;
        [Export("manager", ArgumentSemantic.Strong)]
        SDWebImageManager Manager { get; }

        // @property (assign, nonatomic) NSUInteger maxConcurrentDownloads;
        [Export("maxConcurrentDownloads")]
        nuint MaxConcurrentDownloads { get; set; }

        // @property (assign, nonatomic) SDWebImageOptions options;
        [Export("options", ArgumentSemantic.Assign)]
        SDWebImageOptions Options { get; set; }

        // @property (nonatomic, strong) dispatch_queue_t _Nonnull prefetcherQueue;
        [Export("prefetcherQueue", ArgumentSemantic.Strong)]
        DispatchQueue PrefetcherQueue { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        SDWebImagePrefetcherDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SDWebImagePrefetcherDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // +(instancetype _Nonnull)sharedImagePrefetcher;
        [Static]
        [Export("sharedImagePrefetcher")]
        SDWebImagePrefetcher SharedImagePrefetcher();

        // -(instancetype _Nonnull)initWithImageManager:(SDWebImageManager * _Nonnull)manager __attribute__((objc_designated_initializer));
        [Export("initWithImageManager:")]
        [DesignatedInitializer]
        IntPtr Constructor(SDWebImageManager manager);

        // -(void)prefetchURLs:(NSArray<NSURL *> * _Nullable)urls;
        [Export("prefetchURLs:")]
        void PrefetchURLs([NullAllowed] NSUrl[] urls);

        // -(void)prefetchURLs:(NSArray<NSURL *> * _Nullable)urls progress:(SDWebImagePrefetcherProgressBlock _Nullable)progressBlock completed:(SDWebImagePrefetcherCompletionBlock _Nullable)completionBlock;
        [Export("prefetchURLs:progress:completed:")]
        void PrefetchURLs([NullAllowed] NSUrl[] urls, [NullAllowed] SDWebImagePrefetcherProgressBlock progressBlock, [NullAllowed] SDWebImagePrefetcherCompletionBlock completionBlock);

        // -(void)cancelPrefetching;
        [Export("cancelPrefetching")]
        void CancelPrefetching();
    }

    // @interface WebCache (UIButton)
    [Category]
    [BaseType(typeof(UIButton))]
    interface UIButton_WebCache
    {
        // -(NSURL * _Nullable)sd_currentImageURL;
        [NullAllowed, Export("sd_currentImageURL")]
        NSUrl Sd_currentImageURL();

        // -(NSURL * _Nullable)sd_imageURLForState:(UIControlState)state;
        [Export("sd_imageURLForState:")]
        [return: NullAllowed]
        NSUrl Sd_imageURLForState(UIControlState state);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state;
        [Export("sd_setImageWithURL:forState:")]
        void Sd_setImageWithURL([NullAllowed] NSUrl url, UIControlState state);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder;
        [Export("sd_setImageWithURL:forState:placeholderImage:")]
        void Sd_setImageWithURL([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options;
        [Export("sd_setImageWithURL:forState:placeholderImage:options:")]
        void Sd_setImageWithURL([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, SDWebImageOptions options);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:forState:completed:")]
        void Sd_setImageWithURL([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:forState:placeholderImage:completed:")]
        void Sd_setImageWithURL([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:forState:placeholderImage:options:completed:")]
        void Sd_setImageWithURL([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(NSURL * _Nullable)sd_currentBackgroundImageURL;
        [NullAllowed, Export("sd_currentBackgroundImageURL")]
        NSUrl Sd_currentBackgroundImageURL();

        // -(NSURL * _Nullable)sd_backgroundImageURLForState:(UIControlState)state;
        [Export("sd_backgroundImageURLForState:")]
        [return: NullAllowed]
        NSUrl Sd_backgroundImageURLForState(UIControlState state);

        // -(void)sd_setBackgroundImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state;
        [Export("sd_setBackgroundImageWithURL:forState:")]
        void Sd_setBackgroundImageWithURL([NullAllowed] NSUrl url, UIControlState state);

        // -(void)sd_setBackgroundImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder;
        [Export("sd_setBackgroundImageWithURL:forState:placeholderImage:")]
        void Sd_setBackgroundImageWithURL([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder);

        // -(void)sd_setBackgroundImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options;
        [Export("sd_setBackgroundImageWithURL:forState:placeholderImage:options:")]
        void Sd_setBackgroundImageWithURL([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, SDWebImageOptions options);

        // -(void)sd_setBackgroundImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setBackgroundImageWithURL:forState:completed:")]
        void Sd_setBackgroundImageWithURL([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setBackgroundImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setBackgroundImageWithURL:forState:placeholderImage:completed:")]
        void Sd_setBackgroundImageWithURL([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setBackgroundImageWithURL:(NSURL * _Nullable)url forState:(UIControlState)state placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setBackgroundImageWithURL:forState:placeholderImage:options:completed:")]
        void Sd_setBackgroundImageWithURL([NullAllowed] NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_cancelImageLoadForState:(UIControlState)state;
        [Export("sd_cancelImageLoadForState:")]
        void Sd_cancelImageLoadForState(UIControlState state);

        // -(void)sd_cancelBackgroundImageLoadForState:(UIControlState)state;
        [Export("sd_cancelBackgroundImageLoadForState:")]
        void Sd_cancelBackgroundImageLoadForState(UIControlState state);
    }

    // @interface ForceDecode (UIImage)
    [Category]
    [BaseType(typeof(UIImage))]
    interface UIImage_ForceDecode
    {
        // +(UIImage * _Nullable)decodedImageWithImage:(UIImage * _Nullable)image;
        [Static]
        [Export("decodedImageWithImage:")]
        [return: NullAllowed]
        UIImage DecodedImageWithImage([NullAllowed] UIImage image);

        // +(UIImage * _Nullable)decodedAndScaledDownImageWithImage:(UIImage * _Nullable)image;
        [Static]
        [Export("decodedAndScaledDownImageWithImage:")]
        [return: NullAllowed]
        UIImage DecodedAndScaledDownImageWithImage([NullAllowed] UIImage image);
    }

    // @interface GIF (UIImage)
    [Category]
    [BaseType(typeof(UIImage))]
    interface UIImage_GIF
    {
        // +(UIImage *)sd_animatedGIFWithData:(NSData *)data;
        [Static]
        [Export("sd_animatedGIFWithData:")]
        UIImage Sd_animatedGIFWithData(NSData data);

        // -(BOOL)isGIF;
        [Export("isGIF")]
        bool IsGIF();
    }

    // @interface MultiFormat (UIImage)
    [Category]
    [BaseType(typeof(UIImage))]
    interface UIImage_MultiFormat
    {
        // @property (assign, nonatomic) NSUInteger sd_imageLoopCount;
        [Export("sd_imageLoopCount")]
        nuint Sd_imageLoopCount();

        [Export("sd_imageLoopCount:")]
        nuint Sd_imageLoopCount(nuint count);

        // +(UIImage * _Nullable)sd_imageWithData:(NSData * _Nullable)data;
        [Static]
        [Export("sd_imageWithData:")]
        [return: NullAllowed]
        UIImage Sd_imageWithData([NullAllowed] NSData data);

        // -(NSData * _Nullable)sd_imageData;
        [NullAllowed, Export("sd_imageData")]
        NSData Sd_imageData();

        // -(NSData * _Nullable)sd_imageDataAsFormat:(SDImageFormat)imageFormat;
        [Export("sd_imageDataAsFormat:")]
        [return: NullAllowed]
        NSData Sd_imageDataAsFormat(SDImageFormat imageFormat);
    }

    // @interface HighlightedWebCache (UIImageView)
    [Category]
    [BaseType(typeof(UIImageView))]
    interface UIImageView_HighlightedWebCache
    {
        // -(void)sd_setHighlightedImageWithURL:(NSURL * _Nullable)url;
        [Export("sd_setHighlightedImageWithURL:")]
        void Sd_setHighlightedImageWithURL([NullAllowed] NSUrl url);

        // -(void)sd_setHighlightedImageWithURL:(NSURL * _Nullable)url options:(SDWebImageOptions)options;
        [Export("sd_setHighlightedImageWithURL:options:")]
        void Sd_setHighlightedImageWithURL([NullAllowed] NSUrl url, SDWebImageOptions options);

        // -(void)sd_setHighlightedImageWithURL:(NSURL * _Nullable)url completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setHighlightedImageWithURL:completed:")]
        void Sd_setHighlightedImageWithURL([NullAllowed] NSUrl url, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setHighlightedImageWithURL:(NSURL * _Nullable)url options:(SDWebImageOptions)options completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setHighlightedImageWithURL:options:completed:")]
        void Sd_setHighlightedImageWithURL([NullAllowed] NSUrl url, SDWebImageOptions options, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setHighlightedImageWithURL:(NSURL * _Nullable)url options:(SDWebImageOptions)options progress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setHighlightedImageWithURL:options:progress:completed:")]
        void Sd_setHighlightedImageWithURL([NullAllowed] NSUrl url, SDWebImageOptions options, [NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDExternalCompletionBlock completedBlock);
    }

    // @interface WebCache (UIImageView)
    [Category]
    [BaseType(typeof(UIImageView))]
    interface UIImageView_WebCache
    {
        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url;
        [Export("sd_setImageWithURL:")]
        void Sd_setImageWithURL([NullAllowed] NSUrl url);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder;
        [Export("sd_setImageWithURL:placeholderImage:")]
        void Sd_setImageWithURL([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options;
        [Export("sd_setImageWithURL:placeholderImage:options:")]
        void Sd_setImageWithURL([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:completed:")]
        void Sd_setImageWithURL([NullAllowed] NSUrl url, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:placeholderImage:completed:")]
        void Sd_setImageWithURL([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:placeholderImage:options:completed:")]
        void Sd_setImageWithURL([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options progress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithURL:placeholderImage:options:progress:completed:")]
        void Sd_setImageWithURL([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setImageWithPreviousCachedImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options progress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_setImageWithPreviousCachedImageWithURL:placeholderImage:options:progress:completed:")]
        void Sd_setImageWithPreviousCachedImageWithURL([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_setAnimationImagesWithURLs:(NSArray<NSURL *> * _Nonnull)arrayOfURLs;
        [Export("sd_setAnimationImagesWithURLs:")]
        void Sd_setAnimationImagesWithURLs(NSUrl[] arrayOfURLs);

        // -(void)sd_cancelCurrentAnimationImagesLoad;
        [Export("sd_cancelCurrentAnimationImagesLoad")]
        void Sd_cancelCurrentAnimationImagesLoad();
    }

    // typedef void (^SDSetImageBlock)(UIImage * _Nullable, NSData * _Nullable);
    delegate void SDSetImageBlock([NullAllowed] UIImage arg0, [NullAllowed] NSData arg1);

    // @interface WebCache (UIView)
    [Category]
    [BaseType(typeof(UIView))]
    interface UIView_WebCache
    {
        // -(NSURL * _Nullable)sd_imageURL;
        [NullAllowed, Export("sd_imageURL")]
        NSUrl Sd_imageURL();

        // -(void)sd_internalSetImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options operationKey:(NSString * _Nullable)operationKey setImageBlock:(SDSetImageBlock _Nullable)setImageBlock progress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDExternalCompletionBlock _Nullable)completedBlock;
        [Export("sd_internalSetImageWithURL:placeholderImage:options:operationKey:setImageBlock:progress:completed:")]
        void Sd_internalSetImageWithURL([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] string operationKey, [NullAllowed] SDSetImageBlock setImageBlock, [NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDExternalCompletionBlock completedBlock);

        // -(void)sd_internalSetImageWithURL:(NSURL * _Nullable)url placeholderImage:(UIImage * _Nullable)placeholder options:(SDWebImageOptions)options operationKey:(NSString * _Nullable)operationKey setImageBlock:(SDSetImageBlock _Nullable)setImageBlock progress:(SDWebImageDownloaderProgressBlock _Nullable)progressBlock completed:(SDExternalCompletionBlock _Nullable)completedBlock context:(NSDictionary * _Nullable)context;
        [Export("sd_internalSetImageWithURL:placeholderImage:options:operationKey:setImageBlock:progress:completed:context:")]
        void Sd_internalSetImageWithURL([NullAllowed] NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] string operationKey, [NullAllowed] SDSetImageBlock setImageBlock, [NullAllowed] SDWebImageDownloaderProgressBlock progressBlock, [NullAllowed] SDExternalCompletionBlock completedBlock, [NullAllowed] NSDictionary context);

        // -(void)sd_cancelCurrentImageLoad;
        [Export("sd_cancelCurrentImageLoad")]
        void Sd_cancelCurrentImageLoad();

        // -(void)sd_setShowActivityIndicatorView:(BOOL)show;
        [Export("sd_setShowActivityIndicatorView:")]
        void Sd_setShowActivityIndicatorView(bool show);

        // -(void)sd_setIndicatorStyle:(UIActivityIndicatorViewStyle)style;
        [Export("sd_setIndicatorStyle:")]
        void Sd_setIndicatorStyle(UIActivityIndicatorViewStyle style);

        // -(BOOL)sd_showActivityIndicatorView;
        [Export("sd_showActivityIndicatorView")]
        bool Sd_showActivityIndicatorView();

        // -(void)sd_addActivityIndicator;
        [Export("sd_addActivityIndicator")]
        void Sd_addActivityIndicator();

        // -(void)sd_removeActivityIndicator;
        [Export("sd_removeActivityIndicator")]
        void Sd_removeActivityIndicator();
    }

    // @interface WebCacheOperation (UIView)
    [Category]
    [BaseType(typeof(UIView))]
    interface UIView_WebCacheOperation
    {
        // -(void)sd_setImageLoadOperation:(id _Nullable)operation forKey:(NSString * _Nullable)key;
        [Export("sd_setImageLoadOperation:forKey:")]
        void Sd_setImageLoadOperation([NullAllowed] NSObject operation, [NullAllowed] string key);

        // -(void)sd_cancelImageLoadOperationWithKey:(NSString * _Nullable)key;
        [Export("sd_cancelImageLoadOperationWithKey:")]
        void Sd_cancelImageLoadOperationWithKey([NullAllowed] string key);

        // -(void)sd_removeImageLoadOperationWithKey:(NSString * _Nullable)key;
        [Export("sd_removeImageLoadOperationWithKey:")]
        void Sd_removeImageLoadOperationWithKey([NullAllowed] string key);
    }
}