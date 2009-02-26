using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Stock : System.Object, IResetable, IPlayable, IStoreable, INetworkable
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
        private double _MinPrice = MIN_PRICE;
        private double _MaxPrice = MAX_PRICE;
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

        public Stock(Version fv, WsgFileStream fs, System.Object obj) : base()
        {
            try
            {
                StockIndexes = new StockIndexes();
                PriceHistory = new DoubleHistory();
                Load(fv, fs, obj);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public Stock(Version serverversion, ICommunicateable communicator, bool full, System.Object obj) : base()
        {
            try
            {
                StockIndexes = new StockIndexes();
                PriceHistory = new DoubleHistory();
                ClientCommunication(serverversion, communicator, full, obj);
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

        public double MinPrice
        {
            get
            {
                return _MinPrice;
            }
            private set
            {
                _MinPrice = value * 100;
                double d = _MinPrice % 100;
                if (d >= 0 && d < 26)
                {
                    _MinPrice = (_MinPrice - d + (d >= 13 ? 25 : 0)) / 100;
                }
                else if (d >= 26 && d < 51)
                {
                    _MinPrice = (_MinPrice - d + (d >= 38 ? 50 : 25)) / 100;
                }
                else if (d >= 51 && d < 75)
                {
                    _MinPrice = (_MinPrice - d + (d >= 63 ? 75 : 50)) / 100;
                }
                else if (d >= 75 && d < 100)
                {
                    _MinPrice = (_MinPrice - d + (d >= 88 ? 100 : 75)) / 100;
                }
                if (_MinPrice < MIN_PRICE)
                    _MinPrice = MIN_PRICE;
                if (_MinPrice > MAX_PRICE)
                    _MinPrice = MAX_PRICE;
                if (_MinPrice > MaxPrice)
                    _MinPrice = MaxPrice;
            }
        }

        public double MaxPrice
        {
            get
            {
                return _MaxPrice;
            }
            private set
            {
                _MaxPrice = value * 100;
                double d = _MaxPrice % 100;
                if (d >= 0 && d < 26)
                {
                    _MaxPrice = (_MaxPrice - d + (d >= 13 ? 25 : 0)) / 100;
                }
                else if (d >= 26 && d < 51)
                {
                    _MaxPrice = (_MaxPrice - d + (d >= 38 ? 50 : 25)) / 100;
                }
                else if (d >= 51 && d < 75)
                {
                    _MaxPrice = (_MaxPrice - d + (d >= 63 ? 75 : 50)) / 100;
                }
                else if (d >= 75 && d < 100)
                {
                    _MaxPrice = (_MaxPrice - d + (d >= 88 ? 100 : 75)) / 100;
                }
                if (_MaxPrice < MIN_PRICE)
                    _MaxPrice = MIN_PRICE;
                if (_MaxPrice > MAX_PRICE)
                    _MaxPrice = MAX_PRICE;
                if (_MaxPrice < MinPrice)
                    _MaxPrice = MinPrice;
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
                if (_Price < MinPrice)
                    _Price = MinPrice;
                if (_Price > MaxPrice)
                    _Price = MaxPrice;
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
                MinPrice = MIN_PRICE + (random.Next(1000) / 100);
                MaxPrice = MAX_PRICE - (random.Next(1000) / 100);
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
                int i_up_down = 0, i_min_adjust = 0, i_max_adjust = 0;
                switch (marketstate.State)
                {
                    case MarketStateType.Normal:
                        d_up = (Price / 100) * 7;
                        d_down = (Price / 100) * 7;
                        i_up_down = (Available / 100) * 10;
                        i_min_adjust = 1000;
                        i_max_adjust = 1000;
                        if (d_up <= MinPrice)
                            d_up = MinPrice;
                        if (d_down <= MinPrice)
                            d_down = MinPrice;
                        break;
                    case MarketStateType.Depression:
                        d_up = (Price / 100) * 3.5;
                        d_down = (Price / 100) * 7;
                        i_up_down = (Available / 100) * 5;
                        i_min_adjust = 1500;
                        i_max_adjust = 500;
                        if (d_up <= MinPrice)
                            d_up = MinPrice;
                        if (d_down <= MinPrice * 2)
                            d_down = MinPrice * 2;
                        break;
                    case MarketStateType.Boom:
                        d_up = (Price / 100) * 7;
                        d_down = (Price / 100) * 3.5;
                        i_up_down = (Available / 100) * 15;
                        i_min_adjust = 500;
                        i_max_adjust = 1500;
                        if (d_up <= MinPrice * 2)
                            d_up = MinPrice * 2;
                        if (d_down <= MinPrice)
                            d_down = MinPrice;
                        break;
                }
                if (i_up_down <= 0)
                    i_up_down = MAX_AVAILABLE / 1000;
                MinPrice += (random.Next(i_max_adjust) / 100) - (random.Next(i_min_adjust) / 100);
                MaxPrice += (random.Next(i_max_adjust) / 100) - (random.Next(i_min_adjust) / 100);
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
                    fs.WriteString(Id);
                    fs.WriteString(Name);
                    fs.WriteInt(StockIndexes.Count);
                    if (StockIndexes.Count > 0)
                    {
                        foreach (StockIndex stockindex in StockIndexes.Values)
                            fs.WriteString(stockindex.Id);
                    }
                    PriceHistory.Save(fv, fs);
                    if (fv.Major > 0 && fv.Minor >= 1)
                    {
                        fs.WriteDouble(MinPrice);
                        fs.WriteDouble(MaxPrice);
                    }
                    fs.WriteDouble(Price);
                    fs.WriteInt(Available);
                    fs.WriteInt(OwnedByPlayers);
                }
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
                if (fv.Major > 0)
                {
                    Id = fs.ReadString();
                    Name = fs.ReadString();
                    int c = fs.ReadInt();
                    if (c > 0)
                    {
                        StockIndexes stockindexes = (StockIndexes) obj;
                        for (int i = 0; i < c; i++)
                        {
                            string id = fs.ReadString();
                            StockIndex stockindex = null;
                            if (stockindexes.TryGetValue(id, out stockindex))
                            {
                                stockindex.Stocks.Add(Id, this);
                                StockIndexes.Add(stockindex.Id, stockindex);
                            }
                        }
                    }
                    PriceHistory.Load(fv, fs, obj);
                    if (fv.Major > 0 && fv.Minor >= 1)
                    {
                        MinPrice = fs.ReadDouble();
                        MaxPrice = fs.ReadDouble();
                    }
                    else
                    {
                        MinPrice = MIN_PRICE;
                        MaxPrice = MAX_PRICE;
                    }
                    Price = fs.ReadDouble();
                    if (PriceHistory.Count > 0)
                        PriceHistory.RemoveAt(PriceHistory.Count - 1);
                    Available = fs.ReadInt();
                    OwnedByPlayers = fs.ReadInt();
                }
                return this;
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
                        Id = communicator.ReceiveString();
                        Name = communicator.ReceiveString();
                        int c = communicator.ReceiveInt();
                        if (c > 0)
                        {
                            StockIndexes stockindexes = (StockIndexes) obj;
                            for (int i = 0; i < c; i++)
                            {
                                string id = communicator.ReceiveString();
                                StockIndex stockindex = null;
                                if (stockindexes.TryGetValue(id, out stockindex))
                                {
                                    stockindex.Stocks.Add(Id, this);
                                    StockIndexes.Add(stockindex.Id, stockindex);
                                }
                            }
                        }
                        PriceHistory.ClientCommunication(serverversion, communicator, full, obj);
                    }
                    if (serverversion.Major > 0 && serverversion.Minor >= 1)
                    {
                        MinPrice = communicator.ReceiveDouble();
                        MaxPrice = communicator.ReceiveDouble();
                    }
                    else
                    {
                        MinPrice = MIN_PRICE;
                        MaxPrice = MAX_PRICE;
                    }
                    Price = communicator.ReceiveDouble();
                    if (full && PriceHistory.Count > 0)
                        PriceHistory.RemoveAt(PriceHistory.Count - 1);
                    Available = communicator.ReceiveInt();
                    OwnedByPlayers = communicator.ReceiveInt();
                }
                return this;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public System.Object ServerCommunication(Version clientversion, ICommunicateable communicator, bool full, System.Object obj)
        {
            try
            {
                if (clientversion.Major > 0)
                {
                    if (full)
                    {
                        communicator.SendString(Id);
                        communicator.SendString(Name);
                        communicator.SendInt(StockIndexes.Count);
                        if (StockIndexes.Count > 0)
                        {
                            foreach (StockIndex stockindex in StockIndexes.Values)
                                communicator.SendString(stockindex.Id);
                        }
                        PriceHistory.ServerCommunication(clientversion, communicator, full, obj);
                    }
                    if (clientversion.Major > 0 && clientversion.Minor >= 1)
                    {
                        communicator.SendDouble(MinPrice);
                        communicator.SendDouble(MaxPrice);
                    }
                    communicator.SendDouble(Price);
                    communicator.SendInt(Available);
                    communicator.SendInt(OwnedByPlayers);
                }
                return this;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
