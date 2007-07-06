using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Deposit : System.Collections.Generic.Dictionary<string, DepositContent>, IResetable
    {
        public Deposit(Stocks stocks) : base(stocks.Count)
        {
            try
            {
                if (stocks.Count > 0)
                {
                    foreach (Stock stock in stocks.Values)
                    {
                        this.Add(stock.Id, new DepositContent(stock));
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
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
                        if (d + dc.Value < double.MinValue)
                            d = double.MinValue;
                        else if (d + dc.Value > double.MaxValue)
                            d = double.MaxValue;
                        else
                            d += dc.Value;
                    }
                }
                return d;
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
