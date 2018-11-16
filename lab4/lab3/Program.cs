using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {

            String a = new String("Orsha - my city");
            Console.WriteLine($"{a.publishDate.PublishDate}");
            a.owner.Name = "Orsha";
            a.owner.Organization = "PHP";
            Console.WriteLine($"{a.Str}, {a.CountWords}, {a.CurrentLength}, {a.DisplayWord(a.SplitString(), 2)}, {a.owner.Id}, {a.owner.Organization}");
            a.CurrentLength = 3;
            a.CountWords = 8;
            Console.WriteLine($"{a.CountWords}, {a.CurrentLength}, {a.DisplayWord(a.SplitString(), 2)}");

            String b = new String("Minsk, is the -capital of, Belarus!!");
            b.owner.Name = "Minsk";
            b.owner.Organization = "PH";
            Console.WriteLine($"{b.Str}, {b.CountWords}, {b.CurrentLength}, {b.DisplayWord(b.SplitString(), 2)}");

            Console.WriteLine(a < b);
            String c = a + 21;
            c.owner.Name = "Mins";
            c.owner.Organization = "P";
            Console.WriteLine(c.publishDate.PublishDate);
            Console.WriteLine(b.publishDate.PublishDate);
            Console.WriteLine($"{c.Str}, {c.CountWords}, {c.CurrentLength}, {c.DisplayWord(c.SplitString(), 2)}");
            String d = -b;
            d.owner.Name = "M";
            d.owner.Organization = "HP";
            Console.WriteLine($"{d.Str}, {d.CountWords}, {d.CurrentLength}, {d.DisplayWord(d.SplitString(), 2)}");
            String e = b*'b';
            e.owner.Name = "k";
            e.owner.Organization = "PP";
            Console.WriteLine($"{e.Str}, {e.CountWords}, {e.CurrentLength}, {e.DisplayWord(e.SplitString(), 2)}, {a.owner.Id}, {a.owner.Organization}");
            b.RemovePunctuationMarks();
            Console.WriteLine(b.AvailabilityServiceCharacters());
            Console.WriteLine(MathObj.LengthDifference(a, b));
            MathObj.Null(a);
            Console.WriteLine($"{a.CountWords}, {a.CurrentLength}, {a.DisplayWord(a.SplitString(), 2)}");
            Console.WriteLine($"{a.HashCode()}");

            Console.ReadKey();

        }
    }
}
