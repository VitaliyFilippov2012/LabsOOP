using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public partial class Product
    {
        //Конструкторы
        public Product() //Конструктор без параметров
        {
            Counter.IncrementCount(); //Счётчик увеличиваем
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
    }
}

