﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Deposit : System.Collections.Generic.Dictionary<string, DepositContent>, IResetable, IStoreable, INetworkable
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

        public void Save(Version fv, WsgFileStream fs)
        {
            try
            {
                if (fv.Major > 0)
                {
                    fs.WriteInt(this.Count);
                    if (this.Count > 0)
                    {
                        foreach (string s in this.Keys)
                        {
                            fs.WriteString(s);
                            DepositContent content = null;
                            if (this.TryGetValue(s, out content))
                                content.Save(fv, fs);
                        }
                    }
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
                    int c = fs.ReadInt();
                    for (int i = 0; i < c; i++)
                    {
                        string s = fs.ReadString();
                        DepositContent content = null;
                        if (this.TryGetValue(s, out content))
                            content.Load(fv, fs, obj);
                    }
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
                    int c = communicator.ReceiveInt();
                    if (c > 0)
                    {
                        System.Collections.Generic.Dictionary<string, DepositContent>.ValueCollection.Enumerator e = this.Values.GetEnumerator();
                        for (int i = 0; i < c; i++)
                        {
                            if (e.MoveNext())
                                e.Current.ClientCommunication(serverversion, communicator, full, obj);
                        }
                    }
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
                    communicator.SendInt(this.Count);
                    if (this.Count > 0)
                    {
                        foreach (INetworkable n in this.Values)
                            n.ServerCommunication(clientversion, communicator, full, obj);
                    }
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
