using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.PhoneCall;
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


    }
}