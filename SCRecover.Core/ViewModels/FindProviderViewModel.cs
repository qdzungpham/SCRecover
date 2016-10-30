using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.PhoneCall;

using System.Collections.ObjectModel;
using System.Windows.Input;
using SCRecover.Core.Models;
using SCRecover.Core.Database;
using SCRecover.Core.Interfaces;
using System.Collections.Generic;

using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

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
           // new Thing("Dental Prosthetist"),
            new Thing("Dentist"),
            new Thing("Hearing Aids"), //Its called ENT
            new Thing("Hospitals"),
            //new Thing("Naturopath"),
            new Thing("Optometrist"),
            new Thing("Physiotherapist"),
            new Thing("Podiatrist"),
            
           // new Thing("Remedial Massage Therapist"),
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

        public async void CheckPermission(ProviderDetails selectedProvider)
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            if (status != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
                status = results[Permission.Location];
            }
            if (status == PermissionStatus.Granted)
            {
                ShowViewModel<ProviderMapViewModel>(new
                {
                    name = selectedProvider.Name,
                    address = selectedProvider.Address,
                    phoneNum = selectedProvider.PhoneNum,
                    lat = selectedProvider.Lat,
                    lng = selectedProvider.Lng

                });
            }
        }
        public ICommand SelectProviderCommand
        {
            get
            {
                return new MvxCommand<ProviderDetails>(selectedProvider => CheckPermission(selectedProvider));
            }
        }

        public void LoadProviders()
        {
            if (_selectedType.ToString() == "Acupuncturist")
            {
                Acupuncturist();
            }

            else if (_selectedType.ToString() == "Chiropractor")
            {
                Chiropractor();
            }

            else if (_selectedType.ToString() == "Physiotherapist")
            {
                Physiotherapist();
            }

            else if (_selectedType.ToString() == "Cardiologist")
            {
                Cardiologist();
            }

            else if (_selectedType.ToString() == "Dentist")
            {
                Dentist();
            }

            else if (_selectedType.ToString() == "Optometrist")
            {
                Optometrist();
			}

            else if (_selectedType.ToString() == "Podiatrist")
            {
                Podiatrist();
			}

            else if (_selectedType.ToString() == "Hospitals")
            {
                Hospitals();
            }

            else
            {
                ObservableCollection<ProviderDetails> newProviders = new ObservableCollection<ProviderDetails>();
                Providers = newProviders;
            }
        }

        public void Acupuncturist()
        {
            ObservableCollection<ProviderDetails> newProviders = new ObservableCollection<ProviderDetails>();

            newProviders.Add(new ProviderDetails() { Name = "Dr Anjeleen Brando", Address = "586 Stanley St, Woolloongabba QLD 4102", Type = "Acupuncturist", Lat = "-27.485337", Lng = "153.029057", PhoneNum = "0738461222" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Oona Paquin", Address = "61 Petrie Terrace, Brisbane City QLD 4000", Type = "Acupuncturist", Lat = "-27.465533", Lng = "153.013358", PhoneNum = "0733670333" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Denzel Smith", Address = "738 Main St, Kangaroo Point QLD 4169", Type = "Acupuncturist", Lat = "-27.482205", Lng = "153.036073", PhoneNum = "0734417095" });

            Providers = newProviders;
        }

        public void Chiropractor()
        {
            ObservableCollection<ProviderDetails> newProviders = new ObservableCollection<ProviderDetails>();

            newProviders.Add(new ProviderDetails() { Name = "Dr Miki Humphrey", Address = "300 Elizabeth St, Brisbane City QLD 4000", Type = "Chiropractor", Lat = "-27.467840", Lng = "153.029038", PhoneNum = "0424785699" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Nathan Bogart", Address = "101 Middle St, Coopers Plains QLD 4108", Type = "Chiropractor", Lat = "-27.561293", Lng = "153.046230", PhoneNum = "0423783888" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Lauren Muriel Wilde", Address = "1007 Stanley St E, East Brisbane QLD 4169", Type = "Chiropractor", Lat = "-27.488175", Lng = "153.049572", PhoneNum = "0730092341" });

            Providers = newProviders;
        }

        public void Physiotherapist()
        {
            ObservableCollection<ProviderDetails> newProviders = new ObservableCollection<ProviderDetails>();

            newProviders.Add(new ProviderDetails() { Name = "Dr Stacy Moore", Address = "12 Edna St, Salisbury QLD 4107", Type = "Physiotherapist", Lat = "-27.549229", Lng = "153.039875", PhoneNum = "0731101659" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Benjamin Brown", Address = "82 Eagle St, Brisbane City QLD 4000", Type = "Physiotherapist", Lat = "-27.466756", Lng = "153.029235", PhoneNum = "0428782611" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Mikala Craig", Address = "1/78 Merthyr Rd, New Farm QLD 4005", Type = "Physiotherapist", Lat = "-27.466714", Lng = "153.045682", PhoneNum = "0736594643" });

            Providers = newProviders;
        }

        public void Cardiologist()
        {
            ObservableCollection<ProviderDetails> newProviders = new ObservableCollection<ProviderDetails>();

            newProviders.Add(new ProviderDetails() { Name = "Dr Katherine Tarantino", Address = "Suite 212, Level 2, Ramsay Specialist Centre, Newdegate Street, Greenslopes QLD 4120", Type = "Cardiologist", Lat = "-27.511666", Lng = "153.047965", PhoneNum = "0474766621" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Audrey Fonda", Address = "8/457 Wickham Terrace, Spring Hill QLD 4000", Type = "Cardiologist", Lat = "-27.461615", Lng = "153.021361", PhoneNum = "0736722724" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Cary Mitchum", Address = "293 Vulture St, South Brisbane QLD 4101", Type = "Cardiologist", Lat = "-27.484011", Lng = "153.028291", PhoneNum = "0737282988" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Henry Scorsese", Address = "2 Newdegate St, Greenslopes QLD 4120", Type = "Cardiologist", Lat = "-27.509658", Lng = "153.046476", PhoneNum = "04111185314" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Quentin Mann", Address = "40 Chasely St, Auchenflower QLD 4066", Type = "Cardiologist", Lat = "-27.476096", Lng = "152.998127", PhoneNum = "0731296433" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Natalie Williams", Address = "457 Wickham Terrace, Spring Hill QLD 4000", Type = "Cardiologist", Lat = "-27.461408", Lng = "153.020034", PhoneNum = "0445357621" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Chandler Triabbiani", Address = "South Medical Suites, 3/627 Rode Rd, Chermside QLD 4032", Type = "Cardiologist", Lat = "-27.386199", Lng = "153.021789", PhoneNum = "0734441680" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Andy Torme", Address = "OPSM Mount Ommaney, 6/171 Dandenong Rd, Mount Ommaney QLD 4074", Type = "Cardiologist", Lat = "-27.549699", Lng = "152.938911", PhoneNum = "0732251988" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Natasha Lavigne", Address = "Unit 8, 43 Lang Parade, Milton QLD 4026", Type = "Cardiologist", Lat = "-27.473439", Lng = "153.001847", PhoneNum = "0731152777" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Elizabeth Hepburn", Address = "119 Queen St., Cleveland QLD 4163", Type = "Cardiologist", Lat = "-27.527124", Lng = "153.267256", PhoneNum = "0412257556" });

            Providers = newProviders;

        }
        public void Dentist()
        {
            ObservableCollection<ProviderDetails> newProviders = new ObservableCollection<ProviderDetails>();

            newProviders.Add(new ProviderDetails() { Name = "Dr Elaine Seinfeld", Address = "52 Henley St, Coopers Plains QLD 4108", Type = "Dentist", Lat = "-27.568688", Lng = "153.036258", PhoneNum = "0426185311" });

            newProviders.Add(new ProviderDetails() { Name = "Dr George Benes", Address = "25 Mary St, Brisbane City QLD 4000", Type = "Dentist", Lat = "-27.472825", Lng = "153.026461", PhoneNum = "0732156534" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Jerry Kramer", Address = "79 Adelaide St, Brisbane City QLD 4000", Type = "Dentist", Lat = "-27.469647", Lng = "153.023897", PhoneNum = "0731369188" });
			
			Providers = newProviders;
        }

        public void Optometrist()
        {
            ObservableCollection<ProviderDetails> newProviders = new ObservableCollection<ProviderDetails>();

            newProviders.Add(new ProviderDetails() { Name = "Dr Shiro Khan", Address = "132 Beaudesert Rd, Moorooka QLD 4105", Type = "Optometrist", Lat = "-27.531914", Lng = "153.024323", PhoneNum = "07398985233" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Sasuke Goldman", Address = "Travelex, 4/217 George St, Brisbane City QLD 4000", Type = "Optometrist", Lat = "-27.470982", Lng = "153.023561", PhoneNum = "0424745191" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Siyu !Awolowo", Address = "Rowes Arcade, 235 Edward St, Brisbane City QLD 4000", Type = "Optometrist", Lat = "-27.466293", Lng = "153.025943", PhoneNum = "0733523646" });

            Providers = newProviders;

        }

        public void Podiatrist()
        {
            ObservableCollection<ProviderDetails> newProviders = new ObservableCollection<ProviderDetails>();

            newProviders.Add(new ProviderDetails() { Name = "Dr Alana Uzumaki", Address = "176 Beaudesert Rd, Moorooka QLD 4105", Type = "Podiatrist", Lat = "-27.533050", Lng = "153.024045", PhoneNum = "0472355649" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Hinata Smith", Address = "Suite 74, 7th Floor, Morris Towers, 149 Wickham Terrace, Spring Hill QLD 4000", Type = "Podiatrist", Lat = "-27.464820", Lng = "153.024542", PhoneNum = "0735216363" });

            newProviders.Add(new ProviderDetails() { Name = "Dr Anis Mohamed Corleone", Address = "4/219 Given Terrace, Paddington, Brisbane City QLD 4064", Type = "Podiatrist", Lat = "-27.460789", Lng = "153.005928", PhoneNum = "0734891125" });

            Providers = newProviders;
        }

        public void Hospitals()
        {
            ObservableCollection <ProviderDetails> newProviders = new ObservableCollection<ProviderDetails>();

            newProviders.Add(new ProviderDetails() { Name = "Coztanza Misericordiae Health Services", Address = "Raymond Terrace, South Brisbane QLD 4101", Type = "Hospitals", Lat = "-27.485047", Lng = "153.028512", PhoneNum = "0731238255" });

            newProviders.Add(new ProviderDetails() { Name = "DDS Private Hospital", Address = "259 Wickham Terrace, Brisbane City QLD 4000", Type = "Hospitals", Lat = "-27.464373", Lng = "153.022974", PhoneNum = "0732274188" });

            newProviders.Add(new ProviderDetails() { Name = "Psyber Void Hospital", Address = "2/527 Gregory Terrace, Bowen Hills QLD 4006", Type = "Hospitals", Lat = "-27.452164", Lng = "153.029370", PhoneNum = "0732225656" });

            newProviders.Add(new ProviderDetails() { Name = "Grant Moonshine Hospital", Address = "199 Ipswich Rd, Woolloongabba QLD 4102", Type = "Hospitals", Lat = "-27.499547", Lng = "153.033090", PhoneNum = "0731385421" });
            Providers = newProviders;
        }


    }
}