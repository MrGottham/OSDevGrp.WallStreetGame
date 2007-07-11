using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Deposit : System.Collections.Generic.Dictionary<string, DepositContent>, IResetable
    {
        private Player _Player = null;

        public Deposit(Player player, Stocks stocks) : base(stocks.Count)
        {
            try
            {
                Player = player;
                if (stocks.Count > 0)
                {
                    foreach (Stock stock in stocks.Values)
                    {
                        this.Add(stock.Id, new DepositContent(this, stock));
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public Player Player
        {
            get
            {
                return _Player;
            }
            private set
            {
                _Player = value;
            }
        }

        public double Value
        {
            get
            {
                double d = 0D;
                if (this.Count > 0)
                {
                    foreach (DepositContent dc in this.Values)
                    {
                        if (d + dc.Value >= 0 && d + dc.Value <= double.MaxValue)
                            d += dc.Value;
                    }
                }
                return d;
            }
        }

        public void Buy(Stock stock, MarketState marketstate, int stockstobuy)
        {
            try
            {
                DepositContent content = null;
                if (this.TryGetValue(stock.Id, out content))
                {
                    this.Buy(content, marketstate, stockstobuy);
                }
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
                if (this.ContainsValue(content))
                {
                    content.Buy(marketstate, stockstobuy);
                }
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
                DepositContent content = null;
                if (this.TryGetValue(stock.Id, out content))
                {
                    this.Sell(content, marketstate, stockstosell);
                }
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
                if (this.ContainsValue(content))
                {
                    content.Sell(marketstate, stockstosell);
                }
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
                if (this.Count > 0)
                {
                    foreach (IResetable r in this.Values)
                    {
                        r.Reset(random);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
