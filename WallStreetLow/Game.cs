using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Game : System.Object, IDisposable, IResetable, IPlayable, IStoreable, INetworkable
    {
        private const string SETUP_FILENAME = "WallStreetGame.xml";
        private const byte FILEVERSION_MAJOR = 1;
        private const byte FILEVERSION_MINOR = 0;
        private const int PLAY_TIMER_INTERVAL = 30000;

        private System.Random _Random = null;
        private Version _FileVersion = null;
        private string _FileName = null;
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
        public delegate void BeforeSave();
        public delegate void AfterSave();
        public delegate void BeforeLoad();
        public delegate void AfterLoad();
        public delegate void OnPause();
        public delegate void OnContinue();
        public delegate void UpdateStockInformations();
        public delegate void UpdatePlayerInformations();

        private event BeforeReset _BeforeResetEvent = null;
        private event AfterReset _AfterResetEvent = null;
        private event BeforeSave _BeforeSaveEvent = null;
        private event AfterSave _AfterSaveEvent = null;
        private event BeforeLoad _BeforeLoadEvent = null;
        private event AfterLoad _AfterLoadEvent = null;
        private event OnPause _OnPauseEvent = null;
        private event OnContinue _OnContinueEvent = null;
        private event UpdateStockInformations _UpdateStockInformationsEvent = null;
        private event UpdatePlayerInformations _UpdatePlayerInformationsEvent = null;

        public Game(System.ComponentModel.ISynchronizeInvoke si) : this(si, AssemblyPath + SETUP_FILENAME)
        {
        }

        public Game(System.ComponentModel.ISynchronizeInvoke si, string setupfilename) : base()
        {
            try
            {
                Random = new System.Random();
                FileVersion = new Version(FILEVERSION_MAJOR, FILEVERSION_MINOR);
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

        private static string AssemblyPath
        {
            get
            {
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                if (path.LastIndexOf('\\') >= 0)
                {
                    path = path.Substring(0, path.LastIndexOf('\\') + 1);
                    return path;
                }
                return string.Empty;
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

        private Version FileVersion
        {
            get
            {
                return _FileVersion;
            }
            set
            {
                _FileVersion = value;
            }
        }

        public string FileName
        {
            get
            {
                if (_FileName != null)
                    return _FileName;
                return string.Empty;
            }
            private set
            {
                _FileName = value;
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

        public bool IsPaused
        {
            get
            {
                return PlayTimer.Enabled == false;
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

        public BeforeSave BeforeSaveEvent
        {
            get
            {
                return _BeforeSaveEvent;
            }
            set
            {
                _BeforeSaveEvent = value;
            }
        }

        public AfterSave AfterSaveEvent
        {
            get
            {
                return _AfterSaveEvent;
            }
            set
            {
                _AfterSaveEvent = value;
            }
        }

        public BeforeLoad BeforeLoadEvent
        {
            get
            {
                return _BeforeLoadEvent;
            }
            set
            {
                _BeforeLoadEvent = value;
            }
        }

        public AfterLoad AfterLoadEvent
        {
            get
            {
                return _AfterLoadEvent;
            }
            set
            {
                _AfterLoadEvent = value;
            }
        }

        public OnPause OnPauseEvent
        {
            get
            {
                return _OnPauseEvent;
            }
            set
            {
                _OnPauseEvent = value;
            }
        }

        public OnContinue OnContinueEvent
        {
            get
            {
                return _OnContinueEvent;
            }
            set
            {
                _OnContinueEvent = value;
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
                        if (BeforeLoadEvent != null)
                            BeforeLoadEvent = null;
                        if (AfterLoadEvent != null)
                            AfterLoadEvent = null;
                        if (BeforeSaveEvent != null)
                            BeforeSaveEvent = null;
                        if (AfterSaveEvent != null)
                            AfterSaveEvent = null;
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
                Reset(random, false);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Reset(System.Random random, bool startingserver)
        {
            try
            {
                bool b = true;
                if (BeforeResetEvent != null && !startingserver)
                    b = BeforeResetEvent();
                if (b)
                {
                    while (PlayTimer.Enabled)
                        PlayTimer.Stop();
                    FileName = null;
                    Stocks.Reset(random);
                    Players.Reset(random);
                    MarketState.Reset(random);
                    while (!PlayTimer.Enabled)
                        PlayTimer.Start();
                    if (AfterResetEvent != null && !startingserver)
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
                Players.Play(marketstate, random);
                Stocks.Play(marketstate, random);
                MarketState.Play(marketstate, random);
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

        public void Save()
        {
            try
            {
                if (FileName == String.Empty)
                    throw new System.NotSupportedException();
                Save(FileName);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Save(string filename)
        {
            try
            {
                WsgFileStream fs = null;
                try
                {
                    fs = new WsgFileStream(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None);
                    Save(FileVersion, fs);
                    fs.Close();
                }
                catch (System.Exception ex)
                {
                    if (fs != null)
                        fs.Close();
                    throw ex;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Save(Version fv, WsgFileStream fs)
        {
            try
            {
                if (BeforeSaveEvent != null)
                    BeforeSaveEvent();
                if (fv.Major > 0)
                {
                    while (PlayTimer.Enabled)
                        PlayTimer.Stop();
                    fs.Seek(0, System.IO.SeekOrigin.Begin);
                    FileVersion.Save(fv, fs);
                    StockIndexes.Save(fv, fs);
                    Stocks.Save(fv, fs);
                    Players.Save(fv, fs);
                    MarketState.Save(fv, fs);
                    fs.Flush();
                    FileName = fs.Name;
                    while (!PlayTimer.Enabled)
                        PlayTimer.Start();
                }
                if (AfterSaveEvent != null)
                    AfterSaveEvent();
                if (UpdateStockInformationsEvent != null)
                    UpdateStockInformationsEvent();
                if (UpdatePlayerInformationsEvent != null)
                    UpdatePlayerInformationsEvent();
            }
            catch (System.Exception ex)
            {
                while (!PlayTimer.Enabled)
                    PlayTimer.Start();
                throw ex;
            }
        }

        public void Load(string filename)
        {
            try
            {
                WsgFileStream fs = null;
                try
                {
                    fs = new WsgFileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None);
                    Load(FileVersion, fs, null);
                    fs.Close();
                }
                catch (VersionNotSupportedException ex)
                {
                    if (fs != null)
                        fs.Close();
                    throw ex;
                }
                catch (System.Exception ex)
                {
                    if (fs != null)
                        fs.Close();
                    throw ex;
                }
            }
            catch (System.NotSupportedException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public System.Object Load(Version fv, WsgFileStream fs, System.Object obj)
        {
            try
            {
                if (BeforeLoadEvent != null)
                    BeforeLoadEvent();
                if (fv.Major > 0)
                {
                    while (PlayTimer.Enabled)
                        PlayTimer.Stop();
                    fs.Seek(0, System.IO.SeekOrigin.Begin);
                    Version loadedfv = (Version) FileVersion.Load(fv, fs, null);
                    while (StockIndexes.Count > 0)
                        StockIndexes.Clear();
                    while (Stocks.Count > 0)
                        Stocks.Clear();
                    while (Players.Count > 0)
                        Players.Clear();
                    MarketState.Reset(Random);
                    CurrentPlayer = null;
                    StockIndexes.Load(loadedfv, fs, null);
                    Stocks.Load(loadedfv, fs, StockIndexes);
                    CurrentPlayer = (Player) Players.Load(loadedfv, fs, Stocks);
                    MarketState.Load(loadedfv, fs, null);
                    FileName = fs.Name;
                    while (!PlayTimer.Enabled)
                        PlayTimer.Start();
                }
                if (AfterLoadEvent != null)
                    AfterLoadEvent();
                if (UpdateStockInformationsEvent != null)
                    UpdateStockInformationsEvent();
                if (UpdatePlayerInformationsEvent != null)
                    UpdatePlayerInformationsEvent();
                return this;
            }
            catch (VersionNotSupportedException ex)
            {
                while (!PlayTimer.Enabled)
                    PlayTimer.Start();
                throw ex;
            }
            catch (System.Exception ex)
            {
                while (!PlayTimer.Enabled)
                    PlayTimer.Start();
                throw ex;
            }
        }

        public void Pause()
        {
            try
            {
                if (!IsPaused)
                {
                    while (PlayTimer.Enabled)
                        PlayTimer.Stop();
                    if (OnPauseEvent != null)
                        OnPauseEvent();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Continue()
        {
            try
            {
                if (IsPaused)
                {
                    while (!PlayTimer.Enabled)
                        PlayTimer.Start();
                    if (OnContinueEvent != null)
                        OnContinueEvent();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public System.Object ClientCommunication(Version serverversion, ICommunicateable communicator, bool full, System.Object obj)
        {
            try
            {
                if (serverversion.Major > 0)
                {
                    if (full)
                    {
                        // Send information about the client.
                        communicator.SendString(CurrentPlayer.Company);
                        communicator.SendString(CurrentPlayer.Name);
                        // Clear and reset game informations.
                        while (PlayTimer.Enabled)
                            PlayTimer.Stop();
                        while (StockIndexes.Count > 0)
                            StockIndexes.Clear();
                        while (Stocks.Count > 0)
                            Stocks.Clear();
                        while (Players.Count > 0)
                            Players.Clear();
                        MarketState.Reset(Random);
                        CurrentPlayer = null;
                    }
                    // Receive new game informations.
                    StockIndexes.ClientCommunication(serverversion, communicator, full, null);
                    Stocks.ClientCommunication(serverversion, communicator, full, StockIndexes);
                    Players.ClientCommunication(serverversion, communicator, full, Stocks);
                }
                return this;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public System.Object ServerCommunication(Version serverversion, ICommunicateable communicator, bool full, System.Object obj)
        {
            try
            {
                Player player = (Player) obj;
                if (serverversion.Major > 0)
                {
                    if (full)
                    {
                        // Receive information about the new player.
                        string company = communicator.ReceiveString();
                        string name = communicator.ReceiveString();
                        // Create the new player.
                        player = new Player(company, name, Stocks, false, false);
                        Players.Add(player);
                    }
                    // Send game informations.
                    StockIndexes.ServerCommunication(serverversion, communicator, full, null);
                    Stocks.ServerCommunication(serverversion, communicator, full, StockIndexes);
                    Players.ServerCommunication(serverversion, communicator, full, player);
                }
                return player;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
