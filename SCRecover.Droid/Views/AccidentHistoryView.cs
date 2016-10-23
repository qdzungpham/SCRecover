using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;

namespace SCRecover.Droid.Views
{
    [Activity(Label = "Accident history", ScreenOrientation = ScreenOrientation.Portrait)]
    public class AccidentHistoryView : MvxActivity
    {
        private MvxListView _savedClaimDelete;
        private MvxListView _savedClaimNormal;
        private MvxListView _submittedClaimDelete;
        private MvxListView _submittedClaimNormal;
        private ImageButton _btnDelete;
        private ImageButton _btnDone;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AccidentHistory);

            _savedClaimDelete = FindViewById<MvxListView>(Resource.Id.savedClaimDelete);
            _savedClaimNormal = FindViewById<MvxListView>(Resource.Id.savedClaimNormal);
            _submittedClaimDelete = FindViewById<MvxListView>(Resource.Id.submittedClaimDelete);
            _submittedClaimNormal = FindViewById<MvxListView>(Resource.Id.submittedClaimNormal);
            _btnDelete = FindViewById<ImageButton>(Resource.Id.btnDelete);
            _btnDone = FindViewById<ImageButton>(Resource.Id.btnDone);
            _savedClaimDelete.Visibility = ViewStates.Gone;
            _submittedClaimDelete.Visibility = ViewStates.Gone;
            _btnDone.Visibility = ViewStates.Gone;
            _btnDelete.Click += delegate
            {
                _savedClaimDelete.Visibility = ViewStates.Visible;
                _savedClaimNormal.Visibility = ViewStates.Gone;
                _submittedClaimDelete.Visibility = ViewStates.Visible;
                _submittedClaimNormal.Visibility = ViewStates.Gone;
                _btnDone.Visibility = ViewStates.Visible;
                _btnDelete.Visibility = ViewStates.Gone;
            };
            _btnDone.Click += delegate
            {
                _savedClaimDelete.Visibility = ViewStates.Gone;
                _savedClaimNormal.Visibility = ViewStates.Visible;
                _submittedClaimDelete.Visibility = ViewStates.Gone;
                _submittedClaimNormal.Visibility = ViewStates.Visible;
                _btnDone.Visibility = ViewStates.Gone;
                _btnDelete.Visibility = ViewStates.Visible;
            };

        }
    }
}