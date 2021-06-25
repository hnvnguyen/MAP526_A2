using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Assignment2.Model
{
    public class BodiesData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [PrimaryKey]
        public string id { get; set; }
        public string name { get; set; }
        public string englishName { get; set; }
        public bool isPlanet { get; set; }
        public double semimajorAxis { get; set; }
        public double density { get; set; }
        public double gravity { get; set; }
        public string discoveryDate { get; set; }
        public string discoveredBy { get; set; }

        private bool _isFavourite = false;
        public bool isFavourite {
            get { return _isFavourite; }
            set {
                if (value == _isFavourite)
                    return;
                _isFavourite = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(isFavourite)));
            }
        }
        private string _notes;
        public string notes {
            get { return _notes; }
            set {
                if (value == _notes)
                    return;
                _notes = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(notes)));
            }
        }

    }
}
