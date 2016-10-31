using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Views;


namespace SCRecover.Droid.Views
{
    [Activity(Label = "Home screen", ScreenOrientation = ScreenOrientation.Portrait)]
    public class FirstView : MvxActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);



        }
       
    }
}
