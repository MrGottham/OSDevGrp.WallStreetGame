using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Player : System.Object, IComparable<Player>, IResetable, IPlayable, IStoreable, INetworkable
    {
        private const double CAPITAL_INITIALIZE = 100000D;
        private const int MAX_STOCKS_TO_BUY = 1000;
        private const int MAX_BUY_PR_EPOCH = 3;
        private const int MAX_SELL_PR_EPOCH = 3;

        private int _Id = 0;
        private string _Company = null;
        private string _Name = null;
        private bool _IsComputer = true;
        private bool _IsYou = false;
        private Deposit _Deposit = null;
        private DoubleHistory _ValueHistory = null;
        private double _Capital = CAPITAL_INITIALIZE;

        public Player(int id, string company, string name, Stocks stocks) : this(id, company, name, stocks, true, false)
        {
        }

        public Player(int id, string company, string name, Stocks stocks, bool iscomputer, bool isyou) : base()
        {
            try
            {
                Id = id;
                Company = company;
                Name = name;
                IsComputer = iscomputer;
                IsYou = isyou && !IsComputer;
                Deposit = new Deposit(this, stocks);
                ValueHistory = new DoubleHistory();
                Reset(null);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public Player(int id, Version fv, WsgFileStream fs, System.Object obj) : base()
        {
            try
            {
                Id = id;
                Deposit = new Deposit(this, (Stocks) obj);
                ValueHistory = new DoubleHistory();
                Load(fv, fs, obj);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public Player(int id, Version serverversion, ICommunicateable communicator, bool full, System.Object obj) : base()
        {
            try
            {
                Id = id;
                Deposit = new Deposit(this, (Stocks) obj);
                ValueHistory = new DoubleHistory();
                ClientCommunication(serverversion, communicator, full, obj);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #region IComparable<Player> Members
        public int CompareTo(Player other)
        {
            try
            {
                if (this != other)
                {
                    if (this.IsComputer && other.IsComputer)
                    {
                        if (this.Value > other.Value)
                            return -1;
                        else if (this.Value == other.Value)
                            return 0;
                        else
                            return 1;
                    }
                    else if (this.IsComputer && !other.IsComputer)
                    {
                        return -1;
                    }
                    else if (!this.IsComputer && other.IsComputer)
                    {
                        return 0;
                    }
                    else if (this.Value > other.Value)
                        return -1;
                    else if (this.Value == other.Value)
                        return 0;
                    else
                        return 1;
                }
                return 0;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public int Id
        {
            get
            {
                return _Id;
            }
            private set
            {
                _Id = value;
            }
        }

        public string Company
        {
            get
            {
                if (_Company != null)
                    return _Company;
                return String.Empty;
            }
            set
            {
                _Company = value;
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
            set
            {
                _Name = value;
            }
        }

        public bool IsComputer
        {
            get
            {
                return _IsComputer;
            }
            private set
            {
                _IsComputer = value;
            }
        }

        public bool IsYou
        {
            get
            {
                return _IsYou;
            }
            private set
            {
                _IsYou = value;
            }
        }

        public Deposit Deposit
        {
            get
            {
                return _Deposit;
            }
            private set
            {
                _Deposit = value;
            }
        }

        public DoubleHistory ValueHistory
        {
            get
            {
                return _ValueHistory;
            }
            private set
            {
                _ValueHistory = value;
            }
        }

        public double Capital
        {
            get
            {
                return _Capital;
            }
            set
            {
                if (value >= 0 && value <= double.MaxValue)
                    _Capital = value;
                else
                    throw new System.OverflowException();
            }
        }

        public double Value
        {
            get
            {
                if (Capital + Deposit.Value >= 0 && Capital + Deposit.Value <= double.MaxValue)
                    return Capital + Deposit.Value;
                throw new System.OverflowException();
            }
        }

        public void Buy(Stock stock, MarketState marketstate, int stockstobuy)
        {
            try
            {
                Deposit.Buy(stock, marketstate, stockstobuy);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Buy(DepositContent content, MarketState marketstate, int stockstobuy)
        {
            try
            {
                Deposit.Buy(content, marketstate, stockstobuy);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Sell(Stock stock, MarketState marketstate, int stockstosell)
        {
            try
            {
                Deposit.Sell(stock, marketstate, stockstosell);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Sell(DepositContent content, MarketState marketstate, int stockstosell)
        {
            try
            {
                Deposit.Sell(content, marketstate, stockstosell);
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
                Capital = CAPITAL_INITIALIZE;
                Deposit.Reset(random);
                ValueHistory.Reset(random);
                ValueHistory.Add(Value);
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
                if (IsComputer)
                {
                    if (Deposit.Count > 0)
                    {
                        StockIndex lastindex = null;
                        double lastpriceaverage = 0D;
                        foreach (DepositContent content in Deposit.Values)
                        {
                            if (content.Stock.StockIndexes.Count > 0)
                            {
                                System.Collections.Generic.Dictionary<string, StockIndex>.Enumerator e = content.Stock.StockIndexes.GetEnumerator();
                                if (e.MoveNext())
                                {
                                    if (lastindex == null)
                                    {
                                        lastindex = e.Current.Value;
                                        lastpriceaverage = lastindex.PriceAverage;
                                    }
                                    else if (e.Current.Value.Id != lastindex.Id)
                                    {
                                        lastindex = e.Current.Value;
                                        lastpriceaverage = lastindex.PriceAverage;
                                    }
                                    // Handle computer players deposit.
                                    int buyprocentlow = 0, buyprocentmiddle = 0, buyprocenthigh = 0, maxbuyprepoch = MAX_BUY_PR_EPOCH, stockstobuy = 0;
                                    int sellprocentlow = 0, sellprocentmiddle = 0, sellprocenthigh = 0, maxsellprepoch = MAX_SELL_PR_EPOCH, stockstosell = 0;
                                    switch (marketstate.State)
                                    {
                                        case MarketStateType.Normal:
                                            buyprocentlow = 75;
                                            buyprocentmiddle = 85;
                                            buyprocenthigh = 95;
                                            sellprocentlow = 50;
                                            sellprocentmiddle = 70;
                                            sellprocenthigh = 90;
                                            break;
                                        case MarketStateType.Depression:
                                            buyprocentlow = 60;
                                            buyprocentmiddle = 70;
                                            buyprocenthigh = 80;
                                            sellprocentlow = 30;
                                            sellprocentmiddle = 50;
                                            sellprocenthigh = 70;
                                            break;
                                        case MarketStateType.Boom:
                                            buyprocentlow = 70;
                                            buyprocentmiddle = 80;
                                            buyprocenthigh = 90;
                                            sellprocentlow = 70;
                                            sellprocentmiddle = 80;
                                            sellprocenthigh = 90;
                                            break;
                                        default:
                                            buyprocentlow = 100;
                                            buyprocentmiddle = 100;
                                            buyprocenthigh = 100;
                                            sellprocentlow = 100;
                                            sellprocentmiddle = 100;
                                            sellprocenthigh = 100;
                                            break;
                                    }
                                    // Try to buy stocks.
                                    if (content.Stock.Price < content.Stock.MinPrice * 4 && content.Stock.Available > 0)
                                    {
                                        if (maxbuyprepoch > 0)
                                        {
                                            stockstobuy = MAX_STOCKS_TO_BUY;
                                            if (stockstobuy > content.Stock.Available)
                                                stockstobuy = content.Stock.Available;
                                            while (stockstobuy > 0 && content.Stock.CalculatePrice(stockstobuy) + content.Stock.CalculateBrokerage(marketstate, stockstobuy) > Capital)
                                                stockstobuy = (int) System.Math.Floor((double) (stockstobuy / 10));
                                            if (stockstobuy > 5)
                                            {
                                                content.Buy(marketstate, random.Next(stockstobuy));
                                                maxbuyprepoch -= 1;
                                            }
                                            else if (stockstobuy > 0)
                                            {
                                                content.Buy(marketstate, stockstobuy);
                                                maxbuyprepoch -= 1;
                                            }
                                        }
                                    }
                                    else if (content.Stock.Price < lastpriceaverage / 8 && content.Stock.Available > 0)
                                    {
                                        // Try to buy stocks.
                                        if (random.Next(100) > buyprocentlow && maxbuyprepoch > 0)
                                        {
                                            stockstobuy = MAX_STOCKS_TO_BUY;
                                            if (stockstobuy > content.Stock.Available)
                                                stockstobuy = content.Stock.Available;
                                            while (stockstobuy > 0 && content.Stock.CalculatePrice(stockstobuy) + content.Stock.CalculateBrokerage(marketstate, stockstobuy) > Capital)
                                                stockstobuy = (int) System.Math.Floor((double) (stockstobuy / 10));
                                            if (stockstobuy > 5)
                                            {
                                                content.Buy(marketstate, random.Next(stockstobuy));
                                                maxbuyprepoch -= 1;
                                            }
                                            else if (stockstobuy > 0)
                                            {
                                                content.Buy(marketstate, stockstobuy);
                                                maxbuyprepoch -= 1;
                                            }
                                        }
                                    }
                                    else if (content.Stock.Price < lastpriceaverage / 4 && content.Stock.Available > 0)
                                    {
                                        // Try to buy stocks.
                                        if (random.Next(100) > buyprocentmiddle && maxbuyprepoch > 0)
                                        {
                                            stockstobuy = MAX_STOCKS_TO_BUY;
                                            if (stockstobuy > content.Stock.Available)
                                                stockstobuy = content.Stock.Available;
                                            while (stockstobuy > 0 && content.Stock.CalculatePrice(stockstobuy) + content.Stock.CalculateBrokerage(marketstate, stockstobuy) > Capital)
                                                stockstobuy = (int) System.Math.Floor((double) (stockstobuy / 10));
                                            if (stockstobuy >= 10)
                                            {
                                                stockstobuy = stockstobuy / 2;
                                                if (stockstobuy > 5)
                                                {
                                                    content.Buy(marketstate, random.Next(stockstobuy));
                                                    maxbuyprepoch -= 1;
                                                }
                                                else if (stockstobuy > 0)
                                                {
                                                    content.Buy(marketstate, stockstobuy);
                                                    maxbuyprepoch -= 1;
                                                }
                                            }
                                        }
                                    }
                                    else if (content.Stock.Price < lastpriceaverage && content.Stock.Available > 0)
                                    {
                                        // Try to buy stocks.
                                        if (random.Next(100) > buyprocenthigh && maxbuyprepoch > 0)
                                        {
                                            stockstobuy = MAX_STOCKS_TO_BUY;
                                            if (stockstobuy > content.Stock.Available)
                                                stockstobuy = content.Stock.Available;
                                            while (stockstobuy > 0 && content.Stock.CalculatePrice(stockstobuy) + content.Stock.CalculateBrokerage(marketstate, stockstobuy) > Capital)
                                                stockstobuy = (int) System.Math.Floor((double) (stockstobuy / 10));
                                            if (stockstobuy >= 20)
                                            {
                                                stockstobuy = stockstobuy / 4;
                                                if (stockstobuy > 5)
                                                {
                                                    content.Buy(marketstate, random.Next(stockstobuy));
                                                    maxbuyprepoch -= 1;
                                                }
                                                else if (stockstobuy > 0)
                                                {
                                                    content.Buy(marketstate, stockstobuy);
                                                    maxbuyprepoch -= 1;
                                                }
                                            }
                                        }
                                    }
                                    // Try to sell stocks.
                                    if (content.Count > 0 && content.Stock.Price > content.LastBuyPrice * 2.00)
                                    {
                                        // Try to sell stocks.
                                        if (random.Next(100) > sellprocentlow && maxsellprepoch > 0)
                                        {
                                            stockstosell = content.Count;
                                            if (stockstosell > 5)
                                            {
                                                content.Sell(marketstate, random.Next(stockstosell));
                                                maxsellprepoch -= 1;
                                            }
                                            else
                                            {
                                                content.Sell(marketstate, stockstosell);
                                                maxsellprepoch -= 1;
                                            }
                                        }
                                    }
                                    else if (content.Count > 0 && content.Stock.Price > content.LastBuyPrice * 1.50)
                                    {
                                        // Try to sell stocks.
                                        if (random.Next(100) > sellprocentmiddle && maxsellprepoch > 0)
                                        {
                                            stockstosell = content.Count;
                                            if (stockstosell >= 10)
                                            {
                                                stockstosell = stockstosell / 2;
                                                if (stockstosell > 5)
                                                {
                                                    content.Sell(marketstate, random.Next(stockstosell));
                                                    maxsellprepoch -= 1;
                                                }
                                                else
                                                {
                                                    content.Sell(marketstate, stockstosell);
                                                    maxsellprepoch -= 1;
                                                }
                                            }
                                            else
                                            {
                                                content.Sell(marketstate, stockstosell);
                                                maxsellprepoch -= 1;
                                            }
                                        }
                                    }
                                    else if (content.Count > 0 && content.Stock.Price > content.LastBuyPrice * 1.25)
                                    {
                                        // Try to sell stocks.
                                        if (random.Next(100) > sellprocenthigh && maxsellprepoch > 0)
                                        {
                                            stockstosell = content.Count;
                                            if (stockstosell >= 20)
                                            {
                                                stockstosell = stockstosell / 4;
                                                if (stockstosell > 5)
                                                {
                                                    content.Sell(marketstate, random.Next(stockstosell));
                                                    maxsellprepoch -= 1;
                                                }
                                                else
                                                {
                                                    content.Sell(marketstate, stockstosell);
                                                    maxsellprepoch -= 1;
                                                }
                                            }
                                            else
                                            {
                                                content.Sell(marketstate, stockstosell);
                                                maxsellprepoch -= 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                ValueHistory.AddHistory(Value);
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
                    fs.WriteString(Company);
                    fs.WriteString(Name);
                    fs.WriteBool(IsComputer);
                    fs.WriteBool(IsYou);
                    Deposit.Save(fv, fs);
                    ValueHistory.Save(fv, fs);
                    fs.WriteDouble(Capital);
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
                    Company = fs.ReadString();
                    Name = fs.ReadString();
                    IsComputer = fs.ReadBool();
                    IsYou = fs.ReadBool();
                    Deposit.Load(fv, fs, obj);
                    ValueHistory.Load(fv, fs, obj);
                    Capital = fs.ReadDouble();
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
                        IsComputer = communicator.ReceiveBool();
                        IsYou = communicator.ReceiveBool();
                        ValueHistory.ClientCommunication(serverversion, communicator, full, obj);
                    }
                    if (IsYou && !full)
                    {
                        communicator.SendString(Company);
                        communicator.SendString(Name);
                    }
                    else
                    {
                        Company = communicator.ReceiveString();
                        Name = communicator.ReceiveString();
                    }
                    Deposit.ClientCommunication(serverversion, communicator, full, obj);
                    Capital = communicator.ReceiveDouble();
                    ValueHistory.AddHistory(Value);
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
                        communicator.SendBool(IsComputer);
                        communicator.SendBool(Id == (int) obj);
                        ValueHistory.ServerCommunication(clientversion, communicator, full, obj);
                    }
                    if (Id == (int) obj && !full)
                    {
                        Company = communicator.ReceiveString();
                        Name = communicator.ReceiveString();
                    }
                    else
                    {
                        communicator.SendString(Company);
                        communicator.SendString(Name);
                    }
                    Deposit.ServerCommunication(clientversion, communicator, full, obj);
                    communicator.SendDouble(Capital);
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
