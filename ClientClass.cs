using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace DesktopApp
{
    class ClientClass
    {
        public static void Connect(string ip, int port, string command) //get command from button
        {

            try
            {
                TcpClient tcpclnt = new TcpClient();
                tcpclnt.Connect(ip, port);

                //Enter the string to be transmitted:
                String str = command;
                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                //Transmitting.....

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);

                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(bb[i]));

                tcpclnt.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }

    }
}
