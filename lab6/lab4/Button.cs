﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Button : ControlElement, IDecor
    {
        int sizeX;
        int sizeY;
        string nameOfButton;
        public Button(int _sizeX = 2, int _sizeY = 1)
        {
            nameOfButton = "BV";
            this.sizeX = _sizeX;
            this.sizeY = _sizeY;
        }
        new public int SizeX { get; set; }
        new public int SizeY { get; set; }
        public string NameDecor()
        {
            return "DecorToButton";
        }
        public string NameOfButton
        {
            get => nameOfButton;
            set => nameOfButton = value;
        }
        
        public Button(string name)
        {
            this.nameOfButton = name;
        }

        public override string Name()
        {
            return "Button";
        }

        public override string ToString()
        {
            return $"{this.Name()}: {this.NameOfButton}";
        }
    }
}
