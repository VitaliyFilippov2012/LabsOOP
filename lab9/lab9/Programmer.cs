using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class Programmer
    {
        public event EventHandler Rename;
        public event EventHandler NewProperty;

        private string name;

        public Programmer(string name)
        {
            this.name = name;
        }

        public void CommandAddOperation()
        {
            NewProperty?.Invoke(this, null);
        }

        public void CommandRenOperation()
        {
            Rename?.Invoke(this, null);
        }
    }
}
