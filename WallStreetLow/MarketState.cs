using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public enum MarketStateType
    {
        Normal = 0,
        Depression = 1,
        Boom = 2
    }

    public class MarketState : System.Object, IResetable
    {
        private MarketStateType _State = MarketStateType.Normal;
        private int _Epochs = 0;

        public MarketState() : base()
        {
            try
            {
                Reset(null);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public MarketStateType State
        {
            get
            {
                return _State;
            }
            private set
            {
                _State = value;
            }
        }

        public int Epochs
        {
            get
            {
                return _Epochs;
            }
            private set
            {
                _Epochs = value;
            }
        }

        public void Reset(System.Random random)
        {
            try
            {
                State = MarketStateType.Normal;
                Epochs = 0;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
