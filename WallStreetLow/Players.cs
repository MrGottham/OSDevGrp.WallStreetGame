using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Players : System.Collections.Generic.List<Player>, IResetable, IPlayable, IStoreable, INetworkable
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
                                Player player = new Player(serverversion, communicator, full, obj);
                                this.Add(player);
                            }
                            else
                                e.Current.ClientCommunication(serverversion, communicator, full, obj);
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

        public System.Object ServerCommunication(Version clientversion, ICommunicateable communicator, bool full, System.Object obj)
        {
            try
            {
                if (clientversion.Major > 0)
                {
                    communicator.SendInt(this.Count);
                    if (this.Count > 0)
                    {
                        foreach (INetworkable n in this)
                            n.ServerCommunication(clientversion, communicator, full, obj);
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
