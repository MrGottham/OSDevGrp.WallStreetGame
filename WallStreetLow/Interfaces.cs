﻿using System;
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
        void Load(Version fv, WsgFileStream fs);
    }
}
