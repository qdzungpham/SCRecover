using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace SCRecover.Droid.Views
{
    [Activity(Label = "My profile", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MyProfileView : MvxActivity
    {
        private ImageButton _edit;
        private ImageButton _save;
        private EditText _fullName;
        private EditText _dob;
        private EditText _policyNum;
        private EditText _phoneNum;
        private EditText _email;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MyProfile);

            _edit = FindViewById<ImageButton>(Resource.Id.edit);
            _save = FindViewById<ImageButton>(Resource.Id.save);
            _fullName = FindViewById<EditText>(Resource.Id.fullName);
            _dob = FindViewById<EditText>(Resource.Id.dob);
            _policyNum = FindViewById<EditText>(Resource.Id.policyNum);
            _phoneNum = FindViewById<EditText>(Resource.Id.phoneNum);
            _email = FindViewById<EditText>(Resource.Id.email);

            _save.Visibility = ViewStates.Gone;
            _fullName.Enabled = false;
            _dob.Enabled = false;
            _policyNum.Enabled = false;
            _phoneNum.Enabled = false;
            _email.Enabled = false;

            _edit.Click += delegate
            {
                _fullName.Enabled = true;
                _dob.Enabled = true;
                _policyNum.Enabled = true;
                _phoneNum.Enabled = true;
                _email.Enabled = true;
                _edit.Visibility = ViewStates.Gone;
                _save.Visibility = ViewStates.Visible;
            };

            _save.Click += delegate
            {
                _fullName.Enabled = false;
                _dob.Enabled = false;
                _policyNum.Enabled = false;
                _phoneNum.Enabled = false;
                _email.Enabled = false;
                _edit.Visibility = ViewStates.Visible;
                _save.Visibility = ViewStates.Gone;
            };
        }
    }
}