using MvvmCross.Core.ViewModels;
using SCRecover.Core.Interfaces;
using SCRecover.Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SCRecover.Core.ViewModels
{
    public class MyProfileViewModel
        : MvxViewModel
    {

        public ICommand NavBackCommand
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        private string _fullName = "";
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; RaisePropertyChanged(() => FullName); }
        }

        private string _doB = "";
        public string DateOfBirth
        {
            get { return _doB; }
            set { _doB = value; RaisePropertyChanged(() => DateOfBirth); }
        }

        private string _policyNum = "";
        public string PolicyNum
        {
            get { return _policyNum; }
            set { _policyNum = value; RaisePropertyChanged(() => PolicyNum); }
        }

        private string _phoneNum = "";
        public string PhoneNum
        {
            get { return _phoneNum; }
            set { _phoneNum = value; RaisePropertyChanged(() => PhoneNum); }
        }

        private string _email = "";
        public string Email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged(() => Email); }
        }

        private ClaimDetails _myProfile;
        public ClaimDetails MyProfile
        {
            get { return _myProfile; }
            set { if (_myProfile != value) { _myProfile = value; RaisePropertyChanged(() => MyProfile); } }
        }

        public async void LoadProfile()
        {
            await _dialog.Show("Loading...");
            MyProfile = await _savedClaimDatabase.GetProfile();
            await _dialog.Dismiss();
            FullName = _myProfile.FullName;
            DateOfBirth = _myProfile.DoB;
            PolicyNum = _myProfile.PolicyNum;
            PhoneNum = _myProfile.PhoneNum;
            Email = _myProfile.Email;
        }

        public async void UpdateProfile()
        {
            if (string.IsNullOrWhiteSpace(_fullName) || string.IsNullOrWhiteSpace(_doB) || string.IsNullOrWhiteSpace(_policyNum)
                || string.IsNullOrWhiteSpace(_phoneNum) || string.IsNullOrWhiteSpace(_email))
            {
                await _dialog.ShowToast("Please enter all fields.");
            }
            else
            {
                ClaimDetails newProfile = new ClaimDetails()
                {
                    FullName = _fullName,
                    DoB = _doB,
                    PolicyNum = _policyNum,
                    PhoneNum = _phoneNum,
                    Email = _email,
                    Extra = "profile"
                };

                MyProfile.FullName = _fullName;
                MyProfile.DoB = _doB;
                MyProfile.PolicyNum = _policyNum;
                MyProfile.PhoneNum = _phoneNum;
                MyProfile.Email = _email;
                await _dialog.Show("Save Profile Details", "Synchronising...");
                await _savedClaimDatabase.UpdateProfile(newProfile, _myProfile);
                await _dialog.Dismiss();
                await _dialog.ShowToast("Profile details saved.");
            }
        }

        public ICommand UpdateProfileCommand
        {
            get
            {

                return new MvxCommand(UpdateProfile);
            }
        }

        private readonly IDialogService _dialog;
        private readonly ISavedClaimsDatabase _savedClaimDatabase;
        public MyProfileViewModel(ISavedClaimsDatabase saveClaimDatabase, IDialogService dialog)
        {
            _savedClaimDatabase = saveClaimDatabase;
            _dialog = dialog;
            LoadProfile();
        }
    }
}
