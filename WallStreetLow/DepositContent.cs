using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class DepositContent : System.Object, IResetable
    {
        private Stock _Stock = null;
        private int _Count = 0;

        public DepositContent(Stock stock) : base()
        {
            try
            {
                Stock = stock;
                Reset(null);
            }
            catch (System.Exception ex)
            {
                throw ex;
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
                if (Count * Stock.Price < double.MinValue)
                    return double.MinValue;
                else if (Count * Stock.Price > double.MaxValue)
                    return double.MaxValue;
                else
                    return Count * Stock.Price;
            }
        }

        public void Reset(System.Random random)
        {
            try
            {
                Count = 0;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
