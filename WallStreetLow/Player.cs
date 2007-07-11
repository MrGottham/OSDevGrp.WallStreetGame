using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Player : System.Object, IResetable, IPlayable
    {
        private const double CAPITAL_INITIALIZE = 100000D;
        private const int MAX_STOCKS_TO_BUY = 1000;
        private const int MAX_BUY_PR_EPOCH = 3;
        private const int MAX_SELL_PR_EPOCH = 3;

        private string _Company = null;
        private string _Name = null;
        private bool _IsComputer = true;
        private bool _IsYou = false;
        private Deposit _Deposit = null;
        private DoubleHistory _ValueHistory = null;
        private double _Capital = CAPITAL_INITIALIZE;

        public Player(string company, string name, Stocks stocks) : this(company, name, stocks, true, false)
        {
        }

        public Player(string company, string name, Stocks stocks, bool iscomputer, bool isyou) : base()
        {
            try
            {
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

        public string Company
        {
            get
            {
                return _Company;
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
                return _Name;
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
                                            buyprocentlow = 70;
                                            buyprocentmiddle = 80;
                                            buyprocenthigh = 90;
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
                                            buyprocentlow = 50;
                                            buyprocentmiddle = 60;
                                            buyprocenthigh = 70;
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
                                    if (content.Stock.Price < lastpriceaverage / 4 && content.Stock.Available > 0)
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
                                    else if (content.Stock.Price < lastpriceaverage / 2 && content.Stock.Available > 0)
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
    }
}
