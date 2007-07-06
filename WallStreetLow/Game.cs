using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Game : System.Object, IDisposable, IResetable, IPlayable
    {
        private const string SETUP_FILENAME = "WallStreetGame.xml";
        private const int PLAY_TIMER_INTERVAL = 30000;

        private System.Random _Random = null;
        private StockIndexes _StockIndexes = null;
        private Stocks _Stocks = null;
        private Players _Players = null;
        private Configuration _Configuration = null;
        private MarketState _MarketState = null;
        private Player _CurrentPlayer = null;
        private System.Timers.Timer _PlayTimer = null;

        #region IDisposable variables
        private bool _Disposed = false;
        #endregion

        public delegate bool BeforeReset();
        public delegate void AfterReset();
        public delegate void UpdateStockInformations();
        public delegate void UpdatePlayerInformations();

        private event BeforeReset _BeforeResetEvent = null;
        private event AfterReset _AfterResetEvent = null;
        private event UpdateStockInformations _UpdateStockInformationsEvent = null;
        private event UpdatePlayerInformations _UpdatePlayerInformationsEvent = null;

        public Game(System.ComponentModel.ISynchronizeInvoke si) : this(si, SETUP_FILENAME)
        {
        }

        public Game(System.ComponentModel.ISynchronizeInvoke si, string setupfilename) : base()
        {
            try
            {
                Random = new System.Random();
                StockIndexes = new StockIndexes();
                Stocks = new Stocks();
                Players = new Players();
                Configuration = new Configuration(setupfilename, Random, StockIndexes, Stocks, Players);
                if (StockIndexes == null)
                    StockIndexes = Configuration.StockIndexes;
                if (Stocks == null)
                    Stocks = Configuration.Stocks;
                if (Players == null)
                    Players = Configuration.Players;
                MarketState = new MarketState();
                CurrentPlayer = new Player(String.Empty, String.Empty, Stocks, false, true);
                Players.Add(CurrentPlayer);
                PlayTimer = new System.Timers.Timer(PLAY_TIMER_INTERVAL);
                PlayTimer.AutoReset = true;
                PlayTimer.Elapsed += new System.Timers.ElapsedEventHandler(PlayTimerElapsed);
                PlayTimer.SynchronizingObject = si;
                while (!PlayTimer.Enabled)
                    PlayTimer.Start();
                Disposed = false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        ~Game()
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

        public System.Random Random
        {
            get
            {
                return _Random;
            }
            private set
            {
                _Random = value;
            }
        }

        public StockIndexes StockIndexes
        {
            get
            {
                return _StockIndexes;
            }
            private set
            {
                _StockIndexes = value;
            }
        }

        public Stocks Stocks
        {
            get
            {
                return _Stocks;
            }
            private set
            {
                _Stocks = value;
            }
        }

        public Players Players
        {
            get
            {
                return _Players;
            }
            private set
            {
                _Players = value;
            }
        }

        public Configuration Configuration
        {
            get
            {
                return _Configuration;
            }
            private set
            {
                _Configuration = value;
            }
        }

        public MarketState MarketState
        {
            get
            {
                return _MarketState;
            }
            private set
            {
                _MarketState = value;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return _CurrentPlayer;
            }
            private set
            {
                _CurrentPlayer = value;
            }
        }

        private System.Timers.Timer PlayTimer
        {
            get
            {
                return _PlayTimer;
            }
            set
            {
                _PlayTimer = value;
            }
        }

        public BeforeReset BeforeResetEvent
        {
            get
            {
                return _BeforeResetEvent;
            }
            set
            {
                _BeforeResetEvent = value;
            }
        }

        public AfterReset AfterResetEvent
        {
            get
            {
                return _AfterResetEvent;
            }
            set
            {
                _AfterResetEvent = value;
            }
        }

        public UpdateStockInformations UpdateStockInformationsEvent
        {
            get
            {
                return _UpdateStockInformationsEvent;
            }
            set
            {
                _UpdateStockInformationsEvent = value;
            }
        }

        public UpdatePlayerInformations UpdatePlayerInformationsEvent
        {
            get
            {
                return _UpdatePlayerInformationsEvent;
            }
            set
            {
                _UpdatePlayerInformationsEvent = value;
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
                    if (PlayTimer != null)
                    {
                        while (PlayTimer.Enabled)
                            PlayTimer.Stop();
                    }
                    if (disposing)
                    {
                        if (Random != null)
                            Random = null;
                        if (StockIndexes != null)
                        {
                            while (StockIndexes.Count > 0)
                                StockIndexes.Clear();
                            StockIndexes = null;
                        }
                        if (Stocks != null)
                        {
                            while (Stocks.Count > 0)
                                Stocks.Clear();
                            Stocks = null;
                        }
                        if (Players != null)
                        {
                            while (Players.Count > 0)
                                Players.Clear();
                            Players = null;
                        }
                        if (MarketState != null)
                            MarketState = null;
                        if (CurrentPlayer != null)
                            CurrentPlayer = null;
                        if (PlayTimer != null)
                            PlayTimer.Dispose();
                        if (BeforeResetEvent != null)
                            BeforeResetEvent = null;
                        if (AfterResetEvent != null)
                            AfterResetEvent = null;
                        if (UpdateStockInformationsEvent != null)
                            UpdateStockInformationsEvent = null;
                        if (UpdatePlayerInformationsEvent != null)
                            UpdatePlayerInformationsEvent = null;
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

        private void PlayTimerElapsed(System.Object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                Play();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Reset()
        {
            try
            {
                Reset(Random);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Reset(System.Random random)
        {
            try
            {
                bool b = true;
                if (BeforeResetEvent != null)
                    b = BeforeResetEvent();
                if (b)
                {
                    while (PlayTimer.Enabled)
                        PlayTimer.Stop();
                    Stocks.Reset(random);
                    Players.Reset(random);
                    MarketState.Reset(random);
                    if (AfterResetEvent != null)
                        AfterResetEvent();
                    while (!PlayTimer.Enabled)
                        PlayTimer.Start();
                    if (UpdateStockInformationsEvent != null)
                        UpdateStockInformationsEvent();
                    if (UpdatePlayerInformationsEvent != null)
                        UpdatePlayerInformationsEvent();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Play()
        {
            try
            {
                Play(MarketState, Random);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Play(MarketState marketstate, System.Random random)
        {
            try
            {
                if (UpdateStockInformationsEvent != null)
                    UpdateStockInformationsEvent();
                if (UpdatePlayerInformationsEvent != null)
                    UpdatePlayerInformationsEvent();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
