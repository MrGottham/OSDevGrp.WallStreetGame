using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Stock : System.Object, IResetable
    {
        private const double MIN_PRICE = 2.50D;
        private const double MAX_PRICE = 250000.00D;
        private const int MAX_INITIALIZE_PRICE = 10000;
        private const int MIN_AVAILABLE = 0;
        private const int MAX_AVAILABLE = 2500000;

        private string _Id = null;
        private string _Name = null;
        private StockIndexes _StockIndexes = null;
        private DoubleHistory _PriceHistory = null;
        private double _Price = MIN_PRICE;
        private int _Available = MIN_AVAILABLE;

        public Stock(string id, string name, StockIndex stockindex) : base()
        {
            try
            {
                Id = id;
                Name = name;
                StockIndexes = new StockIndexes();
                PriceHistory = new DoubleHistory();
                AddStockIndex(stockindex);
                Reset();
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

        public DoubleHistory PriceHistory
        {
            get
            {
                return _PriceHistory;
            }
            private set
            {
                _PriceHistory = value;
            }
        }

        public double Price
        {
            get
            {
                return _Price;
            }
            private set
            {
                _Price = value * 100;
                double d = _Price % 100;
                if (d >= 0 && d < 26)
                {
                    _Price = (_Price - d + (d >= 13 ? 25 : 0)) / 100;
                }
                else if (d >= 26 && d < 51)
                {
                    _Price = (_Price - d + (d >= 38 ? 50 : 25)) / 100;
                }
                else if (d >= 51 && d < 75)
                {
                    _Price = (_Price - d + (d >= 63 ? 75 : 50)) / 100;
                }
                else if (d >= 75 && d < 100)
                {
                    _Price = (_Price - d + (d >= 88 ? 100 : 75)) / 100;
                }
                if (_Price < MIN_PRICE)
                    _Price = MIN_PRICE;
                if (_Price > MAX_PRICE)
                    _Price = MAX_PRICE;
                PriceHistory.AddHistory(_Price);
            }
        }

        public double PriceDifference
        {
            get
            {
                if (PriceHistory.Count > 1)
                    return Price - PriceHistory[PriceHistory.Count - 2];
                return 0D;
            }
        }

        public double PriceDifferenceProcent
        {
            get
            {
                if (PriceHistory.Count > 1)
                    return (PriceDifference * 100) / PriceHistory[PriceHistory.Count - 2];
                return 0D;
            }
        }

        public int Available
        {
            get
            {
                return _Available;
            }
            private set
            {
                _Available = value;
                if (_Available < MIN_AVAILABLE)
                    _Available = MIN_AVAILABLE;
                if (_Available > MAX_AVAILABLE)
                    _Available = MAX_AVAILABLE;
            }
        }

        public void AddStockIndex(StockIndex stockindex)
        {
            try
            {
                if (!StockIndexes.ContainsKey(stockindex.Id))
                {
                    StockIndexes.Add(stockindex.Id, stockindex);
                    if (!stockindex.Stocks.ContainsKey(this.Id))
                        stockindex.Stocks.Add(this.Id, this);
                }
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
                System.Threading.Thread.Sleep(1);
                System.Random r = new System.Random();
                while (PriceHistory.Count > 0)
                    PriceHistory.Clear();
                Price = r.Next(MAX_INITIALIZE_PRICE) + r.NextDouble();
                Available = r.Next(MAX_AVAILABLE);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
