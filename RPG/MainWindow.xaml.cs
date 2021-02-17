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

namespace RPGTEST
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

        private void CooldownCountdown(object sender, EventArgs e, Grid grid)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;


            foreach (var countDown in grid.Children.OfType<Rectangle>())
            {
                int cd = Convert.ToInt32(countDown.Tag);

                countDown.Fill = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/RPGTEST;component/cds/cd" + cd + ".png")));

                if (cd == 106)
                {
                    timer.Stop();
                    timer = null;
                    countDown.Fill = null; //Remove cd image
                    countDown.Tag = 0;                 
                    grid.IsEnabled = true;
                }
                else{ countDown.Tag = Convert.ToInt32(countDown.Tag) + 1; }
                
            }
        }

        private void Ability(object sender, MouseButtonEventArgs e)
        {
            Grid ability = (Grid)sender;

            ability.IsEnabled = false;

            foreach (var cd in ability.Children.OfType<Rectangle>())
            {
                Cd(ability);
            }
        }

        void Cd(Grid ability)
        {
            DispatcherTimer abilityTimer = new DispatcherTimer();

            abilityTimer.Tick += (sender, e) => { CooldownCountdown(sender, e, ability); };
            abilityTimer.Interval = TimeSpan.FromMilliseconds(30);
            abilityTimer.Start();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {

            MouseButtonEventArgs x = null;

            if (e.Key == Key.Q)
            {
                if(ability1.IsEnabled == true)
                {
                    Ability(ability1, x);
                }
            }
            else if (e.Key == Key.W)
            {
                if (ability2.IsEnabled == true)
                {
                    Ability(ability2, x);
                }
            }
            else if (e.Key == Key.E)
            {
                if (ability3.IsEnabled == true)
                {
                    Ability(ability3, x);
                }
            }
            else if (e.Key == Key.R)
            {
                if (ability4.IsEnabled == true)
                {
                    Ability(ability4, x);
                }
            }
        }
    }
}
