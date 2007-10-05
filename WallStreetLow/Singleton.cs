using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public sealed class Singleton : System.Object
    {
        private static Singleton _Instance = null;
        private static readonly System.Object _Padlock = new System.Object();

        public Singleton() : base()
        {
        }

        public static Singleton Instance
        {
            get
            {
                lock (_Padlock)
                {
                    if (_Instance == null)
                    {
                        _Instance = new Singleton();
                    }
                    return _Instance;
                }
            }
        }
    }
}
