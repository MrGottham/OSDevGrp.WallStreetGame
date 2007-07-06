using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public class Player : System.Object, IResetable
    {
        private const double CAPITAL_INITIALIZE = 100000D;

        private string _Company = null;
        private string _Name = null;
        private bool _IsComputer = true;
        private bool _IsYou = false;
        private Deposit _Deposit = null;
        private DoubleHistory _ValueHistory = null;
        private double _Capital = CAPITAL_INITIALIZE;

        public Player(string company, string name, Stocks stocks) : this(company, name, stocks, true, false)
        {
        }

        public Player(string company, string name, Stocks stocks, bool iscomputer, bool isyou) : base()
        {
            try
            {
                Company = company;
                Name = name;
                IsComputer = iscomputer;
                IsYou = isyou && !IsComputer;
                Deposit = new Deposit(stocks);
                ValueHistory = new DoubleHistory();
                Reset(null);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public string Company
        {
            get
            {
                return _Company;
            }
            set
            {
                _Company = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public bool IsComputer
        {
            get
            {
                return _IsComputer;
            }
            private set
            {
                _IsComputer = value;
            }
        }

        public bool IsYou
        {
            get
            {
                return _IsYou;
            }
            private set
            {
                _IsYou = value;
            }
        }

        public Deposit Deposit
        {
            get
            {
                return _Deposit;
            }
            private set
            {
                _Deposit = value;
            }
        }

        public DoubleHistory ValueHistory
        {
            get
            {
                return _ValueHistory;
            }
            private set
            {
                _ValueHistory = value;
            }
        }

        public double Capital
        {
            get
            {
                return _Capital;
            }
            private set
            {
                if (value < double.MinValue)
                    _Capital = double.MinValue;
                if (value > double.MaxValue)
                    _Capital = double.MaxValue;
                else
                    _Capital = value;
            }
        }

        public double Value
        {
            get
            {
                if (Capital + Deposit.Value < double.MinValue)
                    return double.MinValue;
                else if (Capital + Deposit.Value > double.MaxValue)
                    return double.MaxValue;
                else
                    return Capital + Deposit.Value;
            }
        }

        public void Reset(System.Random random)
        {
            try
            {
                Capital = CAPITAL_INITIALIZE;
                Deposit.Reset(random);
                while (ValueHistory.Count > 0)
                    ValueHistory.Clear();
                ValueHistory.Add(Value);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
