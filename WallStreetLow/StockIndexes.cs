using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class StockIndexes : System.Collections.Generic.Dictionary<string, StockIndex>, IStoreable
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
    }
}
