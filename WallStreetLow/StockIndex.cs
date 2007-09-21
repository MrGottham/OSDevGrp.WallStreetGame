using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class StockIndex : System.Object, IStoreable, INetworkable
    {
        private string _Id = null;
        private string _Name = null;
        private Stocks _Stocks = null;

        public StockIndex(string id, string name) : base()
        {
            try
            {
                Id = id;
                Name = name;
                Stocks = new Stocks();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public StockIndex(Version fv, WsgFileStream fs, System.Object obj) : base()
        {
            try
            {
                Stocks = new Stocks();
                Load(fv, fs, obj);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public StockIndex(Version serverversion, ICommunicateable communicator, bool full, System.Object obj) : base()
        {
            try
            {
                Stocks = new Stocks();
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

        public double PriceAverage
        {
            get
            {
                if (Stocks.Count > 0)
                {
                    double d = 0;
                    foreach(Stock stock in Stocks.Values)
                    {
                        if (d + stock.Price >= 0 && d + stock.Price <= double.MaxValue)
                            d += stock.Price;
                    }
                    return System.Math.Round(d / Stocks.Count, 2);
                }
                return 0D;
            }
        }

        public Stocks Stocks
        {
            get
            {
                return _Stocks;
            }
            private set
            {
                _Stocks = value;
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
                    if (full)
                    {
                        communicator.SendString(Id);
                        communicator.SendString(Name);
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
