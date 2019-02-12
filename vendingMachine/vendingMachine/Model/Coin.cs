using System.Collections.Generic;

namespace vendingMachine.Model
{
    sealed public class Coin
    {
        private static readonly List<int> _coins = new List<int> { 10, 50, 100, 500 };
        private int _value = 0;
        public int Value { get => _value; }

        Coin(int coin) => _value = coin;

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
