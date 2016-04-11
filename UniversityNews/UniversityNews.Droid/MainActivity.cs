using Android.App;
using Android.Content.PM;
using Android.OS;
//using Plugin.Toasts;

namespace UniversityNews.Droid
{
    [Activity(Label = "UniversityNews", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            //DependencyService.Register<ToastNotificatorImplementation>();
            //ToastNotificatorImplementation.Init(this);
        }
    }
}

