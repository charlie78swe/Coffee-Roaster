using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Roaster.DataHolders
{
    class Reseller : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        int mID;
        string mName;
        string mDescription;
        int mRating = -1;

        public int ID { get => mID; }
        
        public string Name { get => mName; set { mName = value; NotifyPropertyChanged("Name"); }}
        public string Description { get => mDescription; set {mDescription = value; NotifyPropertyChanged("Description"); }}
        public int Rating {
            get => mRating;
            set {mRating = value; NotifyPropertyChanged("Rating"); }}        
    }
}
