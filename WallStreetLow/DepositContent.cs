using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class DepositContent : System.Object, IResetable, IStoreable, INetworkable, INetworkTradeable
    {
        private Deposit _Deposit = null;
        private Stock _Stock = null;
        private int _Count = 0;
        private double _LastBuyPrice = 0;
        private double _LastSellPrice = 0;

        public delegate void OnClientBuyStocks(string stockid, INetworkTradeable tradeable, MarketState marketstate, int stockstobuy);
        public delegate void OnClientSellStocks(string stockid, INetworkTradeable tradeable, MarketState marketstate, int stockstosell);

        private OnClientBuyStocks _OnClientBuyStocksEvent = null;
        private OnClientSellStocks _OnClientSellStocksEvent = null;

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

        public OnClientBuyStocks OnClientBuyStocksEvent
        {
            get
            {
                return _OnClientBuyStocksEvent;
            }
            set
            {
                _OnClientBuyStocksEvent = value;
            }
        }

        public OnClientSellStocks OnClientSellStocksEvent
        {
            get
            {
                return _OnClientSellStocksEvent;
            }
            set
            {
                _OnClientSellStocksEvent = value;
            }
        }

        public void Buy(MarketState marketstate, int stockstobuy)
        {
            try
            {
                if (OnClientBuyStocksEvent != null)
                {
                    if (stockstobuy > 0 && stockstobuy <= Stock.Available && Deposit.Player.Capital >= Stock.CalculatePrice(stockstobuy) + Stock.CalculateBrokerage(marketstate, stockstobuy))
                        OnClientBuyStocksEvent(Stock.Id, this, marketstate, stockstobuy);
                }
                else if (stockstobuy > 0 && stockstobuy <= Stock.Available && Deposit.Player.Capital >= Stock.CalculatePrice(stockstobuy) + Stock.CalculateBrokerage(marketstate, stockstobuy))
                {
                    Count += stockstobuy;
                    Stock.Available -= stockstobuy;
                    Stock.OwnedByPlayers += stockstobuy;
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
                if (OnClientSellStocksEvent != null)
                {
                    if (stockstosell > 0 && stockstosell <= Count && Stock.CalculatePrice(stockstosell) >= Stock.CalculateBrokerage(marketstate, stockstosell))
                        OnClientSellStocksEvent(Stock.Id, this, marketstate, stockstosell);
                }
                else if (stockstosell > 0 && stockstosell <= Count && Stock.CalculatePrice(stockstosell) >= Stock.CalculateBrokerage(marketstate, stockstosell))
                {
                    Count -= stockstosell;
                    Stock.OwnedByPlayers -= stockstosell;
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

        public void Save(Version fv, WsgFileStream fs)
        {
            try
            {
                if (fv.Major > 0)
                {
                    fs.WriteInt(Count);
                    fs.WriteDouble(LastBuyPrice);
                    fs.WriteDouble(LastSellPrice);
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
                    Count = fs.ReadInt();
                    LastBuyPrice = fs.ReadDouble();
                    LastSellPrice = fs.ReadDouble();
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
                    Count = communicator.ReceiveInt();
                    LastBuyPrice = communicator.ReceiveDouble();
                    LastSellPrice = communicator.ReceiveDouble();
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
                    communicator.SendInt(Count);
                    communicator.SendDouble(LastBuyPrice);
                    communicator.SendDouble(LastSellPrice);
                }
                return this;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void ClientBuyStocks(Version serverversion, ICommunicateable communicator, MarketState marketstate, int stockstobuy)
        {
            try
            {
                if (serverversion.Major > 0)
                {
                    Stock.Available = communicator.ReceiveInt();
                    if (stockstobuy > Stock.Available)
                        stockstobuy = Stock.Available;
                    communicator.SendInt(stockstobuy);
                    communicator.SendDouble(Stock.Price);
                    communicator.SendDouble(Stock.CalculatePrice(stockstobuy) + Stock.CalculateBrokerage(marketstate, stockstobuy));
                    Count = communicator.ReceiveInt();
                    Stock.Available = communicator.ReceiveInt();
                    Stock.OwnedByPlayers = communicator.ReceiveInt();
                    LastBuyPrice = communicator.ReceiveDouble();
                    Deposit.Player.Capital = communicator.ReceiveDouble();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void ClientSellStocks(Version serverversion, ICommunicateable communicator, MarketState marketstate, int stockstosell)
        {
            try
            {
                if (serverversion.Major > 0)
                {
                    communicator.SendInt(stockstosell);
                    communicator.SendDouble(Stock.Price);
                    communicator.SendDouble(Stock.CalculatePrice(stockstosell));
                    communicator.SendDouble(Stock.CalculateBrokerage(marketstate, stockstosell));
                    Count = communicator.ReceiveInt();
                    Stock.OwnedByPlayers = communicator.ReceiveInt();
                    Stock.Available = communicator.ReceiveInt();
                    LastBuyPrice = communicator.ReceiveDouble();
                    LastSellPrice = communicator.ReceiveDouble();
                    Deposit.Player.Capital = communicator.ReceiveDouble();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void ServerBuyStocks(Version clientversion, ICommunicateable communicator)
        {
            try
            {
                if (clientversion.Major > 0)
                {
                    communicator.SendInt(Stock.Available);
                    int stockstobuy = communicator.ReceiveInt();
                    double stockprice = communicator.ReceiveDouble();
                    double price = communicator.ReceiveDouble();
                    if (stockstobuy > 0 && stockstobuy <= Stock.Available && Deposit.Player.Capital >= price)
                    {
                        Count += stockstobuy;
                        Stock.Available -= stockstobuy;
                        Stock.OwnedByPlayers += stockstobuy;
                        LastBuyPrice = stockprice;
                        Deposit.Player.Capital -= price;
                    }
                    communicator.SendInt(Count);
                    communicator.SendInt(Stock.Available);
                    communicator.SendInt(Stock.OwnedByPlayers);
                    communicator.SendDouble(LastBuyPrice);
                    communicator.SendDouble(Deposit.Player.Capital);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void ServerSellStocks(Version clientversion, ICommunicateable communicator)
        {
            try
            {
                if (clientversion.Major > 0)
                {
                    int stockstosell = communicator.ReceiveInt();
                    double stockprice = communicator.ReceiveDouble();
                    double price = communicator.ReceiveDouble();
                    double brokerage = communicator.ReceiveDouble();
                    if (stockstosell > 0 && stockstosell < Count && price >= brokerage)
                    {
                        Count -= stockstosell;
                        Stock.OwnedByPlayers -= stockstosell;
                        Stock.Available += stockstosell;
                        if (Count <= 0)
                        {
                            LastBuyPrice = 0;
                            LastSellPrice = 0;
                        }
                        else
                            LastSellPrice = stockprice;
                        Deposit.Player.Capital += price - brokerage;
                    }
                    communicator.SendInt(Count);
                    communicator.SendInt(Stock.OwnedByPlayers);
                    communicator.SendInt(Stock.Available);
                    communicator.SendDouble(LastBuyPrice);
                    communicator.SendDouble(LastSellPrice);
                    communicator.SendDouble(Deposit.Player.Capital);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
