using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        #endregion





        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ThisViewModel.IsTimerRunning = false;
            ThisViewModel.IsTimerPaused = false;
            ThisViewModel.CurrentLeftMinutes = 0;
            ThisViewModel.CurrentLeftSeconds = 0;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ThisViewModel.IsTimerRunning = true;
            ThisViewModel.IsTimerPaused = false;
            ThisViewModel.CurrentLeftMinutes = ThisViewModel.MinuteSet;
            ThisViewModel.CurrentLeftSeconds = ThisViewModel.SecondSet;
            // run timer
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            ThisViewModel.IsTimerRunning = true;
            ThisViewModel.IsTimerPaused = true;
        }

        private void ResumeButton_Click(object sender, RoutedEventArgs e)
        {
            ThisViewModel.IsTimerRunning = true;
            ThisViewModel.IsTimerPaused = false;
        }


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
    }
}
