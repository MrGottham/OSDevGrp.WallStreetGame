using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Game : System.Object
    {
        private const string SETUP_FILENAME = "WallStreetGame.xml";

        private StockIndexes _StockIndexes = null;
        private Configuration _Configuration = null;

        public Game() : this(SETUP_FILENAME)
        {
        }

        public Game(string setupfilename) : base()
        {
            try
            {
                StockIndexes = new StockIndexes();
                Configuration = new Configuration(setupfilename, StockIndexes);
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
    }
}
