using MvvmCross.Core.ViewModels;
using System.Linq;


namespace SCRecover.Core.ViewModels
{
    public class ClaimSummaryViewModel
        : MvxViewModel
    {
        private string _type;
        private string _injury;
        
        

        public string Type
        {
            get { return _type; }
            set { _type = value; RaisePropertyChanged(() => Type); }
        }

        public string Injury
        {
            get { return _injury; }
            set { _injury = value; RaisePropertyChanged(() => Injury); }
        }

        public void Init(string type, string injury)
        {
            _type = type;
            _injury = injury;
        }
        


    }
}