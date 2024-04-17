using Android.App;
using Android.Content;
using Android.Content.PM;
using AndroidX.AppCompat.App;

namespace PhotoBrowser.Sample
{
    [Activity(MainLauncher = true, NoHistory = true, Theme = "@style/MainTheme.Splash", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreenActivity : AppCompatActivity
    {
        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(new Intent(MainApplication.Context, typeof(MainActivity)));
        }
    }
}