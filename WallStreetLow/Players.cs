﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Players : System.Collections.Generic.List<Player>, IResetable
    {
        public Players() : base()
        {
        }

        public void Reset()
        {
            try
            {
                if (this.Count > 0)
                {
                    foreach (IResetable r in this)
                    {
                        r.Reset();
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
