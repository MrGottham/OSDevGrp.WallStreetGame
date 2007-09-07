using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public abstract class Communicator : System.Object
    {
        public Communicator() : base()
        {
        }

        protected abstract void Communication(System.Net.Sockets.Socket socket);
    }
}
