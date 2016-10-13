using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.PhoneCall;

using System.Collections.ObjectModel;
using System.Windows.Input;
using SCRecover.Core.Models;
using SCRecover.Core.Database;
using SCRecover.Core.Interfaces;

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

        private readonly IProvidersDatabase _providerDatabase;

        public AcupuncturistViewModel(IProvidersDatabase providerDatabase)
        {
            _providerDatabase = providerDatabase;
            
            LoadProviders();
        }

        private ObservableCollection<ProviderDetails> _providers;
        public ObservableCollection<ProviderDetails> Providers
        {
            get { return _providers; }
            set { if (_providers != value) { _providers = value; RaisePropertyChanged(() => Providers); } }
        }

        public void PopulateProviders()
        {
            ObservableCollection<ProviderDetails> newProviders = new ObservableCollection<ProviderDetails>();
            newProviders.Add(new ProviderDetails() { Name = "Rick", Address = "14 Rothburn", Type = "Dentist", Lat = "011111", Lng = "122222", PhoneNum = "123123123" });
            newProviders.Add(new ProviderDetails() { Name = "Hang", Address = "14 Rothburn", Type = "Dentist", Lat = "011111", Lng = "122222", PhoneNum = "123123123" });

            _providerDatabase.InsertProvider(newProviders);
        }

        public async void LoadProviders()
        {
            PopulateProviders();
            this.Providers = await _providerDatabase.GetAll();
          
            //if (this.Providers == null || this.Providers.Count == 0)
            //{
            //    PopulateProviders();
            //    this.Providers = await _providerDatabase.GetAll();
            //}

        }



    }
}