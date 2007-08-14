using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Configuration : System.Object 
    {
        private string _SetupFileName = null;
        private StockIndexes _StockIndexes = null;
        private Stocks _Stocks = null;
        private Players _Players = null;
        private System.Xml.XmlDocument _XmlDocument = null;
        private System.Xml.XmlNode _AllStocksXmlNode = null;

        public Configuration(string setupfilename, System.Random random) : this(setupfilename, random, null, null, null)
        {
        }

        public Configuration(string setupfilename, System.Random random, StockIndexes stockindexes, Stocks stocks, Players players) : base()
        {
            try
            {
                SetupFileName = setupfilename;
                StockIndexes = stockindexes;
                if (StockIndexes == null)
                    StockIndexes = new StockIndexes();
                Stocks = stocks;
                if (Stocks == null)
                    Stocks = new Stocks();
                Players = players;
                if (Players == null)
                    Players = new Players();
                Load(random);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public string SetupFileName
        {
            get
            {
                return _SetupFileName;
            }
            set
            {
                _SetupFileName = value;
            }
        }

        public StockIndexes StockIndexes
        {
            get
            {
                return _StockIndexes;
            }
            private set
            {
                _StockIndexes = value;
            }
        }

        public Stocks Stocks
        {
            get
            {
                return _Stocks;
            }
            private set
            {
                _Stocks = value;
            }
        }

        public Players Players
        {
            get
            {
                return _Players;
            }
            private set
            {
                _Players = value;
            }
        }

        private System.Xml.XmlDocument XmlDocument
        {
            get
            {
                return _XmlDocument;
            }
            set
            {
                _XmlDocument = value;
            }
        }

        private System.Xml.XmlNode AllStocksXmlNode
        {
            get
            {
                return _AllStocksXmlNode;
            }
            set
            {
                _AllStocksXmlNode = value;
            }
        }

        private string AllStocksIndexId
        {
            get
            {
                if (AllStocksXmlNode != null)
                {
                    if (AllStocksXmlNode.Attributes["indexid"] != null)
                        return AllStocksXmlNode.Attributes["indexid"].Value;
                }
                return string.Empty;
            }
        }

        private string AllStocksIndexName
        {
            get
            {
                if (AllStocksXmlNode != null)
                {
                    if (AllStocksXmlNode.HasChildNodes)
                        return AllStocksXmlNode.FirstChild.Value;
                }
                return string.Empty;
            }
        }

        public void Load(System.Random random)
        {
            try
            {
                while (StockIndexes.Count > 0)
                    StockIndexes.Clear();
                while (Stocks.Count > 0)
                    Stocks.Clear();
                if (XmlDocument == null)
                    XmlDocument = new System.Xml.XmlDocument();
                XmlDocument.Load(SetupFileName);
                AllStocksXmlNode = XmlDocument.DocumentElement.SelectSingleNode("AllStocks");
                if (AllStocksXmlNode == null)
                    throw new System.Exception("No node named 'AllStocks' in the file named '" + SetupFileName + "'.");
                else if (AllStocksXmlNode.Attributes["indexid"] == null)
                    throw new System.Exception("No attribute named 'indexid' on a node named '" + AllStocksXmlNode.LocalName + "' in the file named '" + SetupFileName + "'.");
                System.Xml.XmlNodeList xmlnodes = XmlDocument.DocumentElement.SelectNodes("StockIndex");
                if (xmlnodes == null)
                    throw new System.Exception("No nodes named 'StockIndex' in the file named '" + SetupFileName + "'.");
                else if (xmlnodes.Count == 0)
                    throw new System.Exception("No nodes named 'StockIndex' in the file named '" + SetupFileName + "'.");
                foreach (System.Xml.XmlNode xmlnode in xmlnodes)
                {
                    if (xmlnode.Attributes["indexid"] == null)
                        throw new System.Exception("No attribute named 'indexid' on a node named '" + xmlnode.LocalName + "' in the file named '" + SetupFileName + "'.");
                    if (xmlnode.Attributes["name"] == null)
                        throw new System.Exception("No attribute named 'named' on a node named '" + xmlnode.LocalName + "' in the file named '" + SetupFileName + "'.");
                    StockIndex stockindex = null;
                    if (!StockIndexes.TryGetValue(xmlnode.Attributes["indexid"].Value, out stockindex))
                    {
                        stockindex = new StockIndex(xmlnode.Attributes["indexid"].Value, xmlnode.Attributes["name"].Value);
                        StockIndexes.Add(stockindex.Id, stockindex);
                    }
                    System.Xml.XmlNodeList xmlchildnodes = xmlnode.SelectNodes("Stock");
                    if (xmlchildnodes == null)
                        throw new System.Exception("No nodes named 'Stock' under the node named '" + xmlnode.LocalName + "' where indexid is '" + xmlnode.Attributes["indexid"].Value + "' in the file named '" + SetupFileName + "'.");
                    if (xmlchildnodes.Count == 0)
                        throw new System.Exception("No nodes named 'Stock' under the node named '" + xmlnode.LocalName + "' where indexid is '" + xmlnode.Attributes["indexid"].Value + "' in the file named '" + SetupFileName + "'.");
                    foreach (System.Xml.XmlNode xmlchildnode in xmlchildnodes)
                    {
                        if (xmlchildnode.Attributes["stockid"] == null)
                            throw new System.Exception("No attribute named 'stockid' on a node named '" + xmlchildnode.LocalName + "' under the node named '" + xmlnode.LocalName + "' where indexid is '" + xmlnode.Attributes["indexid"].Value + "' in the file named '" + SetupFileName + "'.");
                        Stock stock = null;
                        if (!Stocks.TryGetValue(xmlchildnode.Attributes["stockid"].Value, out stock))
                        {
                            if (xmlchildnode.HasChildNodes)
                            {
                                if (xmlchildnode.HasChildNodes)
                                {
                                    stock = new Stock(xmlchildnode.Attributes["stockid"].Value, xmlchildnode.FirstChild.Value, stockindex, random);
                                    Stocks.Add(stock.Id, stock);
                                }
                            }
                        }
                        else if (xmlchildnode.HasChildNodes)
                        {
                            stock.AddStockIndex(stockindex);
                        }
                    }
                }
                if (AllStocksIndexId.Length > 0 && AllStocksIndexName.Length > 0)
                {
                    if (!StockIndexes.ContainsKey(AllStocksIndexId))
                    {
                        StockIndex stockindex = new StockIndex(AllStocksIndexId, AllStocksIndexName);
                        foreach (Stock stock in Stocks.Values)
                        {
                            stock.StockIndexes.Add(stockindex.Id, stockindex);
                            stockindex.Stocks.Add(stock.Id, stock);
                        }
                        StockIndexes.Add(stockindex.Id, stockindex);
                    }
                }
                xmlnodes = XmlDocument.DocumentElement.SelectNodes("Player");
                if (xmlnodes == null)
                    throw new System.Exception("No nodes named 'Player' in the file named '" + SetupFileName + "'.");
                else if (xmlnodes.Count == 0)
                    throw new System.Exception("No nodes named 'Player' in the file named '" + SetupFileName + "'.");
                foreach (System.Xml.XmlNode xmlnode in xmlnodes)
                {
                    if (xmlnode.Attributes["company"] == null)
                        throw new System.Exception("No attribute named 'company' on a node named '" + xmlnode.LocalName + "' in the file named '" + SetupFileName + "'.");
                    if (xmlnode.HasChildNodes)
                    {
                        Players.Add(new Player(xmlnode.Attributes["company"].Value, xmlnode.FirstChild.Value, Stocks));
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
