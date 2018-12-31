using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

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

        private const int MINUTE_MAX = 99;
        private const int SECOND_MAX = 59;

        private int minuteSet = 0;
        public int MinuteSet
        {
            get
            {
                return minuteSet;
            }

            set
            {
                if (value > MINUTE_MAX)
                {
                    minuteSet = 0;
                    NotifyPropertyChanged("MinuteSet");
                    return;
                }

                if (value < 0)
                {
                    minuteSet = MINUTE_MAX;
                    NotifyPropertyChanged("MinuteSet");
                    return;
                }
                else if (value == 0 && SecondSet == 0)
                {
                    SecondSet = 1;
                }
                minuteSet = value;
                NotifyPropertyChanged("MinuteSet");
            }
        }

        private int secondSet = 1;
        public int SecondSet
        {
            get
            {
                return secondSet;
            }

            set
            {
                if (value > SECOND_MAX)
                {
                    if (value == SECOND_MAX + 1 && MinuteSet < MINUTE_MAX)
                    {
                        MinuteSet += 1;
                        secondSet = 0;
                        NotifyPropertyChanged("SecondSet");
                    }
                    else
                    {
                        MessageBox.Show("60 미만의 정수를 입력해 주세요");
                    }
                    return;

                }
                if (value < 0)
                {
                    if (value == -1 && MinuteSet > 0)
                    {
                        MinuteSet -= 1;
                        secondSet = SECOND_MAX;
                        NotifyPropertyChanged("SecondSet");
                    }
                    else
                    {
                        MessageBox.Show("0 이상의 정수를 입력해 주세요");
                    }
                    return;

                }
                if (value == 0 && MinuteSet == 0)
                {
                    return;
                } 
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

        private bool controlVisible = true;
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
                NotifyPropertyChanged("WindowHeight");
            }
        }

        private SolidColorBrush timerLabelColor = new SolidColorBrush(Colors.Black);
        public SolidColorBrush TimerLabelColor
        {
            get
            {
                return timerLabelColor;
            }

            set
            {
                timerLabelColor = value;
                NotifyPropertyChanged("TimerLabelColor");
            }
        }

        private readonly int windowHeight = 161;
        public int WindowHeight
        {
            get
            {
                if (ControlVisible)
                {
                    return windowHeight;
                }
                else
                {
                    int borderThickness = 3;
                    double contentGridRowLengthStar = 4;
                    double collapableGridRowLengthStar = BoolToGridRowHeightConverter.CollapsableGridRowLengthStar;
                    double collapableGridRowLength = (double)windowHeight / (contentGridRowLengthStar + collapableGridRowLengthStar) * contentGridRowLengthStar;
                    return (int)collapableGridRowLength + borderThickness;
                }
            }

            set
            {

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
