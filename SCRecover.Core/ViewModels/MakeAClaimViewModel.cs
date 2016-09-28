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
        public Thing SelectedType
        {
            get { return _selectedType; }
            set { _selectedType = value; RaisePropertyChanged(() => SelectedType); }
        }

        //------
        private List<Thing> _none = new List<Thing>()
        {
            new Thing("1"),           
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
            new Thing("hip"),
            new Thing("Knee, ankle, wrist, elbow"),
            new Thing("Shoulder"),
            

        };
        public List<Thing> Injuries
        {
            get { return _none; }
            set { Update(); _none = value; RaisePropertyChanged(() => Injuries); }
        }

        private void Update()
        {
            if (_selectedType.ToString() == "Fracture")
            {
                _none = _fractures;
            }
            else if (_selectedType == Types[2])
            {
                _none = _dislocations;
            }
        }
        private Thing _selectedInjury;
        public Thing SelectedInjury
        {
            get { return _selectedInjury; }
            set { _selectedInjury = value; RaisePropertyChanged(() => SelectedInjury); }
        }


    }

    



}
