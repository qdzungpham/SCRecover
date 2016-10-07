using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.PhoneCall;

using System.Windows.Input;

namespace SCRecover.Core.ViewModels
{
    public class ProviderMapViewModel
        : MvxViewModel
    {
        

        private ProviderDetails _provider;
        public ProviderDetails Provider
        {
            get { return _provider; }
            set { _provider = value;  RaisePropertyChanged(() => _provider); }
        }

        public ProviderMapViewModel()
        {
            _provider = new ProviderDetails()
            {
                Name = _providerName,
                Address = _providerAddress,
                PhoneNum = _providerPhoneNum,
                Location = new Location()
                {
                    Lat = -27.477353,
                    Lng = 153.028421
                }
            };
        }

        public string _providerName = "QUT Gardens Point Campus";
        public string ProviderName
        {
            get { return _providerName; }
            set { _providerName = value;  RaisePropertyChanged(() => ProviderName); }
        }

        public string _providerAddress = "2 George St, Brisbane City QLD 4000";
        public string ProviderAddress
        {
            get { return _providerAddress; }
            set { _providerAddress = value; RaisePropertyChanged(() => ProviderAddress); }
        }

        public int _providerPhoneNum = 0731382000;
        public int ProviderPhoneNum
        {
            get { return _providerPhoneNum; }
            set { _providerPhoneNum = value; RaisePropertyChanged(() => ProviderPhoneNum); }
        }



    }

    public class Location
        : MvxNotifyPropertyChanged
    {
        private double _lat;
        public double Lat
        {
            get { return _lat; }
            set { _lat = value; RaisePropertyChanged(() => Lat); }
        }

        private double _lng;
        public double Lng
        {
            get { return _lng; }
            set { _lng = value; RaisePropertyChanged(() => Lng); }
        }

        public override bool Equals(object obj)
        {
            var lRhs = obj as Location;
            if (lRhs == null)
                return false;

            return lRhs.Lat == Lat && lRhs.Lng == Lng;
        }

        public override int GetHashCode()
        {
            return Lat.GetHashCode() + Lng.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0:0.00000} {1:0.00000}", Lat, Lng);
        }
    }

    public class ProviderDetails
        : MvxNotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(() => Name); }
        }

        private Location _location;
        public Location Location
        {
            get { return _location; }
            set { _location = value; RaisePropertyChanged(() => Location); }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; RaisePropertyChanged(() => Type); }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; RaisePropertyChanged(() => Address); }
        }

        private int _phoneNum;
        public int PhoneNum
        {
            get { return _phoneNum; }
            set { _phoneNum = value; RaisePropertyChanged(() => PhoneNum); }
        }




        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Location);
        }
    }
}