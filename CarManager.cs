using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Windows;

namespace DesktopApp
{
    class CarManager
    {
        public string IP { get; set; }
        public int Port { get; set; }


        TcpClient tcpclnt = new TcpClient();
        public void Connect(string ip, int port) 
        {
            try
            {
                tcpclnt.Connect(ip, port);
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection error...  " + e.StackTrace + "leeeeeeeeeeeeeelelelelelelelel");  
            }
        }

        private void SendCommand(string command)
        {
            try
            {
                //Enter the string to be transmitted:
                string str = command;
                Stream stm = tcpclnt.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] b = asen.GetBytes(str);
                //Transmitting.....
                stm.Write(b, 0, b.Length);
            }
            catch (Exception e)
            {
                MessageBox.Show("Can't send the command.");
            }
            
        }
        public void Go()
        {
            SendCommand("g");
        }

        public void Stop()
        {
            SendCommand("s");
        }

        public void Disconnect()
        {
            tcpclnt.Close();
        }

    }
}
