using System.Collections.Generic;
using System.Linq;
using vendingMachine.Model;

namespace vendingMachine
{
    sealed class DrinkController
    {
        // TODO 見直し予定
        public static Drink Cola = new Drink("コーラ", 120);
        private List<Drink> _drinks = new List<Drink> { Cola, Cola, Cola, Cola, Cola };

        public List<Drink> AllDrinks() => _drinks;
        public int CountDrink(string name) => _drinks.FindAll(x => x.Name == name).Count();
        public bool Reduce(Drink drink) => _drinks.Remove(drink);
    }
}
