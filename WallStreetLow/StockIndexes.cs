using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class StockIndexes : System.Collections.Generic.Dictionary<string, StockIndex>, IStoreable, INetworkable
    {
        public StockIndexes() : base()
        {
        }

        public void Save(Version fv, WsgFileStream fs)
        {
            try
            {
                if (fv.Major > 0)
                {
                    fs.WriteInt(this.Count);
                    if (Count > 0)
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
                        StockIndex stockindex = new StockIndex(fv, fs, obj);
                        this.Add(stockindex.Id, stockindex);
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
                                StockIndex stockindex = new StockIndex(serverversion, communicator, full, obj);
                                this.Add(stockindex.Id, stockindex);
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
