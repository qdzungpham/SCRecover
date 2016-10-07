using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace SCRecover.Droid.Views
{
    [Activity(Label = "Find Provider")]
    public class FindProviderView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FindMedicalProvider);


        }
    }

    [Activity(Label = "Acupuncturist")]
    public class AcupuncturistView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Acupuncturist);


        }
    }
}