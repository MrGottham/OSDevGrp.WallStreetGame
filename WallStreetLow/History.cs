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

    public class History<T> : System.Collections.Generic.List<T>
    {
        public History() : base(256)
        {
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
    }

    public class DoubleHistory : History<double>
    {
        public DoubleHistory() : base()
        {
        }
    }
}
