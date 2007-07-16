using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Stock : System.Object, IResetable, IPlayable, IStoreable
    {
        private const double MIN_PRICE = 2.50D;
        private const double MAX_PRICE = 250000.00D;
        private const int MAX_INITIALIZE_PRICE = 1000;
        private const int MIN_AVAILABLE = 0;
        private const int MAX_AVAILABLE = 250000;

        private string _Id = null;
        private string _Name = null;
        private StockIndexes _StockIndexes = null;
        private DoubleHistory _PriceHistory = null;
        private double _Price = MIN_PRICE;
        private int _Available = MIN_AVAILABLE;
        private int _OwnedByPlayers = 0;

        public Stock(string id, string name, StockIndex stockindex, System.Random random) : base()
        {
            try
            {
                Id = id;
                Name = name;
                StockIndexes = new StockIndexes();
                PriceHistory = new DoubleHistory();
                AddStockIndex(stockindex);
                Reset(random);
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
                    return (PriceDifference / PriceHistory[PriceHistory.Count - 2]) * 100;
                return 0D;
            }
        }

        public int Available
        {
            get
            {
                return _Available;
            }
            set
            {
                _Available = value;
                if (_Available < MIN_AVAILABLE)
                    _Available = MIN_AVAILABLE;
                if (_Available > MAX_AVAILABLE - OwnedByPlayers)
                    _Available = MAX_AVAILABLE - OwnedByPlayers;
            }
        }

        public int OwnedByPlayers
        {
            get
            {
                return _OwnedByPlayers;
            }
            set
            {
                _OwnedByPlayers = value;
                if (_OwnedByPlayers < MIN_AVAILABLE)
                    _OwnedByPlayers = MIN_AVAILABLE;
                if (_OwnedByPlayers > MAX_AVAILABLE)
                    _OwnedByPlayers = MAX_AVAILABLE;
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

        public double CalculatePrice(int count)
        {
            try
            {
                return count * Price;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public double CalculateBrokerage(MarketState marketstate, int count)
        {
            try
            {
                double brokerage = (CalculatePrice(count) * (marketstate.Brokerage / 100)) * 100;
                double d = brokerage % 100;
                if (d >= 0 && d < 26)
                {
                    brokerage = (brokerage - d + (d >= 13 ? 25 : 0)) / 100;
                }
                else if (d >= 26 && d < 51)
                {
                    brokerage = (brokerage - d + (d >= 38 ? 50 : 25)) / 100;
                }
                else if (d >= 51 && d < 75)
                {
                    brokerage = (brokerage - d + (d >= 63 ? 75 : 50)) / 100;
                }
                else if (d >= 75 && d < 100)
                {
                    brokerage = (brokerage - d + (d >= 88 ? 100 : 75)) / 100;
                }
                return brokerage;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Buy(Player player, MarketState marketstate, int stockstobuy)
        {
            try
            {
                player.Buy(this, marketstate, stockstobuy);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Sell(Player player, MarketState marketstate, int stockstosell)
        {
            try
            {
                player.Sell(this, marketstate, stockstosell);
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
                PriceHistory.Reset(random);
                if (random.Next(100) > 95)
                    Price = random.Next(MAX_INITIALIZE_PRICE * 5) + random.NextDouble();
                else
                    Price = random.Next(MAX_INITIALIZE_PRICE) + random.NextDouble();
                Available = random.Next(MAX_AVAILABLE);
                OwnedByPlayers = 0;
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
                double d_up = 0D, d_down = 0D;
                int i_up_down = 0;
                switch (marketstate.State)
                {
                    case MarketStateType.Normal:
                        d_up = (Price / 100) * 5;
                        d_down = (Price / 100) * 5;
                        i_up_down = (Available / 100) * 10;
                        break;
                    case MarketStateType.Depression:
                        d_up = (Price / 100) * 2.5;
                        d_down = (Price / 100) * 5;
                        i_up_down = (Available / 100) * 5;
                        break;
                    case MarketStateType.Boom:
                        d_up = (Price / 100) * 5;
                        d_down = (Price / 100) * 2.5;
                        i_up_down = (Available / 100) * 15;
                        break;
                }
                if (d_up <= MIN_PRICE)
                    d_up = MIN_PRICE;
                if (d_down <= MIN_PRICE)
                    d_down = MIN_PRICE;
                if (i_up_down <= 0)
                    i_up_down = MAX_AVAILABLE / 1000;
                Price += random.Next(d_up > int.MaxValue ? int.MaxValue : (int) d_up) - random.Next(d_down > int.MaxValue ? int.MaxValue : (int) d_down);
                Available += random.Next(i_up_down) - random.Next(i_up_down);
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
                if (fv.Major > 0)
                {
                }
                throw new System.NotImplementedException();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Load(Version fv, WsgFileStream fs)
        {
            try
            {
                if (fv.Major > 0)
                {
                }
                throw new System.NotImplementedException();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
