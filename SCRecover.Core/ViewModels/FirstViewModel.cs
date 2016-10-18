using MvvmCross.Core.ViewModels;
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


    }
}
