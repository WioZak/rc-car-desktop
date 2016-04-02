using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Windows;

namespace RCCarDesktop
{
    class CarManager
    {
        TcpClient tcpclnt;
        private string goForward = "g";
        private string stop = "s";

        public void Connect(string ip, int port) 
        {
            tcpclnt = new TcpClient();
            tcpclnt.Connect(ip, port);
        }

        private void SendCommand(string command)
        {
            
            //Enter the string to be transmitted:
            string str = command;
            Stream stm = tcpclnt.GetStream();
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] b = asen.GetBytes(str);
            //Transmitting.....
            stm.Write(b, 0, b.Length);    
        }
        public void Go()
        {
            SendCommand(goForward);
        }

        public void Stop()
        {
            SendCommand(stop);
        }

        public void Disconnect()
        {
            tcpclnt.Close();
        }

    }
}
