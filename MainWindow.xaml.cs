using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DialogBox dialogBox = new DialogBox(); // @todo add dialogboxes to catch exceptions
        CarManager car = new CarManager();
        public MainWindow()
        {
            InitializeComponent();
            goButton.Click += GoButton_Click;
            stopButton.Click += StopButton_Click;
            connectButton.Click += ConnectButton_Click;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {           
            car.Connect(car.IP, car.Port);
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            car.Go();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            car.Stop();
        }

        private void GetIp(object sender, TextChangedEventArgs e)
        {
            TextBox ipTextBox = (TextBox)sender;
            string ip = ipTextBox.Text;
            car.IP = ip; //using car properties because don't know how to send ip and port to connect method
        }

        private void GetPort(object sender, TextChangedEventArgs e)
        {
            TextBox portTextBox = (TextBox)sender;
            int port = Convert.ToInt32(portTextBox.Text);
            car.Port = port;            
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            car.Disconnect();
        }
    }
}
