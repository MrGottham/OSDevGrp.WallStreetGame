using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public abstract class Communicator : System.Object, ICommunicateable
    {
        private Game _Game = null;
        private Version _Version = null;
        private System.ComponentModel.ISynchronizeInvoke _Synchronize = null;
        private int _Port = 0;
        private System.Net.Sockets.Socket _Socket = null;

        public Communicator(Game game, Version version, System.ComponentModel.ISynchronizeInvoke synchronize) : base()
        {
            try
            {
                Game = game;
                Version = version;
                Synchronize = synchronize;
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
            protected set
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
            protected set
            {
                _Version = value;
            }
        }

        protected System.ComponentModel.ISynchronizeInvoke Synchronize
        {
            get
            {
                return _Synchronize;
            }
            private set
            {
                _Synchronize = value;
            }
        }

        protected int Port
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

        protected System.Net.Sockets.Socket Socket
        {
            get
            {
                return _Socket;
            }
            set
            {
                _Socket = value;
            }
        }

        public bool Connected
        {
            get
            {
                if (Socket != null)
                    return Socket.Connected;
                return false;
            }
        }

        protected virtual void Communication(System.Net.Sockets.Socket socket)
        {
            try
            {
                Socket = socket;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public byte ReceiveByte()
        {
            try
            {
                byte[] buffer = new byte[1];
                if (Socket.Receive(buffer, buffer.Length, System.Net.Sockets.SocketFlags.None) < buffer.Length)
                    throw new System.Net.Sockets.SocketException((int) System.Net.Sockets.SocketError.IOPending);
                return buffer[0];
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public bool ReceiveBool()
        {
            try
            {
                byte[] buffer = new byte[sizeof(bool)];
                if (Socket.Receive(buffer, buffer.Length, System.Net.Sockets.SocketFlags.None) < buffer.Length)
                    throw new System.Net.Sockets.SocketException((int) System.Net.Sockets.SocketError.IOPending);
                return System.BitConverter.ToBoolean(buffer, 0);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public int ReceiveInt()
        {
            try
            {
                byte[] buffer = new byte[sizeof(System.Int32)];
                if (Socket.Receive(buffer, buffer.Length, System.Net.Sockets.SocketFlags.None) < buffer.Length)
                    throw new System.Net.Sockets.SocketException((int) System.Net.Sockets.SocketError.IOPending);
                return System.BitConverter.ToInt32(buffer, 0);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public double ReceiveDouble()
        {
            try
            {
                byte[] buffer = new byte[sizeof(double)];
                if (Socket.Receive(buffer, buffer.Length, System.Net.Sockets.SocketFlags.None) < buffer.Length)
                    throw new System.Net.Sockets.SocketException((int) System.Net.Sockets.SocketError.IOPending);
                return System.BitConverter.ToDouble(buffer, 0);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public string ReceiveString()
        {
            try
            {
                int bytes = ReceiveInt();
                if (bytes > 0)
                {
                    byte[] buffer = new byte[bytes];
                    if (Socket.Receive(buffer, buffer.Length, System.Net.Sockets.SocketFlags.None) < buffer.Length)
                        throw new System.Net.Sockets.SocketException((int) System.Net.Sockets.SocketError.IOPending);
                    return System.Text.Encoding.Unicode.GetString(buffer);
                }
                return string.Empty;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public Commands ReceiveCommand()
        {
            try
            {
                return (Commands) ReceiveInt();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void SendByte(byte b)
        {
            try
            {
                byte[] buffer = new byte[1];
                buffer[0] = b;
                if (Socket.Send(buffer) < buffer.Length)
                    throw new System.Net.Sockets.SocketException((int) System.Net.Sockets.SocketError.IOPending);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void SendBool(bool b)
        {
            try
            {
                if (Socket.Send(System.BitConverter.GetBytes(b)) < sizeof(bool))
                    throw new System.Net.Sockets.SocketException((int) System.Net.Sockets.SocketError.IOPending);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void SendInt(int i)
        {
            try
            {
                if (Socket.Send(System.BitConverter.GetBytes((System.Int32)i)) < sizeof(System.Int32))
                    throw new System.Net.Sockets.SocketException((int) System.Net.Sockets.SocketError.IOPending);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void SendDouble(double d)
        {
            try
            {
                if (Socket.Send(System.BitConverter.GetBytes(d)) < sizeof(double))
                    throw new System.Net.Sockets.SocketException((int) System.Net.Sockets.SocketError.IOPending);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void SendString(string s)
        {
            try
            {
                int bytes = System.Text.Encoding.Unicode.GetByteCount(s);
                SendInt(bytes);
                if (bytes > 0)
                {
                    if (Socket.Send(System.Text.Encoding.Unicode.GetBytes(s)) < bytes)
                        throw new System.Net.Sockets.SocketException((int) System.Net.Sockets.SocketError.IOPending);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void SendCommand(Commands command)
        {
            try
            {
                SendInt((int)command);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
