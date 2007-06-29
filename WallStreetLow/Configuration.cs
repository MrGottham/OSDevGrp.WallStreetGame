using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Configuration : System.Object 
    {
        private string _SetupFileName = null;
        private StockIndexes _StockIndexes = null;
        private System.Xml.XmlDocument _XmlDocument = null;

        public Configuration(string setupfilename, StockIndexes stockindexes) : base()
        {
            try
            {
                SetupFileName = setupfilename;
                StockIndexes = stockindexes;
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
                if (StockIndexes == null)
                    StockIndexes = new StockIndexes();
                while (StockIndexes.Count > 0)
                    StockIndexes.Clear();
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

                    StockIndexes.Add(xmlnode.Attributes["indexid"].Value, new StockIndex());
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
