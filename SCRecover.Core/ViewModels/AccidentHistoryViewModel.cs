using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.PhoneCall;
using SCRecover.Core.Interfaces;
using SCRecover.Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SCRecover.Core.ViewModels
{
    public class AccidentHistoryViewModel
        : MvxViewModel
    {
        private readonly ISavedClaimsDatabase _database;

        private ObservableCollection<ClaimDetails> _savedClaims;
        public ObservableCollection<ClaimDetails> SavedClaims
        {
            get { return _savedClaims; }
            set { if (_savedClaims != value) { _savedClaims = value; RaisePropertyChanged(() => SavedClaims); } }
        }

        private ObservableCollection<ClaimDetails> _submittedClaims;
        public ObservableCollection<ClaimDetails> SubmittedClaims
        {
            get { return _submittedClaims; }
            set { if (_submittedClaims != value) { _submittedClaims = value; RaisePropertyChanged(() => SubmittedClaims); } }
        }
        public async void LoadClaims()
        {
            SavedClaims = await _database.Filter("saved");
            SubmittedClaims = await _database.Filter("submitted");
        }
        public ICommand SelectSavedClaimCommand
        {
            get
            {
                return new MvxCommand<ClaimDetails>(selectedSavedClaim => ShowViewModel<MakeAClaimViewModel>(new
                {
                    fullName = selectedSavedClaim.FullName,
                    dob = selectedSavedClaim.DoB,
                    policyNum = selectedSavedClaim.PolicyNum,
                    date = selectedSavedClaim.Date,
                    time = selectedSavedClaim.Time,
                    location = selectedSavedClaim.Location,
                    type = selectedSavedClaim.Type,
                    injury = selectedSavedClaim.Injury,
                    cmt = selectedSavedClaim.Cmt

                }));
            }
        }

        public ICommand SelectSubmittedClaimCommand
        {
            get
            {
                return new MvxCommand<ClaimDetails>(selectedSavedClaim => ShowViewModel<ClaimSummaryViewModel>(new
                {
                    fullName = selectedSavedClaim.FullName,
                    doB = selectedSavedClaim.DoB,
                    policyNum = selectedSavedClaim.PolicyNum,
                    date = selectedSavedClaim.Date,
                    time = selectedSavedClaim.Time,
                    location = selectedSavedClaim.Location,
                    type = selectedSavedClaim.Type,
                    injury = selectedSavedClaim.Injury,
                    cmt = selectedSavedClaim.Cmt

                }));
            }
        }

        public ICommand AddClaimCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<MakeAClaimViewModel>());
            }
        }

        public ICommand NavBackCommand
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        public AccidentHistoryViewModel(ISavedClaimsDatabase database)
        {
            _database = database;
            LoadClaims();
        }

    }
}