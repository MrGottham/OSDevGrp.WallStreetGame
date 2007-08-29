using System;
using System.Collections.Generic;
using System.Text;
using OSDevGrp.WallStreetGame;

namespace OSDevGrp.WallStreetGame
{
    public class Client : System.Object, IDisposable
    {
        private Game _Game = null;

        #region IDisposable variables
        private bool _Disposed = false;
        #endregion

        public Client(Game game) : base()
        {
            try
            {
                Game = game;
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

        public bool Connected
        {
            get
            {
                return false;
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
                        Disconnect();
                    }
                    if (disposing)
                    {
                        if (Game != null)
                            Game = null;
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

        public void Connect()
        {
            try
            {
                if (!Connected)
                {
                    throw new System.NotImplementedException();
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
                    throw new System.NotImplementedException();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
