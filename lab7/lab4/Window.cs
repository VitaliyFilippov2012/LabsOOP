using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Counter
    {
        private Counter() { }
        public static int currentCount=0;
        public static void IncrementCount()
        {
            ++currentCount;
        }

    }
    class Window : ControlElement, IDecor
    {
        int sizeX;
        int sizeY;
        int square;
        int freeSquare;
        public int FreeSquare
        {
            get => freeSquare;
            set => freeSquare = value;
        }
        new public int SizeX
        {
            get => this.sizeX;
            set
            {
                if (value == 0)
                {
                    throw new NegativeExceptions("Ширина не может быть 0");
                }
                else
                {
                    this.freeSquare = this.freeSquare + (value * sizeY - this.square);
                    this.sizeX = value;
                    this.square = sizeX * sizeY;
                }
                
            }
        }
        new public int SizeY
        {
            get => this.sizeY;
            set
            {
                if (value == 0)
                {
                    throw new NegativeExceptions("Высота не может быть 0");
                }
                this.freeSquare = this.freeSquare + (value * sizeX - this.square);
                this.sizeY = value;
                this.square = sizeX * sizeY;
            }
        }

        public string NameDecor()
        {
            return "DecorToWindow";

        }
        public Window(int _sizeX = 10, int _sizeY = 10)
        {
            Counter.IncrementCount();
            this.sizeX = _sizeX;
            this.sizeY = _sizeY;
            this.square = _sizeX * sizeY;
            this.freeSquare = this.square;
        }
        public override string Name()
        {
            return "Window";
        }
        public override string ToString()
        {
            return $"{this.Name()}: {Counter.currentCount}";
        }

        public Menu CreateMenu()
        {
            if(this.freeSquare > 15)
            {
                this.freeSquare -= 15;
                return new Menu();
            }
            else
            {
                Console.WriteLine("Недостаточно место для размещения Меню в этом окне, создайте новое окно");
                return null;
            }
        }

        public Button CreateButton()
        {
            if (this.freeSquare > 2)
            {
                this.freeSquare -= 2;
                return new Button();
            }
            else
            {
                Console.WriteLine("Недостаточно место для размещения кнопки в этом окне, создайте новое окно");
                return null;
            }
        }

    }
}
