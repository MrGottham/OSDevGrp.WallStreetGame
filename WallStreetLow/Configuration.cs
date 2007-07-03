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
        private System.Xml.XmlDocument _XmlDocument = null;

        public Configuration(string setupfilename) : this(setupfilename, null, null)
        {
        }

        public Configuration(string setupfilename, StockIndexes stockindexes, Stocks stocks) : base()
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
                Load();
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

        public void Load()
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
                                stock = new Stock(xmlchildnode.Attributes["stockid"].Value, xmlchildnode.FirstChild.Value, stockindex);
                                Stocks.Add(stock.Id, stock);
                            }
                        }
                        else if (xmlchildnode.HasChildNodes)
                        {
                            stock.AddStockIndex(stockindex);
                        }
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
