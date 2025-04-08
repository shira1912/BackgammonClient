using DataProtocols;
using Encryption;
using Newtonsoft.Json;
using System;

namespace LogInClient.Network
{
    internal class SecureNetworkManager 
    {
        public event Action<string> OnMessageReceive;

        private NetworkManager m_NetworkManager;
        private AESEncryption m_AESEncryption;
        private RSAEncryption m_RSAEncryption;

        public SecureNetworkManager()
        {
            m_NetworkManager = new NetworkManager();
            m_AESEncryption = new AESEncryption();
            m_RSAEncryption = new RSAEncryption();
        }

        public void Connect()
        {
            var publicKey = new RSAPublicKey();
            publicKey.DataType = DataType.RSAKey;

            publicKey.PublicKey = m_RSAEncryption.GetPublicKey();

            m_NetworkManager.SendMessage(JsonConvert.SerializeObject(publicKey, Formatting.Indented));
            m_NetworkManager.OnMessageReceive += OnKeyReceive;
        }

        public void SendMessage(string message)
        {
            var chyperdMessage = m_AESEncryption.Encrypt(message);
            m_NetworkManager.SendMessage(chyperdMessage);
        }

        public void Disconnect()
        {
            m_NetworkManager.OnMessageReceive -= OnMessageReceiveFromServer;
            m_NetworkManager.Disconnect();
        }

        private void OnMessageReceiveFromServer(string message)
        {
            var decryptedMessage = m_AESEncryption.Decrypt(message);
            OnMessageReceive.Invoke(decryptedMessage);
        }

        private void OnKeyReceive(string message)
        {
            var decryptedMessage = m_RSAEncryption.Decrypt(message);

            var aesKey = ConvertUtils.Deserialize<AESKey>(decryptedMessage);

            m_AESEncryption.LoadKey(aesKey.Key);
            m_AESEncryption.LoadIV(aesKey.IV);

            m_NetworkManager.OnMessageReceive += OnMessageReceiveFromServer;
            m_NetworkManager.OnMessageReceive -= OnKeyReceive;
        }
    }
}
