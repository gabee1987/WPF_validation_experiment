using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using GalaSoft.MvvmLight.Command;

namespace Data_Validation_Experiment
{
    class MainWindowViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged( [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null )
        {
            if( this.PropertyChanged != null )
            {
                this.PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            Title = "Data Validation Test";
            //Test1 = "This is a required field";
        }

        private string m_AcceptOnlyString;
        public string AcceptOnlyString
        {
            get
            {
                return m_AcceptOnlyString;
            }
            set
            {

                m_AcceptOnlyString = value;
                RaisePropertyChanged( nameof( AcceptOnlyString ) );
            }
        }
        public string Title { get; set; }
        public int AcceptOnlyInt { get; set; }
        //public string AcceptOnlyString { get; set; }

        private int m_NumberBetweenValueEx;
        public int NumberBetweenValueEx
        {
            get { return m_NumberBetweenValueEx; }
            set
            {
                if( value < 10 || value > 100 )
                    throw new ArgumentException( "The number must be between 10 and 100" );
                m_NumberBetweenValueEx = value;
                RaisePropertyChanged( nameof( NumberBetweenValueEx ) );
            }
        }

        private int m_NumberBetweenValueErr;
        public int NumberBetweenValueErr
        {
            get { return m_NumberBetweenValueErr; }
            set
            {
                m_NumberBetweenValueErr = value;
                RaisePropertyChanged( nameof( NumberBetweenValueErr ) );
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                switch( columnName )
                {
                    case "NumberBetweenValueErr":
                        if( NumberBetweenValueErr < 10 || NumberBetweenValueErr > 100 )
                            return "The number must be between 10 and 100";
                        break;
                    case "AcceptOnlyString":
                        if( String.IsNullOrEmpty( AcceptOnlyString ) )
                            return "The input cannot be empty";
                        if( !Regex.IsMatch( AcceptOnlyString, "^[a-zA-Z ]" ) )
                            return "The input must be alphabetic";
                        break;
                }

                return string.Empty;
            }
        }

        public string Test4 { get; set; }


        #region BerendezesLeszerelCommand

        private RelayCommand m_Empty;

        public RelayCommand EmptyCommand
        {
            get
            {
                if( m_Empty == null )
                    m_Empty = new RelayCommand( EmptyCommandCall );
                return m_Empty;
            }
        }

        private void EmptyCommandCall()
        {
            AcceptOnlyString = string.Empty;
        }



        #endregion
    }
}
