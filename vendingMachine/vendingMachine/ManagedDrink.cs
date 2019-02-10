using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachine
{
    class ManagedDrink
    {
        public static Drink Cola = new Drink("コーラ", 120);

        private List<Drink> _dorinks = new List<Drink> { Cola, Cola, Cola, Cola, Cola };


        public List<Drink> AllDrinks()
        {
            return _dorinks;
        }

        public int DrinksCount(String name)
        {
            int count = 0;
            foreach (Drink drink in _dorinks)
            {
                if (drink.Name == name)
                {
                    count++;
                }
            }
            return count;
        }

        public void Reduce(Drink drink)
        {
            _dorinks.Remove(drink);
        }
    }

    class Drink
    {
        private string _name;
        public String Name
        {
            get { return _name; }
        }
        private int _price;
        public int Price
        {
            get { return _price; }
        }

        public Drink(string name, int price)
        {
            _name = name;
            _price = price;
        }
    }
}
