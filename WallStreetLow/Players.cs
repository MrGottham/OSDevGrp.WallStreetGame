using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Players : System.Collections.Generic.List<Player>, IResetable, IPlayable, IStoreable
    {
        public Players() : base()
        {
        }

        public void Reset(System.Random random)
        {
            try
            {
                if (this.Count > 0)
                {
                    foreach (IResetable r in this)
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
                    foreach (IPlayable p in this)
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
                        foreach (IStoreable s in this)
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
                Player currentplayer = null;
                if (fv.Major > 0)
                {
                    int c = fs.ReadInt();
                    for (int i = 0; i < c; i++)
                    {
                        Player player = new Player(fv, fs, obj);
                        if (player.IsYou)
                            currentplayer = player;
                        this.Add(player);
                    }
                }
                return currentplayer;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
