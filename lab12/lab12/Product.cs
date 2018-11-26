using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public class Product : IComparable, IEnumerator
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
        public Product() //Конструктор без параметров
        {
            counter++;
            name = "Buble";
            upc = 234284295;
            producer = "Gorli";
            price = 2.55f;
            purchasePrice = price - 0.5f;
            amount = 2000;
        }

        static Product() //Статический конструктор, вызывается один раз
        {
            counter = 0;
        }

        public Product(int id) : this()//Конструкторы с параметрами
        {
            this.id = id * id;
        }

        public Product(int id, string name) : this(id)
        {
            this.name = name;
        }

        public Product(int id, string name, long upc) : this(id, name)
        {
            this.upc = upc;
        }

        public Product(int id, string name, long upc, float price, string producer = "Minsk", int amount = 62) : this(id, name, upc)//Конструктор с параметрами по умолчанию
        {
            this.producer = producer;
            this.amount = amount;
            this.price = price;
            this.purchasePrice = price - 0.50f;

        }
        //Методы

        public override bool Equals(object obj)
        {
            return (bool)((obj as Product).Amount * (obj as Product).price == amount * price);
        }
        public override int GetHashCode()
        {
            return (int)((Id * upc * price) / amount);
        }

        public override string ToString()
        {
            return ($"\nID-{id}  NAME-{name}  UPC-{upc}  Producer-{producer}  Price-{price}  Purchase price-{purchasePrice}");
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

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
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

        public object Current => throw new NotImplementedException();
    }
}
