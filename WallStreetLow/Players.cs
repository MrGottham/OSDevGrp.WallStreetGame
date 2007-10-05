using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Players : System.Collections.Generic.List<Player>, IResetable, IPlayable, IStoreable, INetworkable
    {
        private System.Collections.Generic.List<Player> _NewPlayers = null;
        private System.Collections.Generic.List<Player> _DisconnectedPlayers = null;

        public Players() : base()
        {
            try
            {
                NewPlayers = new System.Collections.Generic.List<Player>();
                DisconnectedPlayers = new System.Collections.Generic.List<Player>();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public System.Collections.Generic.List<Player> NewPlayers
        {
            get
            {
                return _NewPlayers;
            }
            private set
            {
                _NewPlayers = value;
            }
        }

        public System.Collections.Generic.List<Player> DisconnectedPlayers
        {
            get
            {
                return _DisconnectedPlayers;
            }
            private set
            {
                _DisconnectedPlayers = value;
            }
        }

        public int NextPlayerId
        {
            get
            {
                int nextplayerid = 10000001;
                if (this.Count > 0)
                {
                    foreach (Player player in this)
                    {
                        if (player.Id >= nextplayerid)
                            nextplayerid = player.Id + 1;
                    }
                }
                return nextplayerid;
            }
        }

        public double AverageValue
        {
            get
            {
                double averagevalue = 0D;
                if (this.Count > 0)
                {
                    foreach (Player player in this)
                    {
                        if (averagevalue + player.Value <= double.MaxValue)
                            averagevalue += player.Value;
                    }
                    return averagevalue / this.Count;
                }
                return averagevalue;
            }
        }

        public bool Contains(int playerid)
        {
            try
            {
                if (this.Count > 0)
                {
                    foreach (Player player in this)
                    {
                        if (player.Id == playerid)
                            return true;
                    }
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private Player GetPlayer(int playerid)
        {
            try
            {
                if (this.Count > 0)
                {
                    foreach (Player player in this)
                    {
                        if (player.Id == playerid)
                            return player;
                    }
                }
                return null;
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
                        Player player = new Player(NextPlayerId, fv, fs, obj);
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
                    while (NewPlayers.Count > 0)
                        NewPlayers.Clear();
                    while (DisconnectedPlayers.Count > 0)
                        DisconnectedPlayers.Clear();
                    DisconnectedPlayers.AddRange(this);
                    int c = communicator.ReceiveInt();
                    if (c > 0)
                    {
                        for (int i = 0; i < c; i++)
                        {
                            int playerid = communicator.ReceiveInt();
                            bool containplayer = Contains(playerid);
                            communicator.SendBool(containplayer);
                            if (!containplayer)
                            {
                                Player player = new Player(playerid, serverversion, communicator, true, obj);
                                this.Add(player);
                                NewPlayers.Add(player);
                            }
                            else
                            {
                                Player player = GetPlayer(playerid);
                                player.ClientCommunication(serverversion, communicator, false, obj);
                                while (DisconnectedPlayers.Contains(player))
                                    DisconnectedPlayers.Remove(player);
                            }
                        }
                    }
                    if (DisconnectedPlayers.Count > 0)
                    {
                        foreach (Player p in DisconnectedPlayers)
                        {
                            while (this.Contains(p))
                                this.Remove(p);
                        }
                    }
                }
                foreach (Player player in this)
                {
                    if (player.IsYou)
                        return player;
                }
                return null;
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
                        foreach (Player player in this)
                        {
                            communicator.SendInt(player.Id);
                            bool containplayer = communicator.ReceiveBool();
                            if (!containplayer)
                            {
                                player.ServerCommunication(clientversion, communicator, true, obj);
                            }
                            else
                            {
                                player.ServerCommunication(clientversion, communicator, false, obj);
                            }
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
    }
}
