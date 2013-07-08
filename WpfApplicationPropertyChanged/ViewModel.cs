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
            updateLabel = "Label updated";
            updateTextBox = "TestTextBox";
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

        private string updateLabel;

        public string UpdateLabel
        {
            get { return updateLabel; }
            set
            {
                if (updateLabel != value)
                {
                    updateLabel = value;
                    RaisePropertyChanged("UpdateLabel");
                }
                updateLabel = value;
            }
        }

        private string updateTextBox;

        public string UpdateTextBox
        {
            get { return updateTextBox; }
            set
            {
                if (updateTextBox != value)
                {
                    updateTextBox = value;
                    RaisePropertyChanged("UpdateTextBox");      //Updates the right-bottom TextBox
                }                                               //Text="{Binding Path=UpdateTextBox, Mode=TwoWay}" 
                updateTextBox = value;                          //The content of the textbox is transferred to the
            }                                                   //UpdateTextBox property and may be further used 
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

        //All the buttons require 2 functions that names are defined in
        //get { return new RelayCommand(1. Execute, 2. CanNAMEExecute)
      

        #region Commands
        void UpdateControlExecute()
        {
            ++count;
            UpdateControl = string.Format("You pressed the button ({0}) many times", count);
        }

        bool CanUpdateControlExecute()
        {
            return true;
        }

        public ICommand UpdateName 
        { 
            get { return new RelayCommand(UpdateControlExecute, CanUpdateControlExecute); } 
        }

        ////////////////////////////////////////
        //UpdateLabel
        ///////////////////////////////////////

        void UpdateLabelControlExecute()
        {
            //++count;
            UpdateLabel = string.Format("({0})+({1})", count, updateTextBox);
        }

        bool CanUpdateLabelControlExecute()
        {
            return true;
        }

        public ICommand UpdateLabelName //ICommand name must be the same as the Button binding name in XAML 
        {                               //<Button Content="Button" Command="{Binding UpdateLabelName}"/>
            get { return new RelayCommand(UpdateLabelControlExecute, CanUpdateLabelControlExecute); }
        }                               //The UpdateLabelControlExecute and CanUpdateLabelControlExecute must be defined
                                        //In the UpdateLabelControlExecute() function is the body that will be executed
                                        //After pressing the button
        #endregion                      

    }
}
