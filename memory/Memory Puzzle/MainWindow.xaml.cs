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

namespace Memory_Puzzle
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            timer2.Interval = new TimeSpan(0, 0, 1);
            timer2.Tick += new EventHandler(removing);
            timer3.Interval = new TimeSpan(0, 0, 1);
            timer3.Tick += new EventHandler(addEvents);
        }

        DispatcherTimer timer1 = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();
        DispatcherTimer timer3 = new DispatcherTimer();

        Image[] image = new Image[16];

        Random r = new Random();
        BitmapImage[] bi = new BitmapImage[10];
        int[] num = new int[16];
        int countOne = 0;
        int countTwo = 0;
        int count = 0;
        bool remove = false;
        bool over = false;
        int countWin = 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bi[0] = new BitmapImage(new Uri("/Resourses/рубашка.jpg", UriKind.Relative));
            bi[1] = new BitmapImage(new Uri("/Resourses/1.jpg", UriKind.Relative));
            bi[2] = new BitmapImage(new Uri("/Resourses/2.jpg", UriKind.Relative));
            bi[3] = new BitmapImage(new Uri("/Resourses/3.jpg", UriKind.Relative));
            bi[4] = new BitmapImage(new Uri("/Resourses/4.jpg", UriKind.Relative));
            bi[5] = new BitmapImage(new Uri("/Resourses/5.jpg", UriKind.Relative));
            bi[6] = new BitmapImage(new Uri("/Resourses/6.jpg", UriKind.Relative));
            bi[7] = new BitmapImage(new Uri("/Resourses/7.jpg", UriKind.Relative));
            bi[8] = new BitmapImage(new Uri("/Resourses/8.jpg", UriKind.Relative));
            bi[9] = new BitmapImage(new Uri("/Resourses/фон.jpg", UriKind.Relative));

            Image background = new Image
            {
                Width = 1360,
                Height = 815
            };
            Canvas.SetTop(background, 0);
            Canvas.SetLeft(background, 0);
            background.Source = bi[9];
            canvas.Children.Add(background);
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < 16; i++)
            {
                bool b = false;
                while (!b)
                {
                    int count = 0;
                    num[i] = r.Next(1, 9);
                    for (int j = 0; j < i; j++)
                    {
                        if (num[j] == num[i])
                        {
                            count++;
                        }

                    }
                    if (count < 2)
                    {
                        b = true;
                    }
                }

            }

            int top = 12;
            int left = 20;
            for (int i = 0; i < 16; i++)
            {
                image[i] = new Image();
                image[i].MouseDown += Image_MouseDown;
                //image[i].MouseUp += Image_MouseUp;
                image[i].Width = 230;
                image[i].Height = 180;
                Canvas.SetTop(image[i], top);
                Canvas.SetLeft(image[i], left);
                image[i].Source = bi[num[i]];
                canvas.Children.Add(image[i]);
                if ((i + 1) % 4 == 0)
                {
                    top += 200;
                    left = 12;
                }
                else
                {
                    left += 280;
                }


            }

            image[0].MouseUp += Image_MouseUp0;
            image[1].MouseUp += Image_MouseUp1;
            image[2].MouseUp += Image_MouseUp2;
            image[3].MouseUp += Image_MouseUp3;
            image[4].MouseUp += Image_MouseUp4;
            image[5].MouseUp += Image_MouseUp5;
            image[6].MouseUp += Image_MouseUp6;
            image[7].MouseUp += Image_MouseUp7;
            image[8].MouseUp += Image_MouseUp8;
            image[9].MouseUp += Image_MouseUp9;
            image[10].MouseUp += Image_MouseUp10;
            image[11].MouseUp += Image_MouseUp11;
            image[12].MouseUp += Image_MouseUp12;
            image[13].MouseUp += Image_MouseUp13;
            image[14].MouseUp += Image_MouseUp14;
            image[15].MouseUp += Image_MouseUp15;

            timer1.Interval = new TimeSpan(0, 0, 5);
            timer1.Tick += new EventHandler(overlap);

            timer1.Start();
        }

        private void addEvents(object Sender, EventArgs e)
        {
            image[0].MouseUp += Image_MouseUp0;
            image[1].MouseUp += Image_MouseUp1;
            image[2].MouseUp += Image_MouseUp2;
            image[3].MouseUp += Image_MouseUp3;
            image[4].MouseUp += Image_MouseUp4;
            image[5].MouseUp += Image_MouseUp5;
            image[6].MouseUp += Image_MouseUp6;
            image[7].MouseUp += Image_MouseUp7;
            image[8].MouseUp += Image_MouseUp8;
            image[9].MouseUp += Image_MouseUp9;
            image[10].MouseUp += Image_MouseUp10;
            image[11].MouseUp += Image_MouseUp11;
            image[12].MouseUp += Image_MouseUp12;
            image[13].MouseUp += Image_MouseUp13;
            image[14].MouseUp += Image_MouseUp14;
            image[15].MouseUp += Image_MouseUp15;
            timer3.Stop();
        }

        private void removeEvents()
        {
            image[0].MouseUp -= Image_MouseUp0;
            image[1].MouseUp -= Image_MouseUp1;
            image[2].MouseUp -= Image_MouseUp2;
            image[3].MouseUp -= Image_MouseUp3;
            image[4].MouseUp -= Image_MouseUp4;
            image[5].MouseUp -= Image_MouseUp5;
            image[6].MouseUp -= Image_MouseUp6;
            image[7].MouseUp -= Image_MouseUp7;
            image[8].MouseUp -= Image_MouseUp8;
            image[9].MouseUp -= Image_MouseUp9;
            image[10].MouseUp -= Image_MouseUp10;
            image[11].MouseUp -= Image_MouseUp11;
            image[12].MouseUp -= Image_MouseUp12;
            image[13].MouseUp -= Image_MouseUp13;
            image[14].MouseUp -= Image_MouseUp14;
            image[15].MouseUp -= Image_MouseUp15;
        }

        private void overlap(object Sender, EventArgs e)
        {
            for (int i = 0; i < 16; i++)
            {
                image[i].Source = bi[0];
            }
            timer1.Stop();
        }

        private void Win()
        {
            Image backgroundWin = new Image
            {
                Width = 1100,
                Height = 715
            };
            Canvas.SetTop(backgroundWin, 50);
            Canvas.SetLeft(backgroundWin, 100);
            BitmapImage winning = new BitmapImage(new Uri("/Resourses/Победа.jpg", UriKind.Relative));
            backgroundWin.Source = winning;
            canvas.Children.Add(backgroundWin);
        }

        private void removing (object Sender, EventArgs e)
        {
            if (remove)
            {
                image[countOne].Source = bi[0];
                image[countTwo].Source = bi[0];
                canvas.Children.Remove(image[countOne]);
                canvas.Children.Remove(image[countTwo]);
                remove = false;
                countWin++;
                if (countWin == 8)
                {
                    Win();
                }
                countOne = 0;
                countTwo = 0;
                timer2.Stop();
                return;
            }

            if (over)
            {
                image[countOne].Source = bi[0];
                image[countTwo].Source = bi[0];
                over = false;
                countOne = 0;
                countTwo = 0;
                timer2.Stop();
                return;
            }
            
        }

        private void click()
        {
            
            for (int i = 0; i < image.Length; i++)
            {
                for (int j = 0; j < image.Length; j++)
                {
                    

                    if (image[i].Source == image[j].Source & image[i].Source != bi[0] & image[j].Source != bi[0] & image[i].Source != null & i!=j)
                    {
                        countOne = i;
                        countTwo = j;
                        remove = true;
                        timer2.Start();
                    }
                    else if (image[i].Source != image[j].Source & (image[i].Source != bi[0] & image[j].Source != bi[0]))
                    {
                        countOne = i;
                        countTwo = j;
                        over = true;
                        timer2.Start();
                    }
                   /* else if (image[i].Source != bi[0])
                    {
                        image[i].Source = bi[num[i]];
                    }*/
                }
            }
            
            
           
        }
       


        private DateTime downTime;
        private object downSender;

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.downSender = sender;
                this.downTime = DateTime.Now;
                
                
            }
        }      

        private void Image_MouseUp0(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {
                    
                    image[0].Source = bi[num[0]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }


                    // Do click
                }
            }
        }

        private void Image_MouseUp1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    image[1].Source = bi[num[1]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }
                    // Do click
                }
            }
        }

        private void Image_MouseUp2(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    image[2].Source = bi[num[2]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }
                    // Do click
                }
            }
        }

        private void Image_MouseUp3(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    image[3].Source = bi[num[3]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }
                    // Do click
                }
            }
        }

        private void Image_MouseUp4(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    image[4].Source = bi[num[4]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }
                    // Do click
                }
            }
        }

        private void Image_MouseUp5(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    image[5].Source = bi[num[5]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }
                    // Do click
                }
            }
        }

        private void Image_MouseUp6(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    image[6].Source = bi[num[6]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }
                    // Do click
                }
            }
        }

        private void Image_MouseUp7(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    image[7].Source = bi[num[7]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }
                    // Do click
                }
            }
        }

        private void Image_MouseUp8(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    image[8].Source = bi[num[8]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }
                    // Do click
                }
            }
        }

        private void Image_MouseUp9(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    image[9].Source = bi[num[9]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }
                    // Do click
                }
            }
        }

        private void Image_MouseUp10(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    image[10].Source = bi[num[10]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }
                    // Do click
                }
            }
        }

        private void Image_MouseUp11(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    image[11].Source = bi[num[11]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }
                    // Do click
                }
            }
        }

        private void Image_MouseUp12(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    image[12].Source = bi[num[12]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }
                    // Do click
                }
            }
        }

        private void Image_MouseUp13(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    image[13].Source = bi[num[13]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }
                    // Do click
                }
            }
        }

        private void Image_MouseUp14(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    image[14].Source = bi[num[14]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }
                    // Do click
                }
            }
        }

        private void Image_MouseUp15(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {

                    image[15].Source = bi[num[15]];
                    count++;
                    click();
                    if (count == 2)
                    {
                        removeEvents();
                        timer3.Start();
                        count = 0;
                    }
                    // Do click
                }
            }
        }

        
    }
}
