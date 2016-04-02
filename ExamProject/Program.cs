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
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            

            list.AddLast(10);
            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            list.AddLast(8);
            list.AddLast(9);

            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            list.AddFirst(10);
            list.AddFirst(43);
            list.Print();
            list.Remove(100);
            list.Print();
            //list.RemoveFirst();
            //list.RemoveLast();
            Console.WriteLine(list.Find(12).ToString());
            //list.Remove(12);
            //Console.WriteLine(list.Find(12).ToString());
            Console.WriteLine(list.Length().ToString());
            list.Print();
            list.Remove(10);
            list.Print();
            //list.AnotherRemove(9);
            list.Print();
            //list.AnotherRemove(10);
            //list.AnotherRemove(0);
            list.Print();
            Console.WriteLine(list.Length().ToString());
            list.Sort();
            list.Print();
            Console.WriteLine(list.FirstNode.Data);
            

            Console.ReadKey();
        }
    }
}
