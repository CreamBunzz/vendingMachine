using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachine
{
    public class ManagedMoney
    {
        private int _total;
        public int Total
        {
            get { return _total; }
        }
        private int _profit;
        public int Profit
        {
            get { return _profit; }
        }

        public ManagedMoney()
        {
            _total = 0;
            _profit = 0;
        }

        public void PutMoney(Coin coin)
        {
            _total += coin.Value;
        }

        public int Refund()
        {
            int t = _total;
            _total = 0;
            return t;
        }
        public void Reduce(int money)
        {
            _total -= money;
        }
        public void Add(int money)
        {
            _profit += money;
        }
    }

    public class Coin
    {
        private static List<int> _coins = new List<int> { 10, 50, 100, 500 };
        private int _value;
        public int Value
        {
            get { return _value; }
        }

        Coin(int coin)
        {
            _value = coin;
        }

        public static Coin Create(int coin)
        {
            if (_coins.Contains(coin))
            {
                return new Coin(coin);
            }
            else
            {
                throw new System.ArgumentException(coin.ToString());
            }
        }
    }
}
