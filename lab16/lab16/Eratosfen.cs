using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab16
{
    public class Eratosfen
    {
        List<int> simple;

        public Eratosfen(int MaxNumber)
        {
            simple = new List<int>();
            for (int i = 1; i < MaxNumber; i++)
                simple.Add(i);
            DoEratosfen();
        }

        void Step(int Prime, int startFrom)
        {
            int i = startFrom + 1;
            while (i < simple.Count)
                if (simple[i] % Prime == 0)
                {
                    simple.RemoveAt(i);
                }
                else
                {
                    ++i;
                }
                    
        
        }

        void DoEratosfen()
        {
            int i = 1;
            while (i < simple.Count)
            {
                Step(simple[i], i);
                i++;
            }
        }

        public static void DoEratosfen(int maxNumber)
        {
            Eratosfen d = new Eratosfen(maxNumber);
            using(StreamWriter sw = new StreamWriter(@"E:\Универ\ООП\Лабы\Eratosfen.txt", false, Encoding.UTF8))
            {
                foreach (int n in d.Simple)
                {
                    sw.Write($"{n} ");
                }
            }
            
        }

        public int[] Simple
        {
            get
            {
                return simple.ToArray();
            }
        }

    }
}
