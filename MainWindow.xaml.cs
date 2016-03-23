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
        public static string IP { get; set; }
        public static int Port { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            goButton.Click += GoButton_Click;
            stopButton.Click += StopButton_Click;
        }

        private void ipTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox ipTextBox = (TextBox)sender;
            IP = ipTextBox.Text;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void portTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox portTextBox = (TextBox)sender;
            Port = Convert.ToInt32(portTextBox.Text);
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            ClientClass.Connect(IP, Port, "g");
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            ClientClass.Connect(IP, Port, "s");
        }
    }
}
