using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Container
    {
        private List<ControlElement> _listControleElements;

        public List<ControlElement> ListControleElements
        {
            get => _listControleElements;
            set => _listControleElements = value;
        }

        public Container()
        {
            _listControleElements = new List<ControlElement>();
        }

        public Container(params ControlElement[] controlElements) : this()
        {
            foreach (ControlElement controleElement in controlElements)
            {
                _listControleElements.Add(controleElement);
            }
        }

        public Container(List<ControlElement> listControlElements)
        {
            _listControleElements = listControlElements;
        }

        public void AddElement(ControlElement obj)
        {
            _listControleElements.Add(obj);
        }

        public bool DeleteElement(int position)
        {
            if (_listControleElements.LongCount() > position)
            {
                _listControleElements.RemoveAt(position);
            }
            return _listControleElements.LongCount() > position;
        }

        public void Show()
        {
            Console.WriteLine("-------------------------------------------");

            if (_listControleElements.LongCount() == 0)
            {
                Console.WriteLine("List has not element");
            }
            else
            {

                foreach(ControlElement item in _listControleElements)
                {
                    Console.WriteLine($"- {item.ToString()}");
                }
            }
            Console.WriteLine("-------------------------------------------");

        }
    }
}
