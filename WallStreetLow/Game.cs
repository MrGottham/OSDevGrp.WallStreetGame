using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Game : System.Object, IResetable
    {
        private const string SETUP_FILENAME = "WallStreetGame.xml";

        private StockIndexes _StockIndexes = null;
        private Stocks _Stocks = null;
        private Players _Players = null;
        private Configuration _Configuration = null;
        private Player _CurrentPlayer = null;

        public delegate bool BeforeReset();
        public delegate void AfterReset();
        public delegate void UpdateStockInformations();
        public delegate void UpdatePlayerInformations();

        private event BeforeReset _BeforeResetEvent = null;
        private event AfterReset _AfterResetEvent = null;
        private event UpdateStockInformations _UpdateStockInformationsEvent = null;
        private event UpdatePlayerInformations _UpdatePlayerInformationsEvent = null;

        public Game() : this(SETUP_FILENAME)
        {
        }

        public Game(string setupfilename) : base()
        {
            try
            {
                StockIndexes = new StockIndexes();
                Stocks = new Stocks();
                Players = new Players();
                Configuration = new Configuration(setupfilename, StockIndexes, Stocks, Players);
                if (StockIndexes == null)
                    StockIndexes = Configuration.StockIndexes;
                if (Stocks == null)
                    Stocks = Configuration.Stocks;
                if (Players == null)
                    Players = Configuration.Players;
                CurrentPlayer = new Player(String.Empty, String.Empty, Stocks, false, true);
                Players.Add(CurrentPlayer);
            }
            catch (System.Exception ex)
            {
                throw ex;
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

        public void Reset()
        {
            try
            {
                bool b = true;
                if (BeforeResetEvent != null)
                    b = BeforeResetEvent();
                if (b)
                {
                    Stocks.Reset();
                    Players.Reset();
                    if (AfterResetEvent != null)
                        AfterResetEvent();
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
    }
}
