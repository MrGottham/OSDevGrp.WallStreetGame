using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class StockIndex : System.Object
    {
        private string _Id = null;
        private string _Name = null;
        private Stocks _Stocks = null;

        public StockIndex(string id, string name) : base()
        {
            try
            {
                Id = id;
                Name = name;
                Stocks = new Stocks();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public string Id
        {
            get
            {
                if (_Id != null)
                    return _Id;
                return string.Empty;
            }
            private set
            {
                _Id = value;
            }
        }

        public string Name
        {
            get
            {
                if (_Name != null)
                    return _Name;
                return string.Empty;
            }
            private set
            {
                _Name = value;
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
    }
}
