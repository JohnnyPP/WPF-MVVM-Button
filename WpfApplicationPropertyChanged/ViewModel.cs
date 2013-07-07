using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplicationPropertyChanged 
{
    class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            updateControl="Press the button";
        }

        int count = 0;


        private string updateControl;

        public string UpdateControl
        {
            get { return updateControl; }
            set 
            { 
                if (updateControl!=value)
                {
                    updateControl=value;
                    RaisePropertyChanged("UpdateControl");
                }
                updateControl = value; 
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;           //implemented automatically

        #region Commands
        void UpdateArtistNameExecute()
        {
            ++count;
            UpdateControl = string.Format("You pressed the button ({0}) many times", count);
        }

        bool CanUpdateArtistNameExecute()
        {
            return true;
        }

        public ICommand UpdateArtistName { get { return new RelayCommand(UpdateArtistNameExecute, CanUpdateArtistNameExecute); } }
        #endregion
    }
}
