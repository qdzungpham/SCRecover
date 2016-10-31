using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Text.Format;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;
using SCRecover.Core.ViewModels;
using System;

namespace SCRecover.Droid.Views
{
    [Activity(Label = "Claim information", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MakeAClaimView : MvxActivity
    {
        private EditText _editTextDoB;
        private EditText _editTextDate;
        private EditText _editTextTime;
        ProviderMapViewModel vm;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MakeAClaim);

            vm = ViewModel as ProviderMapViewModel;
            _editTextDoB = FindViewById<EditText>(Resource.Id.editTextDoB);
            _editTextDate = FindViewById<EditText>(Resource.Id.editTextDate);
            _editTextTime = FindViewById<EditText>(Resource.Id.editTextTime);
            _editTextDoB.Focusable = false;
            _editTextDate.Focusable = false;
            _editTextTime.Focusable = false;
            _editTextDoB.Click += DoBSelect_OnClick;
            _editTextDate.Click += DateSelect_OnClick;
            _editTextTime.Click += TimeSelect_OnClick;
        }

        void DoBSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _editTextDoB.Text = time.ToString("dd MMM yyyy");
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
        void DateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _editTextDate.Text = time.ToString("dd MMM yyyy");
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        void TimeSelect_OnClick(object sender, EventArgs eventArgs)
        {
            TimePickerFragment frag = TimePickerFragment.NewInstance(delegate (TimeSpan time)
            {
                _editTextTime.Text = time.ToString();
            });
            frag.Show(FragmentManager, TimePickerFragment.TAG);
        }
    }

    public class DatePickerFragment : DialogFragment,
                                  DatePickerDialog.IOnDateSetListener
    {
        // TAG can be any string of your choice.
        public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();

        // Initialize this value to prevent NullReferenceExceptions.
        Action<DateTime> _dateSelectedHandler = delegate { };

        public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
        {
            DatePickerFragment frag = new DatePickerFragment();
            frag._dateSelectedHandler = onDateSelected;
            return frag;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            DateTime currently = DateTime.Now;
            DatePickerDialog dialog = new DatePickerDialog(Activity,
                                                           this,
                                                           currently.Year,
                                                           currently.Month - 1,
                                                           currently.Day);
            return dialog;
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            // Note: monthOfYear is a value between 0 and 11, not 1 and 12!
            DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            Log.Debug(TAG, selectedDate.ToLongDateString());
            _dateSelectedHandler(selectedDate);
        }
    }

    public class TimePickerFragment : DialogFragment,
                                  TimePickerDialog.IOnTimeSetListener
    {
        // TAG can be any string of your choice.
        public static readonly string TAG = "X:" + typeof(TimePickerFragment).Name.ToUpper();

        // Initialize this value to prevent NullReferenceExceptions.
        Action<TimeSpan> _timeSelectedHandler = delegate { };

        public static TimePickerFragment NewInstance(Action<TimeSpan> onDateSelected)
        {
            TimePickerFragment frag = new TimePickerFragment();
            frag._timeSelectedHandler = onDateSelected;
            return frag;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            DateTime currently = DateTime.Now;
            TimePickerDialog dialog = new TimePickerDialog(Activity,
                                                           this,
                                                           currently.Hour,
                                                           currently.Minute,
                                                           true);
            return dialog;
        }

        public void OnTimeSet(TimePicker view, int hourOfDay, int minute)
        {
            TimeSpan selectedTime = new TimeSpan(hourOfDay, minute, 00);
            Log.Debug(TAG, selectedTime.ToString());
            _timeSelectedHandler(selectedTime);
        }
    }
}
