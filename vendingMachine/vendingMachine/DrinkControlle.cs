using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachine
{
    sealed class DrinkController
    {
        // TODO 見直し予定
        public static Drink Cola = new Drink("コーラ", 120);
        private List<Drink> _drinks = new List<Drink> { Cola, Cola, Cola, Cola, Cola };

        public List<Drink> AllDrinks() => _drinks;
        public int CountDrink(String name) => _drinks.FindAll(x => x.Name == name).Count();
        public bool Reduce(Drink drink) => _drinks.Remove(drink);
    }

    // TODO 見直し予定
    sealed public class Drink
    {
        private string _name;
        private int _price = 0;

        public String Name { get => _name; }
        public int Price { get => _price; }
        public Drink(string name, int price)
        {
            _name = name;
            _price = price;
        }
    }
}
