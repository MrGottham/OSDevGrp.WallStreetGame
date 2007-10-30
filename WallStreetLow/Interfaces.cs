using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public interface IResetable
    {
        void Reset(System.Random random);
    }

    public interface IPlayable
    {
        void Play(MarketState marketstate, System.Random random);
    }

    public interface IStoreable
    {
        void Save(Version fv, WsgFileStream fs);
        System.Object Load(Version fv, WsgFileStream fs, System.Object obj);
    }

    public interface ICommunicateable
    {
        byte ReceiveByte();
        bool ReceiveBool();
        int ReceiveInt();
        double ReceiveDouble();
        string ReceiveString();
        void SendByte(byte b);
        void SendBool(bool b);
        void SendInt(int i);
        void SendDouble(double d);
        void SendString(string s);
    }

    public interface INetworkable
    {
        System.Object ClientCommunication(Version serverversion, ICommunicateable communicator, bool full, System.Object obj);
        System.Object ServerCommunication(Version clientversion, ICommunicateable communicator, bool full, System.Object obj);
    }

    public interface INetworkTradeable
    {
        void ClientBuyStocks(Version serverversion, ICommunicateable communicator);
        void ClientSellStocks(Version serverversion, ICommunicateable communicator);
        void ServerBuyStocks(Version clientversion, ICommunicateable communicator);
        void ServerSellStocks(Version clientversion, ICommunicateable communicator);
    }

    public interface ISelectable
    {
        string GetSelectText();
    }

    public interface ISelectables
    {
        System.Collections.Generic.List<ISelectable> GetSelectables();
    }
}
