using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    class HistoryValue<T> : System.Object
    {
        private System.DateTime _DateTime;
        private T _Value;

        public HistoryValue(T value) : base()
        {
            try
            {
                DateTime = System.DateTime.Now.ToUniversalTime();
                Value = value;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public DateTime DateTime
        {
            get
            {
                return _DateTime;
            }
            private set
            {
                _DateTime = value;
            }
        }

        public T Value
        {
            get
            {
                return _Value;
            }
            private set
            {
                _Value = value;
            }
        }
    }

    public class History<T> : System.Collections.Generic.List<T>, IResetable
    {
        public History() : base(256)
        {
            try
            {
                Reset(null);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void AddHistory(T value)
        {
            try
            {
                while (this.Count >= this.Capacity)
                    this.RemoveAt(0);
                this.Add(value);
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
                while (this.Count > 0)
                    this.Clear();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }

    public class DoubleHistory : History<double>, IStoreable, INetworkable
    {
        public DoubleHistory() : base()
        {
        }

        public double Min
        {
            get
            {
                System.Nullable<double> m = null;
                if (this.Count > 0)
                {
                    foreach (double d in this)
                    {
                        if (m.HasValue)
                        {
                            if (m > d)
                                m = d;
                        }
                        else
                            m = d;
                    }
                    if (m.HasValue)
                        return m.Value;
                }
                return 0D;
            }
        }

        public double Max
        {
            get
            {
                System.Nullable<double> m = null;
                if (this.Count > 0)
                {
                    foreach (double d in this)
                    {
                        if (m.HasValue)
                        {
                            if (m < d)
                                m = d;
                        }
                        else
                            m = d;
                    }
                    if (m.HasValue)
                        return m.Value;
                }
                return 0D;
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
                        foreach (double d in this)
                            fs.WriteDouble(d);
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
                    while (this.Count > 0)
                        this.Clear();
                    int c = fs.ReadInt();
                    if (c > 0)
                    {
                        for (int i = 0; i < c; i++)
                            this.Add(fs.ReadDouble());
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
                    while (this.Count > 0)
                        this.Clear();
                    int c = communicator.ReceiveInt();
                    if (c > 0)
                    {
                        for (int i = 0; i < c; i++)
                            this.Add(communicator.ReceiveDouble());
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
                        foreach (double d in this)
                            communicator.SendDouble(d);
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
