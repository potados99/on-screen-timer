using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace on_screen_timer
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ThisViewModel = new ViewModel();
            this.DataContext = ThisViewModel;
        }


        #region Event Handler

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        #endregion


        #region Variables

        ViewModel ThisViewModel;
        DispatcherTimer Timer;
        TimeSpan Time;

        int PastSecond = 0;

        #endregion



        #region Control Button Click

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Cancel();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            Pause();
        }

        private void ResumeButton_Click(object sender, RoutedEventArgs e)
        {
            Resume();
        }

        #endregion


        #region Time Set Button Click

        private void MinutePlusButton_Click(object sender, RoutedEventArgs e)
        {
            ThisViewModel.MinuteSet += 1;
        }

        private void MinuteMinusButton_Click(object sender, RoutedEventArgs e)
        {
            ThisViewModel.MinuteSet -= 1;
        }

        private void SecondPlusButton_Click(object sender, RoutedEventArgs e)
        {
            ThisViewModel.SecondSet += 1;
        }

        private void SecondMinusButton_Click(object sender, RoutedEventArgs e)
        {
            ThisViewModel.SecondSet -= 1;
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            ThisViewModel.ControlVisible = true;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ThisViewModel.IsTimerRunning)
            {
                ThisViewModel.ControlVisible = false;
            }
        }

        #endregion



        private void Start()
        {
            ThisViewModel.IsTimerRunning = true;
            ThisViewModel.IsTimerPaused = false;
            ThisViewModel.CurrentLeftMinutes = ThisViewModel.MinuteSet;
            ThisViewModel.CurrentLeftSeconds = ThisViewModel.SecondSet;
            // run timer
            StartTimer();
        }

        private void Pause()
        {
            ThisViewModel.IsTimerRunning = true;
            ThisViewModel.IsTimerPaused = true;
            Timer.Stop();
        }

        private void Resume()
        {
            ThisViewModel.IsTimerRunning = true;
            ThisViewModel.IsTimerPaused = false;
            Timer.Start();
        }

        private void Cancel()
        {
            ThisViewModel.IsTimerRunning = false;
            ThisViewModel.IsTimerPaused = false;
            ThisViewModel.CurrentLeftMinutes = 0;
            ThisViewModel.CurrentLeftSeconds = 0;
            Timer.Stop();
        }

        private void StartTimer()
        {
            Time = new TimeSpan(0, ThisViewModel.MinuteSet, ThisViewModel.SecondSet + 1);
            Timer = new DispatcherTimer();

            Timer.Interval = TimeSpan.FromMilliseconds(0);
            Timer.Tick += Timer_Tick;

            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Time == TimeSpan.Zero || Time.TotalSeconds <= 0) TimerDone();

            if (PastSecond != DateTime.Now.Second)
            {
                Time = Time.Add(TimeSpan.FromSeconds(-1));

                ThisViewModel.CurrentLeftMinutes = Time.Minutes;
                ThisViewModel.CurrentLeftSeconds = Time.Seconds;

                PastSecond = DateTime.Now.Second;
            }
        }

        private void TimerDone()
        {
            MessageBox.Show("타이머 완료");
            Timer.Stop();
            ThisViewModel.IsTimerRunning = false;
            ThisViewModel.IsTimerPaused = false;
            ThisViewModel.ControlVisible = true;
        }


        private void ExitItem_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void InfoItem_Click(object sender, RoutedEventArgs e)
        {
            var ver = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            MessageBox.Show(
                "Onscreen Timer\n" +
                "버전 " + ver.ToString() + "\n\n" +
                "Copyright © 2018 Potados 모든 권리 보유."
                );
        }

        private void DevItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "만든이 병준이\n" +
                "조력자 밓디\n"
                 );
        }
    }
}
