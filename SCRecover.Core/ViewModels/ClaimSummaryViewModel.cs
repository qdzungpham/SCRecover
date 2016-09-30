using MvvmCross.Core.ViewModels;
using System.Linq;


namespace SCRecover.Core.ViewModels
{
    public class ClaimSummaryViewModel
        : MvxViewModel
    {
        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; RaisePropertyChanged(() => Type); }
        }

        private string _injury;
        public string Injury
        {
            get { return _injury; }
            set { _injury = value; RaisePropertyChanged(() => Injury); }
        }
        private string _fullName;
        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_fullName))
                {
                    return "No Information";
                }
                else
                {
                    return _fullName;
                }
            }
            set { _fullName = value; RaisePropertyChanged(() => FullName); }
        }

        private string _doB;
        public string DateOfBirth
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_doB))
                {
                    return "No Information";
                }
                else
                {
                    return _doB;
                }
            }
            set { _doB = value; RaisePropertyChanged(() => DateOfBirth); }
        }

        private string _policyNum;
        public string PolicyNum
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_policyNum))
                {
                    return "No Information";
                }
                else
                {
                    return _policyNum;
                }
            }
            set { _policyNum = value; RaisePropertyChanged(() => PolicyNum); }
        }

        private string _date;
        public string Date
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_date))
                {
                    return "No Information";
                }
                else
                {
                    return _date;
                }
            }
            set { _date = value; RaisePropertyChanged(() => Date); }
        }

        private string _time;
        public string Time
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_time))
                {
                    return "No Information";
                }
                else
                {
                    return _time;
                }
            }
            set { _time = value; RaisePropertyChanged(() => Time); }
        }

        private string _location;
        public string Location
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_location))
                {
                    return "No Information";
                }
                else
                {
                    return _location;
                }
            }
            set { _location = value; RaisePropertyChanged(() => Location); }
        }

        private string _cmt;
        public string Comment
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_cmt))
                {
                    return "No Information";
                }
                else
                {
                    return _cmt;
                }
            }
            set { _cmt = value; RaisePropertyChanged(() => Comment); }
        }

        public void Init(string fullName, string doB, string policyNum, string date, string time, string location, string type, string injury, string cmt)
        {
            _fullName = fullName;
            _doB = doB;
            _policyNum = policyNum;
            _date = date;
            _time = time;
            _location = location;
            _type = type;
            _injury = injury;
            _cmt = cmt;
        }
        


    }
}