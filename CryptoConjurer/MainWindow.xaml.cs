using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CryptoConjurer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        //Global variables
        Conjurer Imane = new Conjurer(0, 0.0001, 0);
        Random r = new Random();
        List<Image> itemRemover = new List<Image>();

        DispatcherTimer updateTimer = new DispatcherTimer();
        DispatcherTimer gameTimer = new DispatcherTimer();
        DispatcherTimer cheatTimer = new DispatcherTimer();
        DispatcherTimer flowTimer = new DispatcherTimer();



        //anti cheat
        bool TooFast = false;

        public MainWindow()
        {
            InitializeComponent();

            //Starts window in center of screen
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;



            updateTimer.Tick += UpdateTotal;
            updateTimer.Interval = TimeSpan.FromMilliseconds(100);
            updateTimer.Start();

            gameTimer.Tick += Animation;
            gameTimer.Interval = TimeSpan.FromMilliseconds(40);
            gameTimer.Start();

            cheatTimer.Tick += AntiCheat;
            cheatTimer.Interval = TimeSpan.FromMilliseconds(80);
            cheatTimer.Start();

            flowTimer.Tick += FlowDecay;
            flowTimer.Interval = TimeSpan.FromMilliseconds(97);
            flowTimer.Start();
        }


        int activeFlowMultiplierCountDown = 0;
        bool active = false;
        private void FlowDecay(object sender, EventArgs e)
        {
            if (activeFlowMultiplierCountDown > 0)
            {
                if(active)
                {
                    activeFlowMultiplierCountDown--;
                }
                else
                {
                    flowMultiplier *= 2;
                    active = true;
                    flowText.Foreground = Brushes.LightYellow;
                    flowText.FontWeight = FontWeights.Bold;
                }
            }
            else
            {
                if(active)
                {
                    active = false;
                    flowMultiplier /= 2;
                    flowText.Foreground = Brushes.White;
                    flowText.FontWeight = FontWeights.Light;

                }
            }

            Flow(false, 0.2);
        }

        //Updates the text displaying the total amount of currency.
        private void UpdateTotal(object sender, EventArgs e)
        {
            //Makes the decimal places scale with the amount of currecy you have to not overburden the UI
            int decimals = 7 - Math.Truncate(Imane.Ethereum).ToString().Length;

            //Prevents decimal places to go negative and break the program.
            if (decimals < 0) { decimals = 0; }


            Imane.Ethereum += (Imane.Eps / 10)*flow;
            Total.Text = decimal.Parse(Math.Round(Imane.Ethereum, decimals).ToString(), System.Globalization.NumberStyles.Any).ToString().Replace(",", ".");
        }

        //Animation when clicking
        private void Animation(object sender, EventArgs e)
        {
            //Moves the anmation up and fades it
            ClickSymbolAnimation();

            //Removes the animation once its opacity is low enough.
            ClickSymbolRemover();
        }

        //Limits the maximum amount of clicks possible to avoid auto clickers.
        private void AntiCheat(object sender, EventArgs e)
        {
            TooFast = false;
        }


        private void ClickSymbolAnimation()
        {
            foreach (var z in myCanvas.Children.OfType<Image>())
            {
                if ((string)z.Tag == "Ethereum")
                {

                    Canvas.SetTop(z, Canvas.GetTop(z) - 0.3);

                    z.Opacity -= 0.07;


                    if (z.Opacity < 0.041)
                    {
                        itemRemover.Add(z);
                    }

                }
            }
        }

        private void ClickSymbolRemover()
        {
            foreach (Image y in itemRemover)
            {
                myCanvas.Children.Remove(y);
            }
        }

        MediaPlayer player = new MediaPlayer();


        private void Click(object sender, MouseButtonEventArgs e)
        {
            //Anti auto clicker. If you're clicking too fast, it won't register
            if (TooFast == false)
            {
                //TooFast = true;


                //Increase total amount of currency with the amount of currency bound to each click(Ethereum per click).
                Imane.Ethereum += (Imane.Epc * flow);

                //Increase flow
                Flow(true, 1);

                //Little ethereum symbol when you click
                ClickVisual();


                int random = r.Next(2001);

                //node (20x click)
                if (random < 10)
                {
                    CreateNode("Blue");

                }
                else if (random < 20)
                {
                    CreateNode("Yellow");

                }
                else if (random < 21)
                {
                    CreateNode("Special");
                }
            }
        }


        double flowMultiplier = 1;

        double flow = 1;
        void Flow(bool increase, double amount)
        {
            //Increase and decrease
            if(increase)
            {
                // With every click the flow is increased slightly
                flowBar.Value += 1 * amount;
            }
            else
            {
                // Every x amount of time the flow is decreased
                flowBar.Value -= amount;
            }

            //Bar Visuals
            if (flowBar.Value < 255)
            {
                byte negative = Convert.ToByte(255 - flowBar.Value);
                flowColour.Color = (Color.FromRgb(255, negative, negative));

                flow = (1 + Math.Round(flowBar.Value /10 / 25.5, 2)) * flowMultiplier;
            }
            else
            {
                byte positive = Convert.ToByte(flowBar.Value - 255);
                flowColour.Color = (Color.FromRgb(Convert.ToByte(255-positive), 0, 0));

                flow = (2 - Math.Round((flowBar.Value - 255) / 10 / 25.5,2)) * flowMultiplier;
            }

            //Multiplier number
            flowText.Text = decimal.Parse(flow.ToString(), System.Globalization.NumberStyles.Any).ToString().Replace(",", ".") + "x";

            FlowCps(flow);

        }

        void ClickVisual()
        {
            Image Ethereum = new Image
            {
                Tag = "Ethereum",
                Source = new BitmapImage(new Uri(@"pack://application:,,,/CryptoConjurer;component/Images/Ethereum.png")),
                IsHitTestVisible = false,
                Focusable = false,
            };

            Point p = Mouse.GetPosition(myCanvas);

            var y = p.Y;
            var x = p.X;

            Canvas.SetTop(Ethereum, y - 40);
            Canvas.SetLeft(Ethereum, x - 25);

            myCanvas.Children.Add(Ethereum);
        }

        void CreateNode(string colour)
        {
            Image node = new Image
            {
                Tag = colour,
                Source = new BitmapImage(new Uri(@"pack://application:,,,/CryptoConjurer;component/Images/nodes/node"+colour+".png")),
                IsHitTestVisible = true,
                Focusable = true,
            };

            //test
            Canvas.SetTop(node, r.Next(205, Convert.ToInt32(myCanvas.ActualHeight) - 75));
            Canvas.SetLeft(node, r.Next(1, Convert.ToInt32(myCanvas.ActualWidth) - 35));

            myCanvas.Children.Add(node);

            node.AddHandler(Image.MouseLeftButtonDownEvent, new RoutedEventHandler(node_Click));
        }

        void node_Click(object sender, RoutedEventArgs e)
        {
            //To prevent a default click(Black ethereum animation), I've added the anti cheat to the nodes aswell.
            TooFast = true;

            Image node = (Image)sender;

            myCanvas.Children.Remove(node);

            //Blue clicks with 20 times the power
            if((string)node.Tag == "Blue")
            {
                Imane.Ethereum += Imane.Epc * 20;
                Flow(true, 20);
            }

            //Yellow gives currency for one minute of Cps
            if((string)node.Tag == "Yellow")
            {
                Imane.Ethereum += Imane.Eps * 60;
            }

            //Special multiplies all gains for 30sec
            if ((string)node.Tag == "Special")
            {
                activeFlowMultiplierCountDown = 300;
            }


        }


        private void Purchase(object sender, MouseButtonEventArgs e)
        {
            Grid upgrade = (Grid)sender;

            bool paid = false;


            foreach (var z in upgrade.Children.OfType<TextBlock>())
            {
                //Finds the textblock that has the cost of the upgrade
                if ((string)z.Tag == "Cost")
                {
                    //Checks if the player has enough currency to get he upgrade
                    if (Imane.Ethereum >= Convert.ToDouble(z.Text.Replace(".", ",")))
                    {
                        Imane.Ethereum -= Convert.ToDouble(z.Text.Replace(".", ","));
                        z.Text = Math.Round(Convert.ToDouble(z.Text.Replace(".", ",")) * 1.15, 4).ToString();
                        paid = true;
                    }
                }
            }

            if (paid)
            {
                foreach (var z in upgrade.Children.OfType<TextBlock>())
                {
                    if ((string)z.Tag == "Amount")
                    {
                        z.Text = (Convert.ToInt32(z.Text) + 1).ToString();
                    }

                    if ((string)z.Tag == "Cps")
                    {
                        IncreaseCps(Convert.ToDouble(z.Text.Replace(".", ",")));
              
                    }
                }

            }
        }

        private void IncreaseCps(double cps)
        {
            Imane.Eps += cps;

            
        }

        private void FlowCps(double flow)
        {
            //Makes the decimal places scale with the amount of currecy you have to not overburden the UI
            int decimals = 7 - Math.Truncate(Imane.Ethereum).ToString().Length;

            //Prevents decimal places to go negative and break the program.
            if (decimals < 0) { decimals = 0; }

            PerSecond.Text = "per second: " + decimal.Parse(Math.Round(Imane.Eps * flow, decimals).ToString(), System.Globalization.NumberStyles.Any).ToString().Replace(",", ".");
        }



        private void MouseEnter(object sender, MouseEventArgs e)
        {
            Grid upgrade = (Grid)sender;
            upgrade.Opacity = 0.6;
        }

        private void MouseLeave(object sender, MouseEventArgs e)
        {
            Grid upgrade = (Grid)sender;
            upgrade.Opacity = 1;
        }

        
    }
}
