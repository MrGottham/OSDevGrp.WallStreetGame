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

        public double PriceAverage
        {
            get
            {
                if (Stocks.Count > 0)
                {
                    double d = 0;
                    foreach(Stock stock in Stocks.Values)
                    {
                        if (d + stock.Price >= 0 && d + stock.Price <= double.MaxValue)
                            d += stock.Price;
                    }
                    return System.Math.Round(d / Stocks.Count, 2);
                }
                return 0D;
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
