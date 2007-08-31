using System;
using System.Collections.Generic;
using System.Text;
using OSDevGrp.WallStreetGame;

namespace OSDevGrp.WallStreetGame
{
    public class Client : System.Object, IDisposable
    {
        private const byte CLIENTVERSION_MAJOR = 1;
        private const byte CLIENTVERSION_MINOR = 0;

        private Game _Game = null;
        private Version _Version = null;
        private int _Port = 0;

        #region IDisposable variables
        private bool _Disposed = false;
        #endregion

        public delegate bool BeforeConnect();
        public delegate void AfterConnect();
        public delegate bool BeforeDisconnect();
        public delegate void AfterDisconnect();

        private event BeforeConnect _BeforeConnectEvent = null;
        private event AfterConnect _AfterConnectEvent = null;
        private event BeforeDisconnect _BeforeDisconnectEvent = null;
        private event AfterDisconnect _AfterDisconnectEvent = null;

        public Client(Game game) : base()
        {
            try
            {
                Game = game;
                Version = new Version(CLIENTVERSION_MAJOR, CLIENTVERSION_MINOR);
                string s = System.Configuration.ConfigurationManager.AppSettings["Network.Port"];
                if (s == null)
                    throw new System.Configuration.ConfigurationErrorsException("No key named 'Network.Port' in the application configuration.");
                Port = int.Parse(s);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        ~Client()
        {
            try
            {
                Dispose(false);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public Game Game
        {
            get
            {
                return _Game;
            }
            private set
            {
                _Game = value;
            }
        }

        public Version Version
        {
            get
            {
                return _Version;
            }
            private set
            {
                _Version = value;
            }
        }

        private int Port
        {
            get
            {
                return _Port;
            }
            set
            {
                _Port = value;
            }
        }

        public bool Connected
        {
            get
            {
                return false;
            }
        }

        public BeforeConnect BeforeConnectEvent
        {
            get
            {
                return _BeforeConnectEvent;
            }
            set
            {
                _BeforeConnectEvent = value;
            }
        }

        public AfterConnect AfterConnectEvent
        {
            get
            {
                return _AfterConnectEvent;
            }
            set
            {
                _AfterConnectEvent = value;
            }
        }

        public BeforeDisconnect BeforeDisconnectEvent
        {
            get
            {
                return _BeforeDisconnectEvent;
            }
            set
            {
                _BeforeDisconnectEvent = value;
            }
        }

        public AfterDisconnect AfterDisconnectEvent
        {
            get
            {
                return _AfterDisconnectEvent;
            }
            set
            {
                _AfterDisconnectEvent = value;
            }
        }

        #region IDisposable properties
        private bool Disposed
        {
            get
            {
                return _Disposed;
            }
            set
            {
                _Disposed = value;
            }
        }
        #endregion

        #region IDisposable methods
        public void Dispose()
        {
            try
            {
                Dispose(true);
                System.GC.SuppressFinalize(this);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose(bool disposing)
        {
            try
            {
                if (!Disposed)
                {
                    if (Connected)
                    {
                        if (BeforeDisconnectEvent != null)
                            BeforeDisconnectEvent = null;
                        if (AfterDisconnectEvent != null)
                            AfterDisconnectEvent = null;
                        Disconnect();
                    }
                    if (disposing)
                    {
                        if (Game != null)
                            Game = null;
                        if (Version != null)
                            Version = null;
                        if (BeforeConnectEvent != null)
                            BeforeConnectEvent = null;
                        if (AfterConnectEvent != null)
                            AfterConnectEvent = null;
                        if (BeforeDisconnectEvent != null)
                            BeforeDisconnectEvent = null;
                        if (AfterDisconnectEvent != null)
                            AfterDisconnectEvent = null;
                    }
                    Disposed = true;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private ServerInformations GetServerInformations()
        {
            try
            {
                ServerInformations si = new ServerInformations();
                System.Net.Sockets.Socket socket = null;
                try
                {
                    socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp);
                    System.Net.IPHostEntry he = System.Net.Dns.GetHostEntry("255.255.255.255");
                    System.Net.IPEndPoint ep = new System.Net.IPEndPoint(he.AddressList[0], Port);

                    socket.SendTo(System.BitConverter.GetBytes(0), ep);

                }
                catch (System.Exception ex)
                {
                    if (socket != null)
                        socket.Close();
                    throw ex;
                }
                return si;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Connect()
        {
            try
            {
                if (!Connected)
                {
                    bool b = true;
                    if (BeforeConnectEvent != null)
                        b = BeforeConnectEvent();
                    if (b)
                    {
                        ServerInformations si = GetServerInformations();
                        if (AfterConnectEvent != null)
                            AfterConnectEvent();
                        if (Game.UpdateStockInformationsEvent != null)
                            Game.UpdateStockInformationsEvent();
                        if (Game.UpdatePlayerInformationsEvent != null)
                            Game.UpdatePlayerInformationsEvent();
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (Connected)
                {
                    bool b = true;
                    if (BeforeDisconnectEvent != null)
                        b = BeforeDisconnectEvent();
                    if (b)
                    {
                        if (AfterDisconnectEvent != null)
                            AfterDisconnectEvent();
                        if (Game.UpdateStockInformationsEvent != null)
                            Game.UpdateStockInformationsEvent();
                        if (Game.UpdatePlayerInformationsEvent != null)
                            Game.UpdatePlayerInformationsEvent();
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
