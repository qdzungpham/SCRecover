using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.WebBrowser;
using System.Windows.Input;

namespace SCRecover.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {
        public ICommand MakeAClaimGoCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<MakeAClaimViewModel>());
            }
        }

        public ICommand AccidentHistoryGoCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<AccidentHistoryViewModel>());
            }
        }

        public ICommand ContactUsClick
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<ContactUsViewModel>());
            }
        }

        public ICommand FindProviderGoCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<FindProviderViewModel>());
            }
        }

        public ICommand MyProfileGoCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<MyProfileViewModel>());
            }
        }

        public ICommand RetrieveQuoteCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    MvvmCross.Plugins.WebBrowser.PluginLoader.Instance.EnsureLoaded();
                    Mvx.Resolve<IMvxWebBrowserTask>().ShowWebPage("https://insurance.suncorp.com.au/directlife/pub/suncorp/injury/retrieveapplication");
                });
            }
        }

    }
}
