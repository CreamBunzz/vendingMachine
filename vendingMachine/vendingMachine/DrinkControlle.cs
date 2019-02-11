using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachine
{
    sealed class DrinkController
    {
        public static Drink Cola = new Drink("コーラ", 120);
        private List<Drink> _drinks = new List<Drink> { Cola, Cola, Cola, Cola, Cola };

        public List<Drink> AllDrinks()
        {
            return _drinks;
        }

        public int CountDrink(String name)
        {
            return _drinks.FindAll(x => x.Name == name).Count();
        }

        public void Reduce(Drink drink)
        {
            _drinks.Remove(drink);
        }
    }

    // TODO 見直し予定
    class Drink
    {
        private string _name;
        private int _price = 0;

        public String Name
        {
            get { return _name; }
        }

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
