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
using System.Windows.Threading;

namespace WpfTicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            timer.Tick += AI;
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Start();
        }

        private void AI(object sender, EventArgs e)
        {

        }


        bool x = true;
        private void Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if ((string)button.Content == "")
            {
                if(x)
                {
                    button.Content = "X";
                    x = false;
                }
                else
                {
                    button.Content = "O";
                    x = true;

                }

            }

        }
    }


}
