using System;
using System.Collections.Generic;
using System.Text;
using OSDevGrp.WallStreetGame;

namespace OSDevGrp.WallStreetGame
{
    public class Server : System.Object, IDisposable
    {
        private Game _Game = null;
        private bool _Running = false;
        private System.Threading.Thread _UPDListener = null;

        #region IDisposable variables
        private bool _Disposed = false;
        #endregion

        public delegate bool BeforeStart();
        public delegate void AfterStart();
        public delegate bool BeforeStop();
        public delegate void AfterStop();

        private event BeforeStart _BeforeStartEvent = null;
        private event AfterStart _AfterStartEvent = null;
        private event BeforeStop _BeforeStopEvent = null;
        private event AfterStop _AfterStopEvent = null;

        public Server(Game game) : base()
        {
            try
            {
                Game = game;
                UPDListener = new System.Threading.Thread(new System.Threading.ThreadStart(this.UPDListenerThread));
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

        private System.Threading.Thread UPDListener
        {
            get
            {
                return _UPDListener;
            }
            set
            {
                _UPDListener = value;
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
                        if (UPDListener != null)
                            UPDListener = null;
                        if (BeforeStartEvent != null)
                            BeforeStartEvent = null;
                        if (AfterStartEvent != null)
                            AfterStartEvent = null;
                        if (BeforeStopEvent != null)
                            BeforeStopEvent = null;
                        if (AfterStopEvent != null)
                            AfterStopEvent = null;
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
                        UPDListener.Start();
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
                        if (UPDListener.IsAlive)
                        {
                            UPDListener.Suspend();
                            while (UPDListener.IsAlive)
                            {
                                // Nothing to do.
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

        private void UPDListenerThread()
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
