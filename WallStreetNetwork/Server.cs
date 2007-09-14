using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using OSDevGrp.WallStreetGame;

namespace OSDevGrp.WallStreetGame
{
    public class Server : Communicator, IDisposable
    {
        private const byte SERVERVERSION_MAJOR = 1;
        private const byte SERVERVERSION_MINOR = 0;

        private Game _Game = null;
        private Version _Version = null;
        private bool _Running = false;
        private int _Port = 0;
        private int _MaxConnections = 0;
        private System.Collections.Generic.List<System.Threading.Thread> _UDPListeners = null;
        private System.Collections.Generic.List<System.Threading.Thread> _TCPListeners = null;

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
                UDPListeners = new System.Collections.Generic.List<System.Threading.Thread>();
                TCPListeners = new System.Collections.Generic.List<System.Threading.Thread>();
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

        private System.Collections.Generic.List<System.Threading.Thread> UDPListeners
        {
            get
            {
                return _UDPListeners;
            }
            set
            {
                _UDPListeners = value;
            }
        }

        private System.Collections.Generic.List<System.Threading.Thread> TCPListeners
        {
            get
            {
                return _TCPListeners;
            }
            set
            {
                _TCPListeners = value;
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
                        if (UDPListeners != null)
                            UDPListeners = null;
                        if (TCPListeners != null)
                            TCPListeners = null;
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
                        foreach (System.Net.IPAddress ipaddress in System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName()))
                        {
                            System.Net.Sockets.Socket socket = null;
                            System.Threading.Thread thread = null;
                            try
                            {
                                // Create UDP socket and thread.
                                socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp);
                                socket.Bind(new System.Net.IPEndPoint(ipaddress, Port));
                                thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(this.UDPListenerThread));
                                thread.Start(socket);
                                UDPListeners.Add(thread);
                                // Create TCP socket and thread.
                                socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
                                socket.Bind(new System.Net.IPEndPoint(ipaddress, Port));
                                socket.Listen(MaxConnections);
                                thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(this.TCPListenerThread));
                                thread.Start(socket);
                                TCPListeners.Add(thread);
                            }
                            catch (System.Net.Sockets.SocketException ex)
                            {
                                if (thread != null)
                                {
                                    if (thread.IsAlive)
                                    {
                                        thread.Abort();
                                        while (thread.IsAlive)
                                        {
                                            System.Threading.Thread.Sleep(250);
                                        }
                                    }
                                }
                                if (socket != null)
                                {
                                    if (socket.Connected)
                                        socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                                    socket.Close();
                                }
                                throw ex;
                            }
                            catch (System.Exception ex)
                            {
                                if (thread != null)
                                {
                                    if (thread.IsAlive)
                                    {
                                        thread.Abort();
                                        while (thread.IsAlive)
                                        {
                                            System.Threading.Thread.Sleep(250);
                                        }
                                    }
                                }
                                if (socket != null)
                                {
                                    if (socket.Connected)
                                        socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                                    socket.Close();
                                }
                                throw ex;
                            }
                        }
                        Running = (UDPListeners.Count > 0 || TCPListeners.Count > 0);
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
                        if (UDPListeners != null)
                        {
                            while (UDPListeners.Count > 0)
                            {
                                System.Threading.Thread thread = UDPListeners[0];
                                if (thread.IsAlive)
                                {
                                    thread.Abort();
                                    while (thread.IsAlive)
                                    {
                                        System.Threading.Thread.Sleep(250);
                                    }
                                }
                                UDPListeners.Remove(thread);
                            }
                        }
                        if (TCPListeners != null)
                        {
                            while (TCPListeners.Count > 0)
                            {
                                System.Threading.Thread thread = TCPListeners[0];
                                if (thread.IsAlive)
                                {
                                    thread.Abort();
                                    while (thread.IsAlive)
                                    {
                                        System.Threading.Thread.Sleep(250);
                                    }
                                }
                                TCPListeners.Remove(thread);
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

        private void UDPListenerThread(System.Object obj)
        {
            System.Net.Sockets.Socket serversocket = (System.Net.Sockets.Socket) obj;
            try
            {
                if (Version.Major > 0)
                {
                    while (true)
                    {
                        while (serversocket.Available > 0)
                        {
                            byte[] buffer = new byte[serversocket.Available];
                            System.Net.EndPoint client = (System.Net.EndPoint) new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0);
                            if (serversocket.ReceiveFrom(buffer, ref client) > 0)
                            {
                                string[] clientinformations = System.Text.Encoding.Unicode.GetString(buffer).Split('|');
                                if (clientinformations.Length >= 3)
                                {
                                    switch ((Commands) decimal.Parse(clientinformations[0]))
                                    {
                                        case Commands.GetServerInformations:
                                            Version clientversion = new Version(byte.Parse(clientinformations[1]), byte.Parse(clientinformations[2]));
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
                                                serverinformation += '|' + Version.Major.ToString() + "|" + Version.Minor.ToString();
                                                serversocket.SendTo(System.Text.Encoding.Unicode.GetBytes(serverinformation), client);
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                        System.Threading.Thread.Sleep(250);
                    }
                }
                if (serversocket.Connected)
                    serversocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                serversocket.Close();
            }
            catch (System.Threading.ThreadAbortException)
            {
                if (serversocket.Connected)
                    serversocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                serversocket.Close();
            }
            catch (System.Exception ex)
            {
                if (serversocket.Connected)
                    serversocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                serversocket.Close();
                throw ex;
            }
        }

        private void TCPListenerThread(System.Object obj)
        {
            System.Net.Sockets.Socket serversocket = (System.Net.Sockets.Socket) obj;
            try
            {
                if (Version.Major > 0)
                {
                    while (true)
                    {
                        serversocket.BeginAccept(new System.AsyncCallback(this.TCPListenerAcceptCallback), serversocket);
                        System.Threading.Thread.Sleep(250);
                    }
                }
                if (serversocket.Connected)
                    serversocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                serversocket.Close();
            }
            catch (System.Threading.ThreadAbortException)
            {
                if (serversocket.Connected)
                    serversocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                serversocket.Close();
            }
            catch (System.Exception ex)
            {
                if (serversocket.Connected)
                    serversocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                serversocket.Close();
                throw ex;
            }
        }

        private void TCPListenerAcceptCallback(System.IAsyncResult ar)
        {
            System.Net.Sockets.Socket serversocket = (System.Net.Sockets.Socket) ar.AsyncState;
            System.Net.Sockets.Socket clientsocket = null;
            try
            {
                clientsocket = serversocket.EndAccept(ar);
                Communication(clientsocket);
                clientsocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                clientsocket.Close();
            }
            catch (System.ObjectDisposedException)
            {
                // The socket has been closed.
                if (clientsocket != null)
                {
                    if (clientsocket.Connected)
                        clientsocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                    clientsocket.Close();
                }
            }
            catch (System.Exception ex)
            {
                if (clientsocket != null)
                {
                    if (clientsocket.Connected)
                        clientsocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                    clientsocket.Close();
                }
                throw ex;
            }
        }

        protected override void Communication(System.Net.Sockets.Socket socket)
        {
            try
            {
                bool disconnect = false;
                while (!disconnect)
                {
                    if (socket.Available > 0)
                    {
                    }
                    System.Threading.Thread.Sleep(250);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
