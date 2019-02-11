using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vendingMachine
{
    sealed public class Controller
    {
        private readonly MoneyController moneyController = new MoneyController();
        private readonly DrinkController dringController = new DrinkController();

        public void Run()
        {
            SelectMode();
        }

        private void SelectMode()
        {
            while (true)
            {
                try
                {
                    switch (Utils.ReadAndWrite("お金投入:1,払い戻し:2, 選択:3, コーラ購入:4, 売上:99"))
                    {
                        case "1":
                            moneyController.PutMoney(Coin.Create((Int32.Parse(Utils.ReadAndWrite("投入金額を入力してください(10円・50円・100円・500円)")))));
                            break;
                        case "2":
                            Console.WriteLine("払い戻しした金額だよー：" + moneyController.BackTotal() + "円");
                            break;
                        case "3":
                            Console.WriteLine(DrinkController.Cola.Name + "(" + DrinkController.Cola.Price + "円): " + dringController.CountDrink(DrinkController.Cola.Name) + "本");
                            break;
                        case "4":
                            Buy(moneyController.Total, DrinkController.Cola);
                            break;
                        case "99":
                            Console.WriteLine("ハッピー金額:" + moneyController.Profit + "円");
                            break;
                        default:
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("ちゃんと入力してやー");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("そのお金うけとれないわ。ほな返すでー：" + e.Message + "円");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine("今預かってるお金だよー：" + moneyController.Total + "円");
            }

        }

        private void Buy(int money, Drink drink)
        {
            if ((money >= drink.Price) && (dringController.CountDrink(drink.Name) > 0))
            {
                dringController.Reduce(drink);
                moneyController.Reduce(drink.Price);
                moneyController.Add(drink.Price);
            }
        }
    }
}
