using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class DepositContent : System.Object, IResetable
    {
        private Deposit _Deposit = null;
        private Stock _Stock = null;
        private int _Count = 0;
        private double _LastBuyPrice = 0;
        private double _LastSellPrice = 0;

        public DepositContent(Deposit deposit, Stock stock) : base()
        {
            try
            {
                Deposit = deposit;
                Stock = stock;
                Reset(null);
            }
            catch (System.Exception ex)
            {
                throw ex;
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

        public Stock Stock
        {
            get
            {
                return _Stock;
            }
            private set
            {
                _Stock = value;
            }
        }

        public int Count
        {
            get
            {
                return _Count;
            }
            private set
            {
                _Count = value;
            }
        }

        public double Value
        {
            get
            {
                if (Count * Stock.Price >= 0 && Count * Stock.Price <= double.MaxValue)
                    return Count * Stock.Price;
                throw new System.OverflowException();
            }
        }

        public double LastBuyPrice
        {
            get
            {
                return _LastBuyPrice;
            }
            private set
            {
                _LastBuyPrice = value;
            }
        }

        public double LastSellPrice
        {
            get
            {
                return _LastSellPrice;
            }
            private set
            {
                _LastSellPrice = value;
            }
        }

        public void Buy(MarketState marketstate, int stockstobuy)
        {
            try
            {
                if (stockstobuy > 0 && stockstobuy <= Stock.Available && Deposit.Player.Capital >= Stock.CalculatePrice(stockstobuy) + Stock.CalculateBrokerage(marketstate, stockstobuy))
                {
                    Count += stockstobuy;
                    Stock.Available -= stockstobuy;
                    LastBuyPrice = Stock.Price;
                    Deposit.Player.Capital -= Stock.CalculatePrice(stockstobuy) + Stock.CalculateBrokerage(marketstate, stockstobuy);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Sell(MarketState marketstate, int stockstosell)
        {
            try
            {
                if (stockstosell > 0 && stockstosell <= Count && Stock.CalculatePrice(stockstosell) >= Stock.CalculateBrokerage(marketstate, stockstosell))
                {
                    Count -= stockstosell;
                    Stock.Available += stockstosell;
                    if (Count <= 0)
                    {
                        LastBuyPrice = 0;
                        LastSellPrice = 0;
                    }
                    else
                        LastBuyPrice = Stock.Price;
                    Deposit.Player.Capital += Stock.CalculatePrice(stockstosell) - Stock.CalculateBrokerage(marketstate, stockstosell);
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
                Count = 0;
                LastBuyPrice = 0;
                LastSellPrice = 0;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
