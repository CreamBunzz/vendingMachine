using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachine
{
    sealed public class MoneyController
    {
        private int _total = 0;
        private int _profit = 0;

        public int Total
        {
            get { return _total; }
        }

        public int Profit
        {
            get { return _profit; }
        }

        public void PutMoney(Coin coin)
        {
            _total += coin.Value;
        }

        public void Add(int money)
        {
            _profit += money;
        }

        public void Reduce(int money)
        {
            _total -= money;
        }

        public int BackTotal()
        {
            int t = _total;
            _total = 0;
            return t;
        }
    }

    public class Coin
    {
        private static readonly List<int> _coins = new List<int> { 10, 50, 100, 500 };
        private int _value = 0;

        public int Value
        {
            get { return _value; }
        }

        Coin(int coin)
        {
            _value = coin;
        }

        public static Coin Create(int value)
        {
            if (_coins.Contains(value))
            {
                return new Coin(value);
            }
            else
            {
                throw new System.ArgumentException(value.ToString());
            }
        }
    }
}
