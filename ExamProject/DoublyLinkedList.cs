using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject
{
    class DoublyLinkedList<T> : ILinkedList<T>, IEnumerable<T>, ISortable, IPrintable where T : IComparable<T>
    {
        public Node<T> FirstNode { get; private set; }
        public Node<T> LastNode { get; private set; }
        
        public void AddLast(T value)
        {
            if (LastNode == null)
            {
                FirstNode = new Node<T>(value, null, null);
                LastNode = FirstNode;
            }
            else if (LastNode.LinkToNextNode == null)
            {
                LastNode.LinkToNextNode = new Node<T>(value, LastNode, null);
                LastNode = LastNode.LinkToNextNode;
            }
        }


        public void AddFirst(T value)
        {
            if (FirstNode == null)
            {
                FirstNode = new Node<T>(value, null, null);
                LastNode = FirstNode;
            }
            else if (FirstNode.LinkToPreviousNode == null)
            {
                FirstNode.LinkToPreviousNode = new Node<T>(value, null, FirstNode);
                FirstNode = FirstNode.LinkToPreviousNode;
            }
        }


        public void RemoveFirst()
        {
            if (FirstNode == null)
            {
                throw new InvalidOperationException("Impossible to delete Item. List is empty");
            }
            else if (FirstNode.LinkToPreviousNode == null)
            {
                FirstNode = FirstNode.LinkToNextNode;
                FirstNode.LinkToPreviousNode = null;
            }
        }


        public void RemoveLast()
        {
            if (LastNode == null)
            {
                throw new InvalidOperationException("Impossible to delete Item. List is empty");
            }
            else if (LastNode.LinkToNextNode == null)
            {
                LastNode = LastNode.LinkToPreviousNode;
                LastNode.LinkToNextNode = null;
            }
        }


        public bool Find(T value)
        {
            Node<T> currentNode = FirstNode;

            if (currentNode != null)
            {
                do
                {
                    if (currentNode.Data.CompareTo(value) != 0)
                    {
                        if (currentNode.LinkToNextNode != null)
                        {
                            currentNode = currentNode.LinkToNextNode;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                } while (true);
            }
            else
            {
                return false;
            }
        }

        
        public void Remove(T value)
        {
            Node<T> currentNode = FirstNode;
            do
            {
                if (currentNode.Data.CompareTo(value) == 0)
                {
                    if (currentNode.LinkToPreviousNode == null && currentNode.LinkToNextNode == null)
                    {
                        currentNode = null;
                        FirstNode = LastNode = currentNode;
                    }
                    if (currentNode.LinkToPreviousNode == null && currentNode.LinkToNextNode != null)
                    {
                        currentNode.LinkToNextNode.LinkToPreviousNode = null;
                        FirstNode = currentNode.LinkToNextNode;
                    }
                    if (currentNode.LinkToPreviousNode != null && currentNode.LinkToNextNode == null)
                    {
                        currentNode.LinkToPreviousNode.LinkToNextNode = null;
                        LastNode = currentNode.LinkToPreviousNode;
                    }
                    else
                    {
                        currentNode.LinkToPreviousNode.LinkToNextNode = currentNode.LinkToNextNode;
                        currentNode.LinkToNextNode.LinkToPreviousNode = currentNode.LinkToPreviousNode;
                    }
                }
                currentNode = currentNode.LinkToNextNode;
            } while (currentNode != null);
        }


        //public void AnotherRemove(T value)
        //{
        //    Node<T> currentNode = FirstNode;
        //    while (currentNode != null)
        //    {
        //        if (currentNode.Data.CompareTo(value) == 0)
        //        {
        //            if (currentNode.LinkToPreviousNode == null)
        //            {
        //                FirstNode = currentNode.LinkToNextNode;
        //                if (FirstNode != null)
        //                    FirstNode.LinkToPreviousNode = null;
        //            }
        //            else
        //            {
        //                currentNode.LinkToPreviousNode.LinkToNextNode = currentNode.LinkToNextNode;
        //            }

        //            if (currentNode.LinkToNextNode == null)
        //            {
        //                LastNode = currentNode.LinkToPreviousNode;
        //                if (LastNode != null)
        //                    LastNode.LinkToNextNode = null;
        //            }
        //            else
        //            {
        //                currentNode.LinkToNextNode.LinkToPreviousNode = currentNode.LinkToNextNode;
        //            }
        //            break;
        //        }
        //        currentNode = currentNode.LinkToNextNode;
        //    }
        //}


        public int Length()
        {
            int i = 0;
            Node<T> currentNode = FirstNode;
            if (currentNode == null)
            {
                return i;
            }
            else
            {
                i = 0;
                while (currentNode != null)
                {
                    currentNode = currentNode.LinkToNextNode;
                    i++;
                }
            }
            return i;
        }


        public void Print()
        {
            Node<T> currentNode = FirstNode;
            if (currentNode == null)
            {
                Console.WriteLine("List is empty.");
            }
            else
            {
                do
                {
                    Console.Write("{0} ", currentNode.Data);
                    currentNode = currentNode.LinkToNextNode;
                } while (currentNode != null);
                Console.WriteLine();
            }
        }

        
        public Node<T> First()
        {
            return FirstNode;
        }


        public Node<T> Last()
        {
            return LastNode;
        }


        public void Sort()
        {
            int length = Length();

            for (int i = 1; i <= length; i++)
            {
                Node<T> currentNode = FirstNode;
                do
                {
                    if (currentNode.Data.CompareTo(currentNode.LinkToNextNode.Data) > 0)
                    {
                        SwapLinks(ref currentNode.Data, ref currentNode.LinkToNextNode.Data);
                    }

                    Console.Write("internal steps of Sorting: ");
                    Print();
                    currentNode = currentNode.LinkToNextNode;

                } while (currentNode.LinkToNextNode != null);
            }
        }


        public void SwapLinks(ref T data1, ref T data2)
        {
            T temp = data1;
            data1 = data2;
            data2 = temp;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this.FirstNode);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



    }
}
