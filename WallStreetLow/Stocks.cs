﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Stocks : System.Collections.Generic.Dictionary<string, Stock>, IResetable, IPlayable, IStoreable
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

        public void Load(Version fv, WsgFileStream fs)
        {
            try
            {
                if (fv.Major > 0)
                {
                    int c = fs.ReadInt();
                    for (int i = 0; i < c; i++)
                    {
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
