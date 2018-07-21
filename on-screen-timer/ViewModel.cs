using System.ComponentModel;

namespace on_screen_timer
{
    class ViewModel : INotifyPropertyChanged
    {
        private bool isTimerRunning = false;
        public bool IsTimerRunning
        {
            get
            {
                return isTimerRunning;
            }

            set
            {
                isTimerRunning = value;
                NotifyPropertyChanged("IsTimerRunning");
            }
        }

        private bool isTimerPaused = false;
        public bool IsTimerPaused
        {
            get
            {
                if (IsTimerRunning == false)
                {
                    return false;
                }
                return isTimerPaused;
            }

            set
            {
                isTimerPaused = value;
                NotifyPropertyChanged("IsTimerPaused");
            }
        }


        private int minuteSet = 0;
        public int MinuteSet
        {
            get
            {
                return minuteSet;
            }

            set
            {
                minuteSet = value;
                NotifyPropertyChanged("MinuteSet");
            }
        }

        private int secondSet = 0;
        public int SecondSet
        {
            get
            {
                return secondSet;
            }

            set
            {
                secondSet = value;
                NotifyPropertyChanged("SecondSet");
            }
        }

        private int currentLeftMinutes = 0;
        public int CurrentLeftMinutes
        {
            get
            {
                return currentLeftMinutes;
            }

            set
            {
                currentLeftMinutes = value;
                NotifyPropertyChanged("CurrentLeftMinutes");
            }
        }

        private int currentLeftSeconds = 0;
        public int CurrentLeftSeconds
        {
            get
            {
                return currentLeftSeconds;
            }

            set
            {
                currentLeftSeconds = value;
                NotifyPropertyChanged("CurrentLeftSeconds");
            }
        }

        private bool controlVisible = false;
        public bool ControlVisible
        {
            get
            {
                return controlVisible;
            }

            set
            {
                controlVisible = value;
                NotifyPropertyChanged("ControlVisible");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
