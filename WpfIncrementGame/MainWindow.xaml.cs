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

namespace WpfIncrementGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void PunchButton_Click(object sender, RoutedEventArgs e)
        {
            FistStrengthText.Content = (Convert.ToInt32(FistStrengthText.Content) + 1);
        }

        private void SideKickButton_Click(object sender, RoutedEventArgs e)
        {
            LegStrengthText.Content = Convert.ToInt32(LegStrengthText.Content) + 1;
        }

        private void PushUpButton_Click(object sender, RoutedEventArgs e)
        {
            CoreStrengthText.Content = Math.Round(Convert.ToDouble(CoreStrengthText.Content) + 0.01, 2);
        }
    }
}
