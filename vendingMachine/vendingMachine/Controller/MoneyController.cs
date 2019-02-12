using System.Collections.Generic;
using vendingMachine.Model;

namespace vendingMachine
{
    sealed public class MoneyController
    {
        private int _total = 0;
        private int _profit = 0;

        public int Total { get => _total; }
        public int Profit { get => _profit; }
        public void PutMoney(Coin coin) => _total += coin.Value; 
        public void Add(int money) => _profit += money; 
        public void Reduce(int money) => _total -= money; 
        public int BackTotal()
        {
            int t = _total;
            _total = 0;
            return t;
        }
    }

   
}
