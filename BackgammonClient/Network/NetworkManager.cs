using System;
using System.Net.Sockets;

namespace LogInClient.Network
{
    internal class NetworkManager 
    {
        public event Action<string> OnMessageReceive;

        private int m_PortNo = 5000;
        private string m_IpAddress = "127.0.0.1";
        private TcpClient m_Client;
        private byte[] m_Data;
        private bool m_IsConnected = false;

        public NetworkManager()
        {
            Connect();
        }

        public void Connect()
        {
            if (m_IsConnected)
            {
                return;
            }

            m_Client = new TcpClient();
            m_Client.Connect(m_IpAddress, m_PortNo);
            m_Data = new byte[m_Client.ReceiveBufferSize];
            m_Client.GetStream().BeginRead(m_Data, 0, Convert.ToInt32(m_Client.ReceiveBufferSize), ReceiveMessage, null);
            m_IsConnected = true;
        }

        public void SendMessage(string message)
        {
            try
            {
                NetworkStream ns = m_Client.GetStream();
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                //catch the exception
            }
        }

        public void Disconnect()
        {
            try
            {
                if (!m_IsConnected)
                {
                    return;
                }
                // disconnect form the server
                m_Client.GetStream().Close();
                m_Client.Close();
            }
            catch (Exception ex)
            {
                //catch the exception
            }
            finally
            {
                m_IsConnected = false;
            }
        }

        private void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                int bytesRead;

                // read the data from the server
                bytesRead = m_Client.GetStream().EndRead(ar);

                if (bytesRead < 1)
                {
                    return;
                }
                else
                {
                    string textFromServer = System.Text.Encoding.ASCII.GetString(m_Data, 0, bytesRead);
                    OnMessageReceive?.Invoke(textFromServer);
                }

                m_Client.GetStream().BeginRead(m_Data, 0, Convert.ToInt32(m_Client.ReceiveBufferSize), ReceiveMessage, null);
            }
            catch (Exception ex)
            {
                // ignor the error... fired when the user loggs off
            }
        }
    }
}
