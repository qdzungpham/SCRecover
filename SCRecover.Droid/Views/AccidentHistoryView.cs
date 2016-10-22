using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;

namespace SCRecover.Droid.Views
{
    [Activity(Label = "Accident history")]
    public class AccidentHistoryView : MvxActivity
    {
        private MvxListView _listViewDelete;
        private MvxListView _listViewNormal;
        private ImageButton _btnDelete;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AccidentHistory);

            _listViewDelete = FindViewById<MvxListView>(Resource.Id.listViewDelete);
            _listViewNormal = FindViewById<MvxListView>(Resource.Id.listViewNormal);
            _btnDelete = FindViewById<ImageButton>(Resource.Id.btnDelete);
            _listViewDelete.Visibility = ViewStates.Gone;
            _btnDelete.Click += delegate
            {
                _listViewDelete.Visibility = ViewStates.Visible;
                _listViewNormal.Visibility = ViewStates.Gone;
            };

        }
    }
}