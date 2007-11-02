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

        private bool _Running = false;
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
        public delegate void OnPlayerConnected(Player player);
        public delegate void OnPlayerDisconnected(Player player);

        private event BeforeStart _BeforeStartEvent = null;
        private event AfterStart _AfterStartEvent = null;
        private event BeforeStop _BeforeStopEvent = null;
        private event AfterStop _AfterStopEvent = null;
        private event GetServerInformation _GetServerInformationEvent = null;
        private event OnPlayerConnected _OnPlayerConnectedEvent = null;
        private event OnPlayerDisconnected _OnPlayerDisconnectedEvent = null;

        private class StateObject : System.Object
        {
            private System.Net.Sockets.Socket _ServerSocket = null;
            private byte[] _Buffer = null;

            public StateObject(System.Net.Sockets.Socket serversocket, byte[] buffer) : base()
            {
                try
                {
                    ServerSocket = serversocket;
                    Buffer = buffer;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }

            public System.Net.Sockets.Socket ServerSocket
            {
                get
                {
                    return _ServerSocket;
                }
                private set
                {
                    _ServerSocket = value;
                }
            }

            public byte[] Buffer
            {
                get
                {
                    return _Buffer;
                }
                private set
                {
                    _Buffer = value;
                }
            }
        }

        public Server(Game game, System.ComponentModel.ISynchronizeInvoke synchronize) : base(game, new Version(SERVERVERSION_MAJOR, SERVERVERSION_MINOR), synchronize)
        {
            try
            {
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

        public OnPlayerConnected OnPlayerConnectedEvent
        {
            get
            {
                return _OnPlayerConnectedEvent;
            }
            set
            {
                _OnPlayerConnectedEvent = value;
            }
        }

        public OnPlayerDisconnected OnPlayerDisconnectedEvent
        {
            get
            {
                return _OnPlayerDisconnectedEvent;
            }
            set
            {
                _OnPlayerDisconnectedEvent = value;
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
                        if (OnPlayerDisconnectedEvent != null)
                            OnPlayerDisconnectedEvent = null;
                        Game.UpdateStockInformations usi = Game.UpdateStockInformationsEvent;
                        Game.UpdateStockInformationsEvent = null;
                        Game.UpdatePlayerInformations upi = Game.UpdatePlayerInformationsEvent;
                        Game.UpdatePlayerInformationsEvent = null;
                        Stop();
                        Game.UpdateStockInformationsEvent = usi;
                        Game.UpdatePlayerInformationsEvent = upi;
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
                        if (OnPlayerConnectedEvent != null)
                            OnPlayerConnectedEvent = null;
                        if (OnPlayerDisconnectedEvent != null)
                            OnPlayerDisconnectedEvent = null;
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

        private void CreateListeners(System.Net.IPAddress ipaddress)
        {
            try
            {
                System.Net.Sockets.Socket socket = null;
                System.Threading.Thread thread = null;
                try
                {
                    // Create UDP socket and thread.
                    socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp);
                    socket.EnableBroadcast = true;
                    socket.SetSocketOption(System.Net.Sockets.SocketOptionLevel.Socket, System.Net.Sockets.SocketOptionName.ReuseAddress, 1);
                    socket.SetSocketOption(System.Net.Sockets.SocketOptionLevel.Socket, System.Net.Sockets.SocketOptionName.Broadcast, 1);
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
                        {
                            socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                            socket.Disconnect(false);
                        }
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
                        {
                            socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                            socket.Disconnect(false);
                        }
                        socket.Close();
                    }
                    throw ex;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

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
                        bool containsloopback = false;
                        foreach (System.Net.IPAddress ipaddress in System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName()))
                        {
                            CreateListeners(ipaddress);
                            if (ipaddress.Equals(System.Net.IPAddress.Loopback))
                                containsloopback = true;
                        }
                        if (!containsloopback)
                            CreateListeners(System.Net.IPAddress.Loopback);
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
                        StateObject so = new StateObject(serversocket, new byte[512]);
                        System.Net.EndPoint client = new System.Net.IPEndPoint(System.Net.IPAddress.None, 0);
                        System.IAsyncResult ar = serversocket.BeginReceiveMessageFrom(so.Buffer, 0, so.Buffer.Length, System.Net.Sockets.SocketFlags.None, ref client, new AsyncCallback(UDPListenerReceiveCallback), so);
                        while (!ar.IsCompleted)
                        {
                            System.Threading.Thread.Sleep(250);
                        }
                    }
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                // Don't throw an exception, the thread has just aborted.
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (serversocket.Connected)
                {
                    serversocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                    serversocket.Disconnect(false);
                }
                serversocket.Close();
            }
        }

        private void UDPListenerReceiveCallback(System.IAsyncResult ar)
        {
            System.Net.Sockets.Socket serversocket = ((StateObject) ar.AsyncState).ServerSocket;
            byte[] buffer = ((StateObject) ar.AsyncState).Buffer;
            try
            {
                System.Net.Sockets.SocketFlags sf = System.Net.Sockets.SocketFlags.None;
                System.Net.EndPoint client = new System.Net.IPEndPoint(System.Net.IPAddress.None, 0);
                System.Net.Sockets.IPPacketInformation pi = new System.Net.Sockets.IPPacketInformation();
                int received = serversocket.EndReceiveMessageFrom(ar, ref sf, ref client, out pi);
                if (received > 0)
                {
                    string[] clientinformations = System.Text.Encoding.Unicode.GetString(buffer, 0, received).Split('|');
                    if (clientinformations.Length >= 3)
                    {
                        switch ((Commands) int.Parse(clientinformations[0]))
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
                                    serverinformation += '|' + Version.Major.ToString() + '|' + Version.Minor.ToString() + '|';
                                    serversocket.SendTo(System.Text.Encoding.Unicode.GetBytes(serverinformation), client);
                                }
                                break;
                        }
                    }
                }
            }
            catch (System.ObjectDisposedException)
            {
                // The socket has been closed.
            }
            catch (System.Exception ex)
            {
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
                        System.Collections.Generic.List<System.Net.Sockets.Socket> listenersockets = new System.Collections.Generic.List<System.Net.Sockets.Socket>(1);
                        listenersockets.Add(serversocket);
                        System.Net.Sockets.Socket.Select(listenersockets, null, null, 1000);
                        if (listenersockets.Count > 0)
                        {
                            listenersockets[0].BeginAccept(new System.AsyncCallback(this.TCPListenerAcceptCallback), listenersockets[0]);
                        }
                    }
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                // Don't throw an exception, the thread has just aborted.
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (serversocket.Connected)
                {
                    serversocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                    serversocket.Disconnect(false);
                }
                serversocket.Close();
            }
        }

        private void TCPListenerAcceptCallback(System.IAsyncResult ar)
        {
            System.Net.Sockets.Socket serversocket = (System.Net.Sockets.Socket) ar.AsyncState;
            System.Net.Sockets.Socket clientsocket = null;
            try
            {
                // Accepting new connections on the server socket.
                serversocket.BeginAccept(new System.AsyncCallback(this.TCPListenerAcceptCallback), serversocket);
                // Accepting the incoming connection.
                clientsocket = serversocket.EndAccept(ar);
                Communication(clientsocket);
            }
            catch (System.ObjectDisposedException)
            {
                // The socket has been closed.
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (clientsocket != null)
                {
                    if (clientsocket.Connected)
                    {
                        clientsocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                        clientsocket.Disconnect(false);
                    }
                    clientsocket.Close();
                }
            }
        }

        protected override void Communication(System.Net.Sockets.Socket socket)
        {
            Player player = null;
            try
            {
                base.Communication(socket);
                if (Version.Major > 0)
                {
                    Version clientversion = new Version(1, 0);
                    System.DateTime until = System.DateTime.Now.AddMilliseconds(Game.UpdateInterval * 3);
                    while (Connected)
                    {
                        if (Socket.Available > 0)
                        {
                            until = System.DateTime.Now.AddMilliseconds(Game.UpdateInterval * 3);
                            switch (ReceiveCommand())
                            {
                                case Commands.NewNetworkPlayer:
                                    byte major = ReceiveByte();
                                    byte minor = ReceiveByte();
                                    clientversion = new Version(major, minor);
                                    player = (Player) Game.ServerCommunication(clientversion, this, true, player);
                                    if (OnPlayerConnectedEvent != null)
                                    {
                                        System.Object[] objs = new System.Object[1];
                                        objs.SetValue(player, 0);
                                        Synchronize.Invoke(OnPlayerConnectedEvent, objs);
                                    }
                                    if (Game.UpdatePlayerInformationsEvent != null)
                                        Synchronize.Invoke(Game.UpdatePlayerInformationsEvent, null);
                                    break;
                                case Commands.UpdateGameInformations:
                                    player = (Player) Game.ServerCommunication(clientversion, this, false, player);
                                    if (Game.UpdatePlayerInformationsEvent != null)
                                        Synchronize.Invoke(Game.UpdatePlayerInformationsEvent, null);
                                    break;
                                case Commands.DisconnectPlayer:
                                    Socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                                    Socket.Disconnect(false);
                                    Socket.Close();
                                    break;
                                case Commands.BuyStocks:
                                    Game.ClientBuyingStocks(clientversion, this, ReceiveString(), player);
                                    if (Game.UpdateStockInformationsEvent != null)
                                        Synchronize.Invoke(Game.UpdateStockInformationsEvent, null);
                                    if (Game.UpdatePlayerInformationsEvent != null)
                                        Synchronize.Invoke(Game.UpdatePlayerInformationsEvent, null);
                                    break;
                                case Commands.SellStocks:
                                    Game.ClientSellingStocks(clientversion, this, ReceiveString(), player);
                                    if (Game.UpdateStockInformationsEvent != null)
                                        Synchronize.Invoke(Game.UpdateStockInformationsEvent, null);
                                    if (Game.UpdatePlayerInformationsEvent != null)
                                        Synchronize.Invoke(Game.UpdatePlayerInformationsEvent, null);
                                    break;
                            }
                        }
                        else if (System.DateTime.Now > until)
                        {
                            Socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                            Socket.Disconnect(false);
                            Socket.Close();
                        }
                        System.Threading.Thread.Sleep(250);
                    }
                }
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                switch (ex.SocketErrorCode)
                {
                    case System.Net.Sockets.SocketError.ConnectionAborted:
                        // Don't throw an excetion, the connection has just aborted.
                        break;
                    default:
                        throw ex;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (OnPlayerDisconnectedEvent != null)
                {
                    System.Object[] objs = new System.Object[1];
                    objs.SetValue(player, 0);
                    Synchronize.Invoke(OnPlayerDisconnectedEvent, objs);
                }
                Game.RemovePlayer(player);
                if (Game.UpdatePlayerInformationsEvent != null)
                    Synchronize.Invoke(Game.UpdatePlayerInformationsEvent, null);
            }
        }
    }
}
