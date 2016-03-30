using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject
{
    public interface ILinkedList<T>
    {
        void AddFirst(T value);
        void AddLast(T Value);
        void Remove(T value);
        void RemoveFirst();
        void RemoveLast();
        bool Find(T value);
        int Length();
        Node<T> First();
        Node<T> Last();
    }
}
