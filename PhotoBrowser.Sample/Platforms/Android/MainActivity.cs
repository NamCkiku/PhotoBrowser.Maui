using Android.App;
using Android.Content.PM;
using Android.OS;

namespace PhotoBrowser.Sample
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = false,
        LaunchMode = LaunchMode.SingleTask, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait, Exported = true)]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}
