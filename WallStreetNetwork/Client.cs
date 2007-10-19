using System;
using System.Collections.Generic;
using System.Text;
using OSDevGrp.WallStreetGame;

namespace OSDevGrp.WallStreetGame
{
    public class Client : Communicator, IDisposable
    {
        private const byte CLIENTVERSION_MAJOR = 1;
        private const byte CLIENTVERSION_MINOR = 0;

        private int _WaitForServers = 0;
        private System.Threading.ManualResetEvent _ManuelResetEvent = null;
        private ServerInformation _SelectedServer = null;

        #region IDisposable variables
        private bool _Disposed = false;
        #endregion

        public delegate bool BeforeConnect();
        public delegate void AfterConnect();
        public delegate bool BeforeDisconnect();
        public delegate void AfterDisconnect();
        public delegate ServerInformation SelectServer(ServerInformations serverinformations);
        public delegate void OnPlayerConnected(Player player);
        public delegate void OnPlayerDisconnected(Player player);

        private event BeforeConnect _BeforeConnectEvent = null;
        private event AfterConnect _AfterConnectEvent = null;
        private event BeforeDisconnect _BeforeDisconnectEvent = null;
        private event AfterDisconnect _AfterDisconnectEvent = null;
        private event SelectServer _SelectServerEvent = null;
        private event OnPlayerConnected _OnPlayerConnectedEvent = null;
        private event OnPlayerDisconnected _OnPlayerDisconnectEvent = null;

        public Client(Game game, System.ComponentModel.ISynchronizeInvoke synchronize) : base(game, new Version(CLIENTVERSION_MAJOR, CLIENTVERSION_MINOR), synchronize)
        {
            try
            {
                string s = System.Configuration.ConfigurationManager.AppSettings["Network.Port"];
                if (s == null)
                    throw new System.Configuration.ConfigurationErrorsException("No key named 'Network.Port' in the application configuration.");
                Port = int.Parse(s);
                s = System.Configuration.ConfigurationManager.AppSettings["Network.WaitForServers"];
                if (s == null)
                    throw new System.Configuration.ConfigurationErrorsException("No key named 'Network.WaitForServers' in the application configuration.");
                WaitForServers = int.Parse(s);
                ManuelResetEvent = new System.Threading.ManualResetEvent(true);
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

        private int WaitForServers
        {
            get
            {
                return _WaitForServers;
            }
            set
            {
                _WaitForServers = value;
            }
        }

        private System.Threading.ManualResetEvent ManuelResetEvent
        {
            get
            {
                return _ManuelResetEvent;
            }
            set
            {
                _ManuelResetEvent = value;
            }
        }

        private ServerInformation SelectedServer
        {
            get
            {
                return _SelectedServer;
            }
            set
            {
                _SelectedServer = value;
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

        public SelectServer SelectServerEvent
        {
            get
            {
                return _SelectServerEvent;
            }
            set
            {
                _SelectServerEvent = value;
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
                return _OnPlayerDisconnectEvent;
            }
            set
            {
                _OnPlayerDisconnectEvent = value;
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
                        if (OnPlayerDisconnectedEvent != null)
                            OnPlayerDisconnectedEvent = null;
                        Game.UpdateStockInformations usi = Game.UpdateStockInformationsEvent;
                        Game.UpdateStockInformationsEvent = null;
                        Game.UpdatePlayerInformations upi = Game.UpdatePlayerInformationsEvent;
                        Game.UpdatePlayerInformationsEvent = null;
                        Disconnect();
                        Game.UpdateStockInformationsEvent = usi;
                        Game.UpdatePlayerInformationsEvent = upi;
                    }
                    if (ManuelResetEvent != null)
                        ManuelResetEvent.Close();
                    if (disposing)
                    {
                        if (Game != null)
                            Game = null;
                        if (Version != null)
                            Version = null;
                        if (ManuelResetEvent != null)
                            ManuelResetEvent = null;
                        if (BeforeConnectEvent != null)
                            BeforeConnectEvent = null;
                        if (AfterConnectEvent != null)
                            AfterConnectEvent = null;
                        if (BeforeDisconnectEvent != null)
                            BeforeDisconnectEvent = null;
                        if (AfterDisconnectEvent != null)
                            AfterDisconnectEvent = null;
                        if (SelectServerEvent != null)
                            SelectServerEvent = null;
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

        private System.Net.IPAddress GetBroadcastAddress(System.Net.IPAddress address)
        {
            try
            {
                if (!address.Equals(System.Net.IPAddress.Loopback))
                {
                    byte[] b = address.GetAddressBytes();
                    b[b.Length - 1] = 255;
                    for (int i = 0; i < b.Length; i++)
                        b[i] = (byte) (b[i] & 0xFF);
                    return new System.Net.IPAddress(b);
                }
                return address;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private System.Net.Sockets.Socket CreateBroadcastSocket(System.Net.IPAddress ipaddress)
        {
            try
            {
                System.Net.Sockets.Socket socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp);
                socket.EnableBroadcast = true;
                socket.SetSocketOption(System.Net.Sockets.SocketOptionLevel.Socket, System.Net.Sockets.SocketOptionName.ReuseAddress, 1);
                socket.SetSocketOption(System.Net.Sockets.SocketOptionLevel.Socket, System.Net.Sockets.SocketOptionName.Broadcast, 1);
                socket.Bind(new System.Net.IPEndPoint(ipaddress, 0));
                return socket;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private ServerInformations GetServerInformations()
        {
            try
            {
                ServerInformations si = new ServerInformations();
                if (Version.Major > 0)
                {
                    System.Collections.Generic.List<System.Net.Sockets.Socket> sockets = new System.Collections.Generic.List<System.Net.Sockets.Socket>();
                    try
                    {
                        // Initialize and bind sockets.
                        bool containsloopback = false;
                        foreach (System.Net.IPAddress ipaddress in System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName()))
                        {
                            sockets.Add(CreateBroadcastSocket(ipaddress));
                            if (ipaddress.Equals(System.Net.IPAddress.Loopback))
                                containsloopback = true;
                        }
                        if (!containsloopback)
                            sockets.Add(CreateBroadcastSocket(System.Net.IPAddress.Loopback));
                        if (sockets.Count > 0)
                        {
                            // Broadcast client information on each socket
                            bool broadcasted = false;
                            foreach (System.Net.Sockets.Socket socket in sockets)
                            {
                                try
                                {
                                    string clientinformation = Commands.GetServerInformations.ToString("d") + '|' + Version.Major.ToString() + '|' + Version.Minor.ToString() + '|';
                                    socket.SendTo(System.Text.Encoding.Unicode.GetBytes(clientinformation), System.Net.Sockets.SocketFlags.None, new System.Net.IPEndPoint(GetBroadcastAddress(((System.Net.IPEndPoint) socket.LocalEndPoint).Address), Port));
                                    if (!broadcasted)
                                    {
                                        socket.SendTo(System.Text.Encoding.Unicode.GetBytes(clientinformation), System.Net.Sockets.SocketFlags.None, new System.Net.IPEndPoint(System.Net.IPAddress.Broadcast, Port));
                                        broadcasted = true;
                                    }
                                }
                                catch (System.Net.Sockets.SocketException ex)
                                {
                                    switch (ex.SocketErrorCode)
                                    {
                                        case System.Net.Sockets.SocketError.HostUnreachable:
                                            // Nothing to do.
                                            break;
                                        default:
                                            throw ex;
                                    }
                                }
                                catch (System.Exception ex)
                                {
                                    throw ex;
                                }
                            }
                            // Receive server informations.
                            int timetowait = WaitForServers;
                            while (timetowait > 0)
                            {
                                System.Threading.Thread.Sleep(250);
                                timetowait -= 250;
                                System.Collections.Generic.List<System.Net.Sockets.Socket> listenersockets = new System.Collections.Generic.List<System.Net.Sockets.Socket>(sockets.Count);
                                listenersockets.AddRange(sockets);
                                System.Net.Sockets.Socket.Select(listenersockets, null, null, 1000);
                                if (listenersockets.Count > 0)
                                {
                                    foreach (System.Net.Sockets.Socket listenersocket in listenersockets)
                                    {
                                        while (listenersocket.Available > 0)
                                        {
                                            try
                                            {
                                                byte[] buffer = new byte[listenersocket.Available];
                                                System.Net.EndPoint server = (System.Net.EndPoint) new System.Net.IPEndPoint(System.Net.IPAddress.None, 0);
                                                if (listenersocket.ReceiveFrom(buffer, ref server) > 0)
                                                {
                                                    string[] serverinformations = System.Text.Encoding.Unicode.GetString(buffer).Split('|');
                                                    if (serverinformations.Length >= 3)
                                                    {
                                                        bool found = false;
                                                        for (int i = 0; i < si.Count && !found; i++)
                                                            found = (si[i].Information == serverinformations[0]);
                                                        if (!found)
                                                            si.Add(new ServerInformation(serverinformations[0], new Version(byte.Parse(serverinformations[1]), byte.Parse(serverinformations[2])), server));
                                                    }
                                                }
                                            }
                                            catch (System.Net.Sockets.SocketException ex)
                                            {
                                                switch (ex.SocketErrorCode)
                                                {
                                                    case System.Net.Sockets.SocketError.ConnectionReset:
                                                        // Nothing to do.
                                                        break;
                                                    default:
                                                        throw ex;
                                                }
                                            }
                                            catch (System.Exception ex)
                                            {
                                                throw ex;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (sockets.Count > 0)
                        {
                            foreach (System.Net.Sockets.Socket socket in sockets)
                            {
                                if (socket.Connected)
                                {
                                    socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                                    socket.Disconnect(false);
                                }
                                socket.Close();
                            }
                        }
                    }
                }
                if (si.Count == 0)
                    throw new System.Net.Sockets.SocketException((int) System.Net.Sockets.SocketError.HostUnreachable);
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
                        SelectedServer = si[0];
                        if (SelectServerEvent != null)
                            SelectedServer = SelectServerEvent(si);
                        if (SelectedServer != null)
                        {
                            System.Net.Sockets.Socket socket = null;
                            try
                            {
                                ManuelResetEvent.Reset();
                                socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
                                System.IAsyncResult ar = socket.BeginConnect(SelectedServer.EndPoint, new System.AsyncCallback(this.ClientConnectCallback), socket);
                                ManuelResetEvent.WaitOne();
                            }
                            catch (System.Exception ex)
                            {
                                if (socket != null)
                                {
                                    if (socket.Connected)
                                        socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                                    socket.Close();
                                }
                                throw ex;
                            }
                        }
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
                        if (Socket != null)
                        {
                            SendCommand(Commands.DisconnectPlayer);
                            Socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                            Socket.Disconnect(false);
                            Socket.Close();
                            Socket = null;
                        }
                        if (SelectedServer != null)
                            SelectedServer = null;
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

        private void ClientConnectCallback(System.IAsyncResult ar)
        {
            System.Net.Sockets.Socket clientsocket = (System.Net.Sockets.Socket) ar.AsyncState;
            bool disconnecting = false;
            try
            {
                clientsocket.EndConnect(ar);
                StartCommunication(clientsocket);
                ManuelResetEvent.Set();
                Communication(clientsocket);
            }
            catch (System.ObjectDisposedException)
            {
                // The socket has been closed.
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                switch (ex.SocketErrorCode)
                {
                    case System.Net.Sockets.SocketError.ConnectionAborted:
                        // Don't throw an excetion, the connection has just aborted.
                        disconnecting = true;
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
                if (clientsocket.Connected)
                {
                    clientsocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                    clientsocket.Disconnect(false);
                }
                clientsocket.Close();
                if (disconnecting)
                {
                    if (Socket != null)
                        Socket = null;
                    if (SelectedServer != null)
                        SelectedServer = null;
                    if (AfterDisconnectEvent != null)
                        Synchronize.Invoke(AfterDisconnectEvent, null);
                    if (Game.UpdateStockInformationsEvent != null)
                        Synchronize.Invoke(Game.UpdateStockInformationsEvent, null);
                    if (Game.UpdatePlayerInformationsEvent != null)
                        Synchronize.Invoke(Game.UpdatePlayerInformationsEvent, null);
                }
            }
        }

        protected void StartCommunication(System.Net.Sockets.Socket socket)
        {
            try
            {
                base.Communication(socket);
                if (SelectedServer.Version.Major > 0)
                {
                    SendCommand(Commands.NewNetworkPlayer);
                    SendByte(Version.Major);
                    SendByte(Version.Minor);
                    Game.ClientCommunication(SelectedServer.Version, this, true, null);
                }
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected override void Communication(System.Net.Sockets.Socket socket)
        {
            try
            {
                base.Communication(socket);
                if (SelectedServer.Version.Major > 0)
                {
                    while (Connected)
                    {
                        System.DateTime wait = DateTime.Now.AddMilliseconds(Game.UpdateInterval);
                        while (Connected && System.DateTime.Now <= wait)
                        {
                            System.Threading.Thread.Sleep(250);
                        }
                        if (Connected)
                        {
                            SendCommand(Commands.UpdateGameInformations);
                            Game.ClientCommunication(SelectedServer.Version, this, false, null);
                            if (Game.Players.NewPlayers.Count > 0)
                            {
                                foreach (Player p in Game.Players.NewPlayers)
                                {
                                    if (OnPlayerConnectedEvent != null)
                                    {
                                        System.Object[] objs = new System.Object[1];
                                        objs.SetValue(p, 0);
                                        Synchronize.Invoke(OnPlayerConnectedEvent, objs);
                                    }
                                }
                            }
                            if (Game.Players.DisconnectedPlayers.Count > 0)
                            {
                                foreach (Player p in Game.Players.DisconnectedPlayers)
                                {
                                    if (OnPlayerDisconnectedEvent != null)
                                    {
                                        System.Object[] objs = new System.Object[1];
                                        objs.SetValue(p, 0);
                                        Synchronize.Invoke(OnPlayerDisconnectedEvent, objs);
                                    }
                                    Game.RemovePlayer(p);
                                }
                            }
                            if (Game.UpdateStockInformationsEvent != null)
                                Synchronize.Invoke(Game.UpdateStockInformationsEvent, null);
                            if (Game.UpdatePlayerInformationsEvent != null)
                                Synchronize.Invoke(Game.UpdatePlayerInformationsEvent, null);
                        }
                    }
                }
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
