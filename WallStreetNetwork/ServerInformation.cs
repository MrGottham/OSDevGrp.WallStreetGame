using System;
using System.Collections.Generic;
using System.Text;
using OSDevGrp.WallStreetGame;

namespace OSDevGrp.WallStreetGame
{
    public class ServerInformation : System.Object
    {
        private string _Information = null;
        private Version _Version = null;
        private System.Net.EndPoint _EndPoint = null;

        public ServerInformation(string information, Version version, System.Net.EndPoint endpoint) : base()
        {
            try
            {
                Information = information;
                Version = version;
                EndPoint = endpoint;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public string Information
        {
            get
            {
                if (_Information != null)
                    return _Information;
                return String.Empty;
            }
            private set
            {
                _Information = value;
            }
        }

        public Version Version
        {
            get
            {
                return _Version;
            }
            private set
            {
                _Version = value;
            }
        }

        public System.Net.EndPoint EndPoint
        {
            get
            {
                return _EndPoint;
            }
            private set
            {
                _EndPoint = value;
            }
        }
    }
}
