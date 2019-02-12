namespace vendingMachine.Model
{
    // TODO 見直し予定
    sealed public class Drink
    {
        private string _name;
        private int _price = 0;

        public string Name { get => _name; }
        public int Price { get => _price; }
        public Drink(string name, int price)
        {
            _name = name;
            _price = price;
        }
    }
}
