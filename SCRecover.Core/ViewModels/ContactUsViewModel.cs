using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.PhoneCall;
using MvvmCross.Plugins.WebBrowser;
using System.Windows.Input;

namespace SCRecover.Core.ViewModels
{
    public class ContactUsViewModel
        : MvxViewModel
    {
        public ICommand NavBackCommand
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }
        public ICommand CallGeneralCommand
        {
            get
            {
                return new MvxCommand(() => {
                    MvvmCross.Plugins.PhoneCall.PluginLoader.Instance.EnsureLoaded();
                    Mvx.Resolve<IMvxPhoneCallTask>().MakePhoneCall("General enquiries", "132524");
                });
            }
        }

        public ICommand CallPaymentCommand
        {
            get
            {
                return new MvxCommand(() => {
                    MvvmCross.Plugins.PhoneCall.PluginLoader.Instance.EnsureLoaded();
                    Mvx.Resolve<IMvxPhoneCallTask>().MakePhoneCall("Payments", "113113");
                });
            }
        }

        public ICommand CallInterCommand
        {
            get
            {
                return new MvxCommand(() => {
                    MvvmCross.Plugins.PhoneCall.PluginLoader.Instance.EnsureLoaded();
                    Mvx.Resolve<IMvxPhoneCallTask>().MakePhoneCall("International", "61733621222");
                });
            }
        }

        public ICommand CallMedicalCommand
        {
            get
            {
                return new MvxCommand(() => {
                    MvvmCross.Plugins.PhoneCall.PluginLoader.Instance.EnsureLoaded();
                    Mvx.Resolve<IMvxPhoneCallTask>().MakePhoneCall("Medical assistance", "113113");
                });
            }
        }

        public ICommand GooglePlusCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    MvvmCross.Plugins.WebBrowser.PluginLoader.Instance.EnsureLoaded();
                    Mvx.Resolve<IMvxWebBrowserTask>().ShowWebPage("https://plus.google.com/+SuncorpInsuranceBrisbane");
                });
            }
        }

        public ICommand FacebookCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    MvvmCross.Plugins.WebBrowser.PluginLoader.Instance.EnsureLoaded();
                    Mvx.Resolve<IMvxWebBrowserTask>().ShowWebPage("https://www.facebook.com/SuncorpInsurance/");
                });
            }
        }

        public ICommand YoutubeCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    MvvmCross.Plugins.WebBrowser.PluginLoader.Instance.EnsureLoaded();
                    Mvx.Resolve<IMvxWebBrowserTask>().ShowWebPage("https://www.youtube.com/user/suncorpinsurance");
                });
            }
        }
    }
}