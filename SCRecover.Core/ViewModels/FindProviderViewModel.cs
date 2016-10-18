using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.PhoneCall;

using System.Collections.ObjectModel;
using System.Windows.Input;
using SCRecover.Core.Models;
using SCRecover.Core.Database;
using SCRecover.Core.Interfaces;
using System.Collections.Generic;

namespace SCRecover.Core.ViewModels
{
    public class FindProviderViewModel
        : MvxViewModel
    {
        public ICommand NavBackCommand
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }
        

        public FindProviderViewModel()
        {
           
            LoadProviders(); 
        }

        private ObservableCollection<ProviderDetails> _providers;
        public ObservableCollection<ProviderDetails> Providers
        {
            get { return _providers; }
            set { if (_providers != value) { _providers = value; RaisePropertyChanged(() => Providers); } }
        }

        public class Thing
        {
            public Thing(string caption)
            {
                Caption = caption;
            }

            public string Caption { get; private set; }

            public override string ToString()
            {
                return Caption;
            }

            public override bool Equals(object obj)
            {
                var rhs = obj as Thing;
                if (rhs == null)
                    return false;
                return rhs.Caption == Caption;
            }

            public override int GetHashCode()
            {
                if (Caption == null)
                    return 0;
                return Caption.GetHashCode();
            }
        }

        private List<Thing> _providerTypes = new List<Thing>()
        {
            new Thing("None"),
            new Thing("Acupuncturist"),
            new Thing("Chiropractor"),
            new Thing("Dental Prosthetist"),
            new Thing("Dentist"),
            new Thing("Hearing Aids"),
            new Thing("Hospitals"),
            new Thing("Naturopath"),
            new Thing("Optical"),
            new Thing("Physiotherapist"),
            new Thing("Podiatrist"),
            new Thing("Remedial Massage Therapist"),
        };

        public List<Thing> ProviderTypes
        {
            get { return _providerTypes; }
            set { _providerTypes = value; RaisePropertyChanged(() => ProviderTypes); }
        }

        private Thing _selectedType = new Thing("None");
        public Thing SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value; RaisePropertyChanged(() => SelectedType);
                LoadProviders();
                RaisePropertyChanged(() => Providers);
            }
        }

        public ICommand SelectProviderCommand
        {
            get
            {
                return new MvxCommand<ProviderDetails>(selectedProvider => ShowViewModel<ProviderMapViewModel>( new
                {
                    name = selectedProvider.Name,
                    address = selectedProvider.Address,
                    phoneNum = selectedProvider.PhoneNum,
                    lat = selectedProvider.Lat,
                    lng = selectedProvider.Lng

                }));
            }
        }

        public void LoadProviders()
        {
            if (_selectedType.ToString() == "Acupuncturist")
            {
                Acupuncturist();
            } else if (_selectedType.ToString() == "Chiropractor")
            {
                Chiropractor();
            }
        }

        public void Acupuncturist()
        {
            ObservableCollection<ProviderDetails> newProviders = new ObservableCollection<ProviderDetails>();
            newProviders.Add(new ProviderDetails() { Name = "Mrs Anjeleen Koklas", Address = "586 Stanley St, Woolloongabba QLD 4102", Type = "Acupuncturist", Lat = "-27.485337", Lng = "153.029057", PhoneNum = "0738461222" });
            newProviders.Add(new ProviderDetails() { Name = "Mrs Gavin Scott", Address = "61 Petrie Terrace, Brisbane City QLD 4000", Type = "Acupuncturist", Lat = "-27.465533", Lng = "153.013358", PhoneNum = "0733670333" });

            Providers = newProviders;
        }

        public void Chiropractor()
        {
            ObservableCollection<ProviderDetails> newProviders = new ObservableCollection<ProviderDetails>();
            
            newProviders.Add(new ProviderDetails() { Name = "Dr Miki Humphrey", Address = "300 Elizabeth St, Brisbane City QLD 4000", Type = "Chiropractor", Lat = "-27.467840", Lng = "153.029038", PhoneNum = "0424785699" });

            Providers = newProviders;
        }


    }
}