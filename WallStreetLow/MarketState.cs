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

    public class MarketState : System.Object, IResetable, IPlayable, IStoreable
    {
        private const double BROKERAGE_INITIALIZE = 2.5D;
        private const double MIN_BROKERAGE = 1.0D;
        private const double MAX_BROKERAGE = 5.0D;

        private MarketStateType _State = MarketStateType.Normal;
        private int _Epochs = 0;
        private double _Brokerage = BROKERAGE_INITIALIZE;

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

        public double Brokerage
        {
            get
            {
                return _Brokerage;
            }
            private set
            {
                _Brokerage = value;
                if (_Brokerage < MIN_BROKERAGE)
                    _Brokerage = MIN_BROKERAGE;
                if (_Brokerage > MAX_BROKERAGE)
                    _Brokerage = MAX_BROKERAGE;
            }
        }

        public void Reset(System.Random random)
        {
            try
            {
                State = MarketStateType.Normal;
                Epochs = 0;
                Brokerage = BROKERAGE_INITIALIZE;
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
                int r = 0;
                switch (State)
                {
                    case MarketStateType.Normal:
                        r = random.Next(100);
                        if (r < 10)
                        {
                            State = MarketStateType.Depression;
                            while (Epochs == 0)
                                Epochs = random.Next(20);
                        }
                        else if (r > 90)
                        {
                            State = MarketStateType.Boom;
                            while (Epochs == 0)
                                Epochs = random.Next(20);
                        }
                        r = random.Next(100);
                        if (r < 10 && Brokerage > MIN_BROKERAGE)
                            Brokerage -= 0.25;
                        else if (r > 90 && Brokerage < MAX_BROKERAGE)
                            Brokerage += 0.25;
                        break;
                    case MarketStateType.Depression:
                        if (Epochs > 0)
                        {
                            Epochs -= 1;
                        }
                        else
                        {
                            State = MarketStateType.Normal;
                            Epochs = 0;
                        }
                        r = random.Next(100);
                        if (r < 10 && Brokerage > MIN_BROKERAGE)
                            Brokerage -= 0.25;
                        else if (r > 85 && Brokerage < MAX_BROKERAGE)
                            Brokerage += 0.25;
                        break;
                    case MarketStateType.Boom:
                        if (Epochs > 0)
                        {
                            Epochs -= 1;
                        }
                        else
                        {
                            State = MarketStateType.Normal;
                            Epochs = 0;
                        }
                        r = random.Next(100);
                        if (r < 15 && Brokerage > MIN_BROKERAGE)
                            Brokerage -= 0.25;
                        else if (r > 90 && Brokerage < MAX_BROKERAGE)
                            Brokerage += 0.25;
                        break;
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
                    fs.WriteInt((int) State);
                    fs.WriteInt(Epochs);
                    fs.WriteDouble(Brokerage);
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
                if (fv.Major > 0)
                {
                    State = (MarketStateType) fs.ReadInt();
                    Epochs = fs.ReadInt();
                    Brokerage = fs.ReadDouble();
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
