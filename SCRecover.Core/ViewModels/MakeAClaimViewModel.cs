using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;

namespace SCRecover.Core.ViewModels
{
    public class MakeAClaimViewModel
        : MvxViewModel
    {
        private DateTime _date = DateTime.Now;
        private TimeSpan _time = DateTime.Now.TimeOfDay;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; RaisePropertyChanged(() => Date); }
        }

        public TimeSpan Time
        {
            get { return _time; }
            set { _time = value; RaisePropertyChanged(() => Time); }
        }

        //========
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

        //------
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


    }

    



}
