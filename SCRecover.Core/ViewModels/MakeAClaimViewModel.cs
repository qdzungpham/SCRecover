using MvvmCross.Core.ViewModels;
using System.IO;
using System;
using System.Collections.Generic;
using MvvmCross.Plugins.PictureChooser;
using System.Windows.Input;
using SCRecover.Core.Interfaces;
using SCRecover.Core.Database;
using SCRecover.Core.Models;

using System.Collections.ObjectModel;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace SCRecover.Core.ViewModels
{
    public class MakeAClaimViewModel
        : MvxViewModel
    {
        public ICommand NavBackCommand
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }
        // Datepicker and timepicker
        private string _date = DateTime.Now.ToString("dd MMM yyyy");
        private string _time = DateTime.Now.ToString("hh:mm:00");

        public string Date
        {
            get { return _date; }
            set { _date = value; RaisePropertyChanged(() => Date); }
        }

        public string Time
        {
            get { return _time; }
            set { _time = value; RaisePropertyChanged(() => Time); }
        }

        // Select type and specificed injury
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
        private List<Thing> _types = new List<Thing>()
        {
            new Thing("None"),
            new Thing("Fracture"),
            new Thing("Dislocation"),
            new Thing("Burn"),
        };
        public List<Thing> Types
        {
            get { return _types; }
            set { _types = value; RaisePropertyChanged(() => Types); }
        }

        private Thing _selectedType = new Thing("None");
        private Thing _selectedInjury;
        public Thing SelectedType
        {
            get { return _selectedType; }
            set { _selectedType = value; RaisePropertyChanged(() => SelectedType); RaisePropertyChanged(() => Injuries);
                _selectedInjury = new Thing("None"); RaisePropertyChanged(() => SelectedInjury);
            }
        }

        // -----------------------------
        private List<Thing> _none = new List<Thing>()
        {
            new Thing("None"),           
        };
        private List<Thing> _fractures = new List<Thing>()
        {
            new Thing("None"),
            new Thing("Lower leg, kneecap or ankle"),
            new Thing("Vertebrae"),
            new Thing("Arm"),
            new Thing("Sternum"),
            new Thing("Collar bone"),
            new Thing("Foot"),
            new Thing("Hand"),
            new Thing("Jaw"),
            new Thing("Shoulder blade"),
            new Thing("Wrist"),
            new Thing("Cheekbone"),
            new Thing("Coccyx"),
            new Thing("Eye socket"),
            new Thing("Nose"),
            new Thing("Rib or ribs"),
            new Thing("Sacrum"),

        };
        private List<Thing> _dislocations = new List<Thing>()
        {
            new Thing("None"),
            new Thing("Hip"),
            new Thing("Knee, ankle, wrist, elbow"),
            new Thing("Shoulder"),
            

        };
        private List<Thing> _burns = new List<Thing>()
        {
            new Thing("None"),
            new Thing("More than 20% of body surface or %0% of face"),
            new Thing("At least 4% but less than 20% of body surface"),
            new Thing("Hands to at least 50% of either hand surface"),


        };
        public List<Thing> Injuries
        {
            get {
                if (_selectedType.ToString() == "Fracture")
                {
                    return _fractures;
                } else if (_selectedType.ToString() == "Dislocation")
                {
                    return _dislocations;
                } else if (_selectedType.ToString() == "Burn")
                {
                    return _burns;
                } else
                {
                    return _none;
                }
            }
            set {
                if (_selectedType.ToString() == "Fracture")
                {
                    _fractures = value; 
                } else if (_selectedType.ToString() == "Dislocation")
                {
                    _dislocations = value; 
                } else if (_selectedType.ToString() == "Burn")
                {
                    _burns = value; 
                } else
                {
                    _none = value;
                }
                RaisePropertyChanged(() => Injuries);
            }
        }

        
        public Thing SelectedInjury
        {
            get { return _selectedInjury; }
            set { _selectedInjury = value; RaisePropertyChanged(() => SelectedInjury); }
        }

        // Take photo and choose photo
        private readonly IMvxPictureChooserTask _pictureChooserTask;

        

        private MvxCommand _takePictureCommand;

        public System.Windows.Input.ICommand TakePictureCommand
        {
            get
            {
                _takePictureCommand = _takePictureCommand ?? new MvxCommand(DoTakePicture);
                return _takePictureCommand;
            }
        }

        private async void DoTakePicture()
        {
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
            }

            if ((cameraStatus == PermissionStatus.Granted) && (storageStatus == PermissionStatus.Granted))
            {
                _pictureChooserTask.TakePicture(400, 95, OnPicture, () => { });
            } 
        }

        private MvxCommand _choosePictureCommand;

        public ICommand ChoosePictureCommand
        {
            get
            {
                _choosePictureCommand = _choosePictureCommand ?? new MvxCommand(DoChoosePicture);
                return _choosePictureCommand;
            }
        }

        private void DoChoosePicture()
        {
            _pictureChooserTask.ChoosePictureFromLibrary(400, 95, OnPicture, () => { });
        }

        private byte[] _bytes;

        public byte[] Bytes
        {
            get { return _bytes; }
            set { _bytes = value; RaisePropertyChanged(() => Bytes); }
        }

        private void OnPicture(Stream pictureStream)
        {
            var memoryStream = new MemoryStream();
            pictureStream.CopyTo(memoryStream);
            Bytes = memoryStream.ToArray();
        }

        //=============================
        private string _fullName = "";
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; RaisePropertyChanged(() => FullName); }
        }

        private string _doB ="";
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

        private string _location = "";
        public string Location
        {
            get { return _location; }
            set { _location = value; RaisePropertyChanged(() => Location); }
        }

        private string _cmt = "";
        public string Comment
        {
            get { return _cmt; }
            set { _cmt = value; RaisePropertyChanged(() => Comment); }
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

        public ICommand ViewSummaryCommand
        {
            get
            {
                return new MvxCommand(() => 
                {
                    ShowViewModel<ClaimSummaryViewModel>(new
                    {
                        fullName = _fullName,
                        doB = _doB,
                        policyNum = _policyNum,
                        phoneNum = _phoneNum,
                        email = _email,
                        date = _date,
                        time = _time,
                        location = _location,
                        type = _selectedType.ToString(),
                        injury = _selectedInjury.ToString(),
                        cmt = _cmt,
                        bytes = _bytes
                    });
                        });
            }
        }


        private readonly ISavedClaimsDatabase _savedClaimDatabase;

        public ICommand SaveClaimCommand
        {
            get
            {

                return new MvxCommand(SaveClaim);
            }
        }

        private readonly IDialogService _dialog;
        public async void SaveClaim()
        {

            ClaimDetails newClaim = new ClaimDetails()      
            {
                FullName = _fullName,
                DoB = _doB,
                PolicyNum = _policyNum,
                PhoneNum = _phoneNum,
                Email = _email,
                Date = _date.ToString(),
                Time = _time.ToString(),
                Location = _location,
                Type = _selectedType.ToString(),
                Injury = _selectedInjury.ToString(),
                Cmt = _cmt,
                Extra = "saved"
                //Bytes = _bytes
            };

            await _dialog.Show("Saving Claim", "Synchronising...");
            await _savedClaimDatabase.InsertClaim(newClaim);
            await _dialog.Dismiss();
            await _dialog.ShowToast("Claim saved.");
        }

        public ICommand SubmitClaimCommand
        {
            get
            {

                return new MvxCommand(SubmitClaim);
            }
        }
        public async void SubmitClaim()
        {
            if (string.IsNullOrWhiteSpace(_fullName) || string.IsNullOrWhiteSpace(_doB) || string.IsNullOrWhiteSpace(_policyNum)
                || string.IsNullOrWhiteSpace(_phoneNum) || string.IsNullOrWhiteSpace(_email)
                || string.IsNullOrWhiteSpace(_location) || string.IsNullOrWhiteSpace(_cmt))
            {
                await _dialog.ShowToast("Please enter all fields.");
            }
            else
            {
                ClaimDetails newClaim = new ClaimDetails()
                {
                    FullName = _fullName,
                    DoB = _doB,
                    PolicyNum = _policyNum,
                    PhoneNum = _phoneNum,
                    Email = _email,
                    Date = _date.ToString(),
                    Time = _time.ToString(),
                    Location = _location,
                    Type = _selectedType.ToString(),
                    Injury = _selectedInjury.ToString(),
                    Cmt = _cmt,
                    Extra = "submitted"
                    //Bytes = _bytes
                };

                await _dialog.Show("Lodging claim...");
                await _savedClaimDatabase.InsertClaim(newClaim);
                await _dialog.Dismiss();
                ShowViewModel<FirstViewModel>();
                await _dialog.ShowToast("Claim lodged.");
            }
        }

        public async void UseProfileDetails()
        {
            ClaimDetails MyProfile = new ClaimDetails();
            MyProfile = await _savedClaimDatabase.GetProfile();
            FullName = MyProfile.FullName;
            DateOfBirth = MyProfile.DoB;
            PolicyNum = MyProfile.PolicyNum;
            PhoneNum = MyProfile.PhoneNum;
            Email = MyProfile.Email;
            if (string.IsNullOrWhiteSpace(MyProfile.FullName))
            {
                await _dialog.ShowToast("Profile details have not been entered.");
            }
            else
            {
                await _dialog.ShowToast("Profile details used.");
            }
            
        }

        public ICommand UseProfileDetailsCommand
        {
            get
            {

                return new MvxCommand(UseProfileDetails);
            }
        }

        public MakeAClaimViewModel(IMvxPictureChooserTask pictureChooserTask, ISavedClaimsDatabase saveClaimDatabase, IDialogService progressDialog)
        {
            _pictureChooserTask = pictureChooserTask;
            _savedClaimDatabase = saveClaimDatabase;
            _dialog = progressDialog;
        }

        public void Init(string fullName, string dob, string policyNum, string phoneNum, string email, string date, string time, string location, string type, string injury, string cmt)
        {
            _fullName = fullName;
            _doB = dob;
            _policyNum = policyNum;
            _phoneNum = phoneNum;
            _email = email;
            if (date != null && time != null)
            {
                _date = date;
                _time = time;
            }
            _location = location;
            _selectedType = new Thing(type);
            _selectedInjury = new Thing(injury);
            _cmt = cmt;

        }

    }


}
