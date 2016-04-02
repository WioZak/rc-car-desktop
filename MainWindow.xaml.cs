using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace RCCarDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string IP;
        private int Port;

        CarManager car = new CarManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                car.Connect(IP, Port);
            }
            catch (Exception)
            {
                MessageBox.Show("Connection error...  ");
            }
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                car.Go();
            }
            catch (Exception)
            {
                MessageBox.Show("Can't send the command.");
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                car.Stop();
            }
            catch (Exception)
            {
                MessageBox.Show("Can't send the command.");
            }
        }

        private void GetIp(object sender, TextChangedEventArgs e)
        {
            TextBox ipTextBox = (TextBox)sender;
            string ip = ipTextBox.Text;
            IP = ip;
        }

        private void GetPort(object sender, TextChangedEventArgs e)
        {
            TextBox portTextBox = (TextBox)sender;
            int port = Convert.ToInt32(portTextBox.Text);
            Port = port;            
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            car.Disconnect();
        }
    }
}
