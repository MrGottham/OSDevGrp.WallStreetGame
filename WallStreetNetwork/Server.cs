using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using OSDevGrp.WallStreetGame;

namespace OSDevGrp.WallStreetGame
{
    public class Server : System.Object, IDisposable
    {
        private const byte SERVERVERSION_MAJOR = 1;
        private const byte SERVERVERSION_MINOR = 0;

        private Game _Game = null;
        private Version _Version = null;
        private bool _Running = false;
        private int _Port = 0;
        private int _MaxConnections = 0;
        private System.Threading.Thread _UDPListener = null;
        private System.Net.Sockets.Socket _UDPSocket = null;
        private System.Threading.Thread _TCPListener = null;

        #region IDisposable variables
        private bool _Disposed = false;
        #endregion

        public delegate bool BeforeStart();
        public delegate void AfterStart();
        public delegate bool BeforeStop();
        public delegate void AfterStop();
        public delegate string GetServerInformation();

        private event BeforeStart _BeforeStartEvent = null;
        private event AfterStart _AfterStartEvent = null;
        private event BeforeStop _BeforeStopEvent = null;
        private event AfterStop _AfterStopEvent = null;
        private event GetServerInformation _GetServerInformationEvent = null;

        public Server(Game game) : base()
        {
            try
            {
                Game = game;
                Version = new Version(SERVERVERSION_MAJOR, SERVERVERSION_MINOR);
                string s = System.Configuration.ConfigurationManager.AppSettings["Network.Port"];
                if (s == null)
                    throw new System.Configuration.ConfigurationErrorsException("No key named 'Network.Port' in the application configuration.");
                Port = int.Parse(s);
                s = System.Configuration.ConfigurationManager.AppSettings["Network.MaxConnections"];
                if (s == null)
                    throw new System.Configuration.ConfigurationErrorsException("No key named 'Network.MaxConnections' in the application configuration.");
                MaxConnections = int.Parse(s);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        ~Server()
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

        public bool Running
        {
            get
            {
                return _Running;
            }
            private set
            {
                _Running = value;
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

        private int MaxConnections
        {
            get
            {
                return _MaxConnections;
            }
            set
            {
                _MaxConnections = value;
            }
        }

        private System.Threading.Thread UDPListener
        {
            get
            {
                return _UDPListener;
            }
            set
            {
                _UDPListener = value;
            }
        }

        private System.Net.Sockets.Socket UDPSocket
        {
            get
            {
                return _UDPSocket;
            }
            set
            {
                _UDPSocket = value;
            }
        }

        private System.Threading.Thread TCPListener
        {
            get
            {
                return _TCPListener;
            }
            set
            {
                _TCPListener = value;
            }
        }

        public BeforeStart BeforeStartEvent
        {
            get
            {
                return _BeforeStartEvent;
            }
            set
            {
                _BeforeStartEvent = value;
            }
        }

        public AfterStart AfterStartEvent
        {
            get
            {
                return _AfterStartEvent;
            }
            set
            {
                _AfterStartEvent = value;
            }
        }

        public BeforeStop BeforeStopEvent
        {
            get
            {
                return _BeforeStopEvent;
            }
            set
            {
                _BeforeStopEvent = value;
            }
        }

        public AfterStop AfterStopEvent
        {
            get
            {
                return _AfterStopEvent;
            }
            set
            {
                _AfterStopEvent = value;
            }
        }

        public GetServerInformation GetServerInformationEvent
        {
            get
            {
                return _GetServerInformationEvent;
            }
            set
            {
                _GetServerInformationEvent = value;
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

        private void Dispose(bool disposing)
        {
            try
            {
                if (!Disposed)
                {
                    if (Running)
                    {
                        if (BeforeStopEvent != null)
                            BeforeStopEvent = null;
                        if (AfterStopEvent != null)
                            AfterStopEvent = null;
                        Stop();
                    }
                    if (disposing)
                    {
                        if (Game != null)
                            Game = null;
                        if (Version != null)
                            Version = null;
                        if (UDPListener != null)
                            UDPListener = null;
                        if (TCPListener != null)
                            TCPListener = null;
                        if (BeforeStartEvent != null)
                            BeforeStartEvent = null;
                        if (AfterStartEvent != null)
                            AfterStartEvent = null;
                        if (BeforeStopEvent != null)
                            BeforeStopEvent = null;
                        if (AfterStopEvent != null)
                            AfterStopEvent = null;
                        if (GetServerInformationEvent != null)
                            GetServerInformationEvent = null;
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

        public void Start()
        {
            try
            {
                if (!Running)
                {
                    bool b = true;
                    if (BeforeStartEvent != null)
                        b = BeforeStartEvent();
                    if (b)
                    {
                        Game.Reset(Game.Random, true);
                        if (UDPListener == null)
                        {
                            UDPListener = new System.Threading.Thread(new System.Threading.ThreadStart(this.UDPListenerThread));
                            UDPListener.Start();
                        }
                        if (TCPListener == null)
                        {
                            TCPListener = new System.Threading.Thread(new System.Threading.ThreadStart(this.TCPListenerThread));
                            TCPListener.Start();
                        }
                        Running = true;
                        if (AfterStartEvent != null)
                            AfterStartEvent();
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Stop()
        {
            try
            {
                if (Running)
                {
                    bool b = true;
                    if (BeforeStopEvent != null)
                        b = BeforeStopEvent();
                    if (b)
                    {
                        if (UDPListener != null)
                        {
                            if (UDPListener.IsAlive)
                            {
                                UDPListener.Abort();
                                while (UDPListener.IsAlive)
                                {
                                    System.Threading.Thread.Sleep(250);
                                }
                            }
                            UDPListener = null;
                        }
                        if (TCPListener != null)
                        {
                            if (TCPListener.IsAlive)
                            {
                                TCPListener.Abort();
                                while (TCPListener.IsAlive)
                                {
                                    System.Threading.Thread.Sleep(250);
                                }
                            }
                        }
                        Running = false;
                        if (AfterStopEvent != null)
                            AfterStopEvent();
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void UDPListenerThread()
        {
            try
            {
                UDPSocket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp);
                UDPSocket.Blocking = false;
                UDPSocket.DontFragment = true;
                UDPSocket.EnableBroadcast = true;
                UDPSocket.MulticastLoopback = false;
                UDPSocket.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, Port));
                if (Version.Major > 0)
                {
                    while (true)
                    {
                        if (UDPSocket.Available > 0)
                        {
                            byte[] buffer = new byte[UDPSocket.Available];
                            System.Net.EndPoint client = (System.Net.EndPoint) new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0);
                            if (UDPSocket.ReceiveFrom(buffer, ref client) > 0)
                            {
                                string[] s = System.Text.Encoding.Unicode.GetString(buffer).Split('|');
                                if (s.Length >= 3)
                                {
                                    switch ((Commands) decimal.Parse(s[0]))
                                    {
                                        case Commands.GetServerInformations:
                                            Version clientversion = new Version(byte.Parse(s[1]), byte.Parse(s[2]));
                                            if (clientversion.Major < Version.Major || (clientversion.Major == Version.Major && clientversion.Minor <= Version.Minor))
                                            {
                                                string serverinformation = "Wall Street Game Server on " + System.Environment.MachineName;
                                                if (GetServerInformationEvent != null)
                                                {
                                                    serverinformation = GetServerInformationEvent();
                                                    if (serverinformation == null)
                                                        serverinformation = String.Empty;
                                                    serverinformation = serverinformation.Replace("|", null);
                                                }
                                                serverinformation += "|" + Version.Major.ToString() + "|" + Version.Minor.ToString();
                                                UDPSocket.SendTo(System.Text.Encoding.Unicode.GetBytes(serverinformation), client);
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                UDPSocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                UDPSocket.Close();
                UDPSocket = null;
            }
            catch (System.Threading.ThreadAbortException)
            {
                if (UDPSocket != null)
                {
                    UDPSocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                    UDPSocket.Close();
                    UDPSocket = null;
                }
            }
            catch (System.Exception ex)
            {
                if (UDPSocket != null)
                {
                    UDPSocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                    UDPSocket.Close();
                    UDPSocket = null;
                }
                throw ex;
            }
        }

        private void TCPListenerThread()
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
