using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Counter 
    {
        private Counter() {}//Закрытый конструктор класса счётчик
        public static int currentCount;
        public static void IncrementCount()
        {
            ++currentCount;
        }

    }

    public partial class Product  //Класс продукты
    {
        readonly int id;
        string name;
        long upc;
        string producer;
        float price;
        float purchasePrice;
        const int shelfLife = 30;
        int amount;
        public static int counter;
        //Методы

        public override bool Equals(object obj)
        {
            return (bool)((obj as Product).Amount* (obj as Product).price == amount*price);
        }
        public override int GetHashCode()
        {
            return (int)((Id*upc*price)/amount);
        }

        public override string ToString()
        {
            return ($"Класс Продукты состоит из полей:\nID-{id}\nNAME-{name}\nUPC-{upc}\nProducer-{producer}\nPrice-{price}\nShelf life-{shelfLife}\nPurchase price-{purchasePrice}\nAmount-{amount}");
        }
        public string ToStr()
        {
            return ($"{id}\t{name}\t{upc}\t{producer}\t\t{price}\t{shelfLife}\t\t{purchasePrice}\t\t{amount}");
        }
        public static void Info()
        {
            Console.WriteLine("ID\tNAME\tUPC\t\tProducer\tPrice\tShelf life\tPurchase price\tAmount");
        }

        public void Proceeds(ref int rounding, out double proc, out double priceAm)
        {
            priceAm = Math.Round((amount * price), rounding);
            proc = priceAm - Math.Round((amount * purchasePrice), rounding);
        }


        //get && set
        public int Id
        {
            get
            {
                return id;
            }
        }

        public int ShelfLife
        {
            get
            {
                return shelfLife;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public long UPC
        {
            get
            {
                return upc;
            }
            set
            {
                upc = value;
            }
        }

        public string Producer
        {
            get
            {
                return producer;
            }
            set
            {
                producer = value;
            }
        }

        public float Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0.0f)
                {
                    price = value * (-1);
                }
                if (value > 10.0f)
                {
                    price = 10.0f;
                }

            }
        }
        public float PurchasePrice
        {
            get
            {
                return purchasePrice;
            }
            set
            {
                purchasePrice = value;
            }
        }
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }
    }
}
