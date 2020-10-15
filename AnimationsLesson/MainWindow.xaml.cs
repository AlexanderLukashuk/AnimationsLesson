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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimationsLesson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DoubleAnimation widthAnimation;
        private DoubleAnimation heightAnimation;

        private bool isAnimationCompleted = true;

        public MainWindow()
        {
            InitializeComponent();
            CreateAnimation();
        }

        private void CreateAnimation()
        {
            heightAnimation = new DoubleAnimation();
            heightAnimation.From = button.Height;
            heightAnimation.To = button.Height + 50;
            heightAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
            heightAnimation.AutoReverse = true;

            heightAnimation.Completed += HeightAnimationCompleted;

            widthAnimation = new DoubleAnimation();
            widthAnimation.From = button.Width;
            widthAnimation.To = button.Width + 50;
            widthAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
            widthAnimation.AutoReverse = true;

            widthAnimation.Completed += HeightAnimationCompleted;
        }

        private void HeightAnimationCompleted(object sender, EventArgs e)
        {
            isAnimationCompleted = true;
        }

        private void StartAnimation(object sender, RoutedEventArgs e)
        {
            if (isAnimationCompleted)
            {
                isAnimationCompleted = false;
                button.BeginAnimation(HeightProperty, heightAnimation);
                button.BeginAnimation(WidthProperty, widthAnimation);
            }
        }
    }
}
