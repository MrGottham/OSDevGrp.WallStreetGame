using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Stocks : System.Collections.Generic.Dictionary<string, Stock>, IResetable
    {
        public Stocks() : base()
        {
        }

        public void Reset()
        {
            try
            {
                if (this.Count > 0)
                {
                    foreach (IResetable r in this.Values)
                    {
                        r.Reset();
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
