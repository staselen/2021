using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace FlaskeAutomat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Bufferes
        Queue<Product> beerBuffer = new Queue<Product>();
        Queue<Product> sodaBuffer = new Queue<Product>();
        Queue<Product> sharedBuffer = new Queue<Product>();

        //List of imgaes to be removed from canvas.
        List<Image> itemRemover = new List<Image>();

        //Producer. Because my producer is controlled by my gui I need acess to its produce method.
        //Unlike the splitter and consumer classes that just do their thing in a loop.
        Producer producer = new Producer();

        //Dispatch timers, responsible for the animations in the gui.
        DispatcherTimer sharedBufferTimer = new DispatcherTimer(); //Moving products on first buffer
        DispatcherTimer sodaBufferTimer = new DispatcherTimer(); //Moving soda on soda buffer
        DispatcherTimer beerBufferTimer = new DispatcherTimer(); //Moving beer on beer buffer
        DispatcherTimer autoProduceTimer = new DispatcherTimer(); //Auto producer
        DispatcherTimer customerSatisfactionTimer = new DispatcherTimer(); //Customer satisfaction bar

        double Speed = 1; //Multiplier of production speed and animations

        //Variable keeping track of what producer is currently producing
        Drinks.Drink product = Drinks.Drink.Soda;
        public MainWindow()
        {
            InitializeComponent();
            //Starts window in center of screen
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            //I'm using DispatcherTimers for my animations. It will run a method at every interval

            //Conveyor belt animation----
            sharedBufferTimer.Tick += SharedBufferAnimation;
            sharedBufferTimer.Interval = TimeSpan.FromMilliseconds(30);
            sharedBufferTimer.Start();

            sodaBufferTimer.Tick += SodaBufferAnimation;
            sodaBufferTimer.Interval = TimeSpan.FromMilliseconds(30);
            sodaBufferTimer.Start();

            beerBufferTimer.Tick += BeerBufferAnimation;
            beerBufferTimer.Interval = TimeSpan.FromMilliseconds(30);
            beerBufferTimer.Start();
            //Conveyor belt animation----

            //Cusomer satisfaction animation--
            customerSatisfactionTimer.Tick += CustomerSatisfactionAnimation;
            customerSatisfactionTimer.Interval = TimeSpan.FromMilliseconds(50);
            customerSatisfactionTimer.Start();
            //Cusomer satisfaction animation--

            //Auto produce
            autoProduceTimer.Tick += AutoProduce;
            autoProduceTimer.Interval = TimeSpan.FromMilliseconds(30);
            //Auto produce

            Splitter splitter = new Splitter();
            Consumer sodaConsumer = new Consumer();
            Consumer beerConsumer = new Consumer();

            //Unique to the splitter, it needs acess to 3 buffers, unlike the rest who only has access to one
            //Since threads only take one parameter I've put the 3 buffers in an array
            Queue<Product>[] buffers = new Queue<Product>[3];
            buffers[0] = sharedBuffer;
            buffers[1] = sodaBuffer;
            buffers[2] = beerBuffer;

            //Create and start splitter thread
            Thread splitterThread = new Thread(splitter.Split)
            {
                Name = "Splitter"
            };
            splitterThread.Start(buffers);

            //Create and start sodaConsumerThread
            Thread sodaConsumerThread = new Thread(sodaConsumer.Consume)
            {
                Name = "SodaConsumer"
            };
            sodaConsumerThread.Start(sodaBuffer);

            //Create and start beerConsumerThread
            Thread beerConsumerThread = new Thread(beerConsumer.Consume)
            {
                Name = "BeerConsumer"
            };
            beerConsumerThread.Start(beerBuffer);

        }

        void AutoProduce(object sender, EventArgs e)
        {
            if (RepeatButton.IsEnabled)
            {
                RoutedEventArgs x = new RoutedEventArgs(); //Dosen't do anything, but method requires it.
                RepeatButton_Click(RepeatButton, x);
            }
        }

        void RemoveAnimation()
        {
            //Adds all the images that have reached the final destination to the list of images that should be removed
            foreach (var x in myCanvas.Children.OfType<Image>())
            {
                if (Canvas.GetLeft(x) >= 350)
                {
                    if ((string)x.Tag == "Soda" || (string)x.Tag == "Beer")
                    {
                        itemRemover.Add(x);
                    }
                }
            }
            //Has to be in two different loops
            //One to identify, another to remove
            //If one loop did both, the loop would throw an error because the size of the collection would change while it is running

            //Call the method with loop to remove
            RemoveFromRemoveList();
        }

        void RemoveFromRemoveList()
        {
            foreach (Image y in itemRemover)
            {
                myCanvas.Children.Remove(y);
                FillSatisfactionBar((string)y.Tag); //Fill the satisfaction bar corresponding to the product removed
            }
            itemRemover.Clear(); //After they've been removed from the canvas, can also remove them from the list
        }

        //Technically does the oppsite of filling up the bar, but had to make a workaround
        //Using the background as the foreground so it's opposite.
        void FillSatisfactionBar(string type)
        {
            if (type == "Beer")
            {
                BeerSatisfactionBar.Value -= 33;
            }
            else if (type == "Soda")
            {
                SodaSatisfactionBar.Value -= 33;
            }
        }


        //Animation for customer satisfaction bar. Slowly increasing (decrasing visually)
        //If it fills up (Is empty visually) the applcation will close.
        void CustomerSatisfactionAnimation(object sender, EventArgs e)
        {
            SodaSatisfactionBar.Value += 0.1 * Speed;
            BeerSatisfactionBar.Value += 0.1 * Speed;

            if (BeerSatisfactionBar.Value >= BeerSatisfactionBar.Maximum || SodaSatisfactionBar.Value >= SodaSatisfactionBar.Maximum)
                Environment.Exit(0);
        }

        //Animation soda buffer queue
        void SodaBufferAnimation(object sender, EventArgs e)
        {
            lock (sodaBuffer)
            {
                foreach (Product soda in sodaBuffer)
                {
                    if (Canvas.GetLeft(soda.Image) <= 350)
                    {//If destination is not reached, move the soda bottle.
                        Canvas.SetTop(soda.Image, Canvas.GetTop(soda.Image) + 0.5 * Speed);
                        Canvas.SetLeft(soda.Image, Canvas.GetLeft(soda.Image) + 1 * Speed);
                    }
                    else
                    {//If destination is reached, call the method that removes the animation(The image from canvas)
                        RemoveAnimation();
                    }
                }
                Monitor.PulseAll(sodaBuffer);
            }
        }
        //Animation beer buffer queue
        void BeerBufferAnimation(object sender, EventArgs e)
        {
            lock (beerBuffer)
            {
                foreach (Product beer in beerBuffer)
                {

                    if (Canvas.GetLeft(beer.Image) <= 350)
                    {//Same as soda
                        Canvas.SetTop(beer.Image, Canvas.GetTop(beer.Image) - 0.5 * Speed);
                        Canvas.SetLeft(beer.Image, Canvas.GetLeft(beer.Image) + 1 * Speed);
                    }
                    else
                    {
                        RemoveAnimation();
                    }
                }
                Monitor.PulseAll(beerBuffer);
            }
        }
        void SharedBufferAnimation(object sender, EventArgs e)
        {
            lock (sharedBuffer)
            {
                foreach (Product product in sharedBuffer)
                {
                    if (Canvas.GetLeft(product.Image) <= 250)
                    {//If the product has no reached the splitter then move it
                        Canvas.SetLeft(product.Image, Canvas.GetLeft(product.Image) + 1 * Speed);
                    }
                    else
                    {//If it has reached the splitter, give it the tag "Arrived" 
                     //The splitter will then peek the queue, see that the first in queue has the state of arrived and will sort it
                        product.State = "Arrived";
                    }
                }
                Monitor.PulseAll(sharedBuffer);
            }
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            Producer.Value += 2 * Speed; //Every click or 33ms of holding, increase the progress bar (producer) with 2/100

            if (Producer.Value >= Producer.Maximum) //If full
            {
                Producer.Value = 0; //Set to 0

                //product is a variable keeping check if what the producer is currently producing.
                CreateBottle(product);
            }
        }

        void CreateBottle(Drinks.Drink type)
        {
            Image drink = new Image
            {
                Tag = type.ToString(),
                Source = new BitmapImage(new Uri(@"pack://application:,,,/FlaskeAutomat;component/Images/" + type + "Bottle.png")),
                Height = 50,
                Width = 50,
            };

            //Set image to be at start of conveyor belt
            Canvas.SetTop(drink, 189);
            Canvas.SetLeft(drink, 70);

            //Produce product and save it in a temp variable
            Product product = producer.Produce(sharedBuffer, type, drink);

            lock (sharedBuffer)
            {
                Monitor.PulseAll(sharedBuffer);
                sharedBuffer.Enqueue(product); //Add it to the sharedBuffer

            }
            //Set tool tip of the image to the ToString of Product.
            drink.ToolTip = product.ToString();

            //Add the drink to canvas
            myCanvas.Children.Add(drink);
        }

        private void sodaToggle_Checked(object sender, RoutedEventArgs e)
        {   //Soda radio button

            //Soda gradiant colour
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
            myLinearGradientBrush.StartPoint = new Point(0.5, 0);
            myLinearGradientBrush.EndPoint = new Point(0.5, 1);
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.2));
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.Brown, 0.9));
            Producer.Foreground = myLinearGradientBrush;

            product = Drinks.Drink.Soda;

            Producer.Value = 0;
        }

        private void beerToggle_Checked(object sender, RoutedEventArgs e)
        {   //Beer radio button

            //Beer gradiant colour
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
            myLinearGradientBrush.StartPoint = new Point(0.5, 0);
            myLinearGradientBrush.EndPoint = new Point(0.5, 1);
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.Brown, 0.2));
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.DarkOrange, 0.9));
            Producer.Foreground = myLinearGradientBrush;

            product = Drinks.Drink.Beer;

            Producer.Value = 0;
        }

        //Start button (Makes everything run)(On by default)
        private void ToggleButton_Start(object sender, RoutedEventArgs e)
        {
            StartButton.IsHitTestVisible = false;
            StopButton.IsHitTestVisible = true;

            StopButton.IsChecked = false;
            RepeatButton.IsEnabled = true;

            Splitter.turnedOn = true;
            Consumer.turnedOn = true;
            sodaBufferTimer.Start();
            beerBufferTimer.Start();
            sharedBufferTimer.Start();
            customerSatisfactionTimer.Start();
        }

        //Stop button (Makes everything stop)
        private void ToggleButton_Stop(object sender, RoutedEventArgs e)
        {

            StopButton.IsHitTestVisible = false;
            StartButton.IsHitTestVisible = true;

            StartButton.IsChecked = false;
            RepeatButton.IsEnabled = false; //Can't produce while it's stopped

            Splitter.turnedOn = false;
            Consumer.turnedOn = false;
            sodaBufferTimer.Stop();
            beerBufferTimer.Stop();
            sharedBufferTimer.Stop();
            customerSatisfactionTimer.Stop();
        }

        //Auto on and off. Makes the producer automatic (As if you were constantly holding mouse down on it)
        private void ToggleButton_Auto(object sender, RoutedEventArgs e)
        {
            autoProduceTimer.Start();
            RepeatButton.IsHitTestVisible = false; //Can't producer yourself when it's on auto.
        }
        private void ToggleOffButton_Auto(object sender, RoutedEventArgs e)
        {
            autoProduceTimer.Stop();
            RepeatButton.IsHitTestVisible = true;
        }



        //Change speed multiplier to 1, 1.5 and 2. Change opacity to visualise what level of speed is active.
        private void Speed1(object sender, MouseButtonEventArgs e)
        {
            Speed = 1;
            ImageSpeed1.Opacity = 1;
            ImageSpeed2.Opacity = 0.3;
            ImageSpeed3.Opacity = 0.3;
        }
        private void Speed2(object sender, MouseButtonEventArgs e)
        {
            Speed = 1.5;
            ImageSpeed1.Opacity = 1;
            ImageSpeed2.Opacity = 1;
            ImageSpeed3.Opacity = 0.3;
        }
        private void Speed3(object sender, MouseButtonEventArgs e)
        {
            Speed = 2;
            ImageSpeed1.Opacity = 1;
            ImageSpeed2.Opacity = 1;
            ImageSpeed3.Opacity = 1;
        }
    }
}
