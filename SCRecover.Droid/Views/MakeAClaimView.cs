using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace SCRecover.Droid.Views
{
    [Activity(Label = "Claim information")]
    public class MakeAClaimView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MakeAClaim);


        }
    }
}
