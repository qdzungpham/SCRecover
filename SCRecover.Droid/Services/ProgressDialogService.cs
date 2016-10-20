using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using SCRecover.Core.Interfaces;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace SCRecover.Droid.Services
{
    public class ProgressDialogService : IProgressDialogService
    {
        ProgressDialog pd;



        public async Task Show(string title, string message)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                var mvxTopActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
                pd = new ProgressDialog(mvxTopActivity.Activity);
                pd.Indeterminate = true;
                pd.SetProgressStyle(ProgressDialogStyle.Spinner);
                pd.SetTitle(title);
                pd.SetMessage(message);
                pd.SetCancelable(false);
                pd.Show();
            }, null);
            
        }

        public async Task Show(string message)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                var mvxTopActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
                pd = new ProgressDialog(mvxTopActivity.Activity);
                pd.Indeterminate = true;
                pd.SetProgressStyle(ProgressDialogStyle.Spinner);
                pd.SetMessage(message);
                pd.SetCancelable(false);
                pd.Show();
            }, null);

        }

        public async Task Dismiss()
        {
            pd.Dismiss();
        }
    }
}