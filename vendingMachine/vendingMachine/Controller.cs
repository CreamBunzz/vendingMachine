using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachine
{
    class Controller
    {
        ManagedMoney managedMoney = new ManagedMoney();
        ManagedDrink managedDrink = new ManagedDrink();

        public void run()
        {
            Message Msg = new Message();
            Console.WriteLine(Msg.hellow);
            for (; ; )
            {
                Console.WriteLine("お金投入:1,払い戻し:2, 選択:3, コーラ購入:4, 売上:99");
                String mode = Console.ReadLine();

                try
                {
                    switch (mode)
                    {
                        case "1":
                            Console.WriteLine("投入金額を入力してください(10円・50円・100円・500円)");
                            managedMoney.PutMoney(Coin.Create((Int32.Parse(Console.ReadLine()))));
                            break;
                        case "2":
                            Console.WriteLine("払い戻しした金額だよー：" + managedMoney.Refund() + "円");
                            break;
                        case "3":
                            Console.WriteLine(ManagedDrink.Cola.Name + "(" + ManagedDrink.Cola.Price + "円): " + managedDrink.DrinksCount(ManagedDrink.Cola.Name) + "本");
                            break;
                        case "4":                        
                            Buy(managedMoney.Total, ManagedDrink.Cola);
                            break;
                        case "99":
                            Console.WriteLine("ハッピー金額:" + managedMoney.Profit + "円");
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
                Console.WriteLine("今預かってるお金だよー：" + managedMoney.Total + "円");
            }

            string input2 = Console.ReadLine();
        }

        public void Buy(int money, Drink drink)
        {
            if ((money >= drink.Price) && (managedDrink.DrinksCount(drink.Name) > 0))
            {
                managedDrink.Reduce(drink);
                managedMoney.Reduce(drink.Price);
                managedMoney.Add(drink.Price);
            } 
        }


        class Message
        {
            public string hellow = "ようこそ自動販売機へ！\r\n";

            public Message()
            {
                hellow = "ようこそ自動販売機へ！";
            }
        }
    }
}
