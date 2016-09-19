using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApplication1
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

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblAnswer.Content = "Answer = " + (long.Parse(txtFirstNumber.Text) * long.Parse(txtSecondNumber.Text));
            }
            catch { }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(slider.Value);
            lblSliderValue.Content = val;
            progressBar.Value = (val * val) / 100;
            lblProgressBarValue.Content = progressBar.Value;
        }

        private void Ellipse_MouseEnter(object sender, MouseEventArgs e)
        {
            elipse.Height += 10;
            elipse.Width += 10;
        }

        private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            elipse.Height -= 10;
            elipse.Width -= 10;
        }

        private void btnCloseExpander_Click(object sender, RoutedEventArgs e)
        {
            expander.IsExpanded = false;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.MiddleButton == MouseButtonState.Pressed) return;
            if (e.RightButton == MouseButtonState.Pressed) return;
            if (e.LeftButton != MouseButtonState.Pressed) return;

            if (WindowState == WindowState.Maximized && e.ClickCount != 2) return;

            DragMove();
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnJUST_Click(object sender, RoutedEventArgs e)
        {
            setImage("JUST.jpg");
        }
        
        private void btnSpongebob_Click(object sender, RoutedEventArgs e)
        {
            setImage("mfw.jpg");
        }

        private void setImage(string newImgStr)
        {
            ImageSourceValueSerializer Isvs = new ImageSourceValueSerializer();
            ImageSource newImgSrc = (ImageSource)Isvs.ConvertFromString(newImgStr, null);
            image.Source = newImgSrc;
        }

    }
}
