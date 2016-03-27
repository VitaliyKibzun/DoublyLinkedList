using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(10);
            list.AddLast(8);
            list.AddLast(7);
            list.AddFirst(11);
            list.AddFirst(43);
            list.Print();
            //list.RemoveFirst();
            //list.RemoveLast();
            Console.WriteLine(list.Find(12).ToString());
            //list.Remove(12);
            //Console.WriteLine(list.Find(12).ToString());
            Console.WriteLine(list.Lenght().ToString());
            list.Print();
            list.Remove(9);
            list.Print();
            Console.WriteLine(list.Lenght().ToString());
            list.Sort();
            list.Print();

            Console.ReadKey();
        }
    }
}
