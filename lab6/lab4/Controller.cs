using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Controller
    {
        public static void FindAllButton(Container container)
        {
            Container ButArr = new Container();
            for (int i = 0; i < container.ListControleElements.LongCount(); ++i)
            {
                if ((container.ListControleElements.ElementAt(i) is Button) && !(container.ListControleElements.ElementAt(i) is Menu))
                {
                    ButArr.AddElement(container.ListControleElements.ElementAt(i));
                }
            }

            ButArr.Show();
        }
        public static void FindMenuBylevel(Container container, int level)
        {
            Container MenuArr = new Container();
            for (int i = 0; i < container.ListControleElements.LongCount(); ++i)
            {
                if (container.ListControleElements.ElementAt(i) is Menu)
                {
                    Menu m = container.ListControleElements.ElementAt(i) as Menu;
                    if (m.CountLevel == level)
                    {
                        MenuArr.AddElement(container.ListControleElements.ElementAt(i));
                    }
                   
                }
            }
            MenuArr.Show();
        }


    }
}
