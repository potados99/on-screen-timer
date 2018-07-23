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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace on_screen_timer
{
    /// <summary>
    /// AlertWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AlertWindow : Window
    {
        public AlertWindow(double duration, string message)
        {
            InitializeComponent();

            MessageLabel.Content = message;

            DoubleAnimation dba1 = new DoubleAnimation();
            dba1.From = 0;
            dba1.To = 3;
            dba1.Duration = new Duration(TimeSpan.FromSeconds(duration));
            dba1.AutoReverse = true;
            dba1.Completed += (s, a) =>
            {
                Close();
            };

            BeginAnimation(OpacityProperty, dba1);
        }
    }
}
