using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Stocks : System.Collections.Generic.Dictionary<string, Stock>, IResetable, IPlayable, IStoreable, INetworkable
    {
        public Stocks() : base()
        {
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

        public void Play(MarketState marketstate, System.Random random)
        {
            try
            {
                if (this.Count > 0)
                {
                    foreach (IPlayable p in this.Values)
                    {
                        p.Play(marketstate, random);
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
                        foreach (IStoreable s in this.Values)
                            s.Save(fv, fs);
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
                        Stock stock = new Stock(fv, fs, obj);
                        this.Add(stock.Id, stock);
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
                        Enumerator e = this.GetEnumerator();
                        for (int i = 0; i < c; i++)
                        {
                            if (full)
                            {
                                Stock stock = new Stock(serverversion, communicator, full, obj);
                                this.Add(stock.Id, stock);
                            }
                            else if (e.MoveNext())
                                e.Current.Value.ClientCommunication(serverversion, communicator, full, obj);
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

        public System.Object ServerCommunication(Version serverversion, ICommunicateable communicator, bool full, System.Object obj)
        {
            try
            {
                if (serverversion.Major > 0)
                {
                    communicator.SendInt(this.Count);
                    if (this.Count > 0)
                    {
                        foreach (INetworkable n in this.Values)
                            n.ServerCommunication(serverversion, communicator, full, obj);
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
