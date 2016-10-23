using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Lang;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;
using System;

namespace SCRecover.Droid.Views
{
    [Activity(Label = "Claim information", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MakeAClaimView : MvxActivity
    {
        private MvxDatePicker _datePicker;
        private EditText _editTextDate;
        private Button _buttonDateDone;

        private MvxTimePicker _timePicker;
        private EditText _editTextTime;
        private Button _buttonTimeDone;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MakeAClaim);

            #region DatePicker and TimePicker
            _datePicker = FindViewById<MvxDatePicker>(Resource.Id.datePicker);
            _editTextDate = FindViewById<EditText>(Resource.Id.editTextDate);
            _buttonDateDone = FindViewById<Button>(Resource.Id.buttonDateDone);
            _datePicker.Visibility = ViewStates.Gone;
            _buttonDateDone.Visibility = ViewStates.Gone;
            _editTextDate.Focusable = false;
            _editTextDate.Click += delegate
            {
                _datePicker.Visibility = ViewStates.Visible;
                _buttonDateDone.Visibility = ViewStates.Visible;
            };
            _buttonDateDone.Click += delegate
            {
                _datePicker.Visibility = ViewStates.Gone;
                _buttonDateDone.Visibility = ViewStates.Gone;
            };

            _timePicker = FindViewById<MvxTimePicker>(Resource.Id.timePicker);
            _editTextTime = FindViewById<EditText>(Resource.Id.editTextTime);
            _buttonTimeDone = FindViewById<Button>(Resource.Id.buttonTimeDone);
            _timePicker.Visibility = ViewStates.Gone;
            _buttonTimeDone.Visibility = ViewStates.Gone;
            _editTextTime.Focusable = false;
            _editTextTime.Click += delegate
            {
                _timePicker.Visibility = ViewStates.Visible;
                _buttonTimeDone.Visibility = ViewStates.Visible;
            };
            _buttonTimeDone.Click += delegate
            {
                _timePicker.Visibility = ViewStates.Gone;
                _buttonTimeDone.Visibility = ViewStates.Gone;
            };

            #endregion

      
            

         
        }


    }
}
