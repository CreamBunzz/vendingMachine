using System;
using vendingMachine.Model;

namespace vendingMachine
{
    sealed public class Controller
    {
        private readonly MoneyController moneyController = new MoneyController();
        private readonly DrinkController dringController = new DrinkController();

        public void Run() => SelectMode();
        // TODO 見直し予定
        private void SelectMode()
        {
            while (true)
            {
                try
                {
                    switch (Utils.ReadAndWrite("お金投入:1,払い戻し:2, 選択:3, コーラ購入:4, 売上:99, 自販機終売(終了): exit"))
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
                            switch (Buy(moneyController.Total, DrinkController.Cola))
                            {
                                case 0:
                                    Console.WriteLine("コーラ1本買えましたよー");
                                    break;
                                case 1:
                                    Console.WriteLine("お金が足りてないぞい");
                                    break;
                                case 2:
                                    Console.WriteLine("在庫切れ");
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "5":
                            switch (Buy(moneyController.Total, DrinkController.Cola))
                            {
                                case 0:
                                    Console.WriteLine("コーラ1本買えましたよー");
                                    break;
                                case 1:
                                    Console.WriteLine("お金が足りてないぞい");
                                    break;
                                case 2:
                                    Console.WriteLine("在庫切れ");
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "99":
                            Console.WriteLine("ハッピー金額:" + moneyController.Profit + "円");
                            break;
                        case "exit":
                            Console.WriteLine("売上金額と投入済みの金を持って自販機は爆発する");
                            Console.WriteLine("ハッピー金額:" + (moneyController.Profit + moneyController.Total) + "円");
                            return;
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

        private int Buy(int money, Drink drink)
        {
            if (money < drink.Price) return 1;
            if (dringController.CountDrink(drink.Name) <= 0) return 2;
            if ((money >= drink.Price) && (dringController.CountDrink(drink.Name) > 0))
            {
                dringController.Reduce(drink);
                moneyController.ReduceMoney(drink.Price);
                moneyController.AddProfit(drink.Price);
            }
            return 0;
        }
    }
}
