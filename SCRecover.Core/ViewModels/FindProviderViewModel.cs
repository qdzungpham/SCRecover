using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.PhoneCall;

using System.Collections.ObjectModel;
using System.Windows.Input;
using SCRecover.Core.Models;

namespace SCRecover.Core.ViewModels
{
    public class FindProviderViewModel
        : MvxViewModel
    {
        public ICommand AcupuncturistGoCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<AcupuncturistViewModel>());
            }
        }



    }

    public class AcupuncturistViewModel
        : MvxViewModel
    {
        public ICommand MapViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<ProviderMapViewModel>());
            }
        }

        

        



    }
}