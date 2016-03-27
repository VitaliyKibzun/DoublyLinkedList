using System;

namespace ExamProject
{
    class LinkedList<T> : ILinkedList<T>, ISortable, IPrintable where T : IComparable<T>
    {
        public Node<T> firstNode = null;
        public Node<T> lastNode = null;


        public void AddLast(T value)
        {
            if (lastNode == null)
            {
                firstNode = new Node<T>(value, null, null);
                lastNode = firstNode;
            }
            else if (lastNode.LinkToNextNode == null)
            {
                lastNode.LinkToNextNode = new Node<T>(value, lastNode, null);
                lastNode = lastNode.LinkToNextNode;
            }
        }


        public void AddFirst(T value)
        {
            if (firstNode == null)
            {
                firstNode = new Node<T>(value, null, null);
                lastNode = firstNode;
            }
            else if (firstNode.LinkToPreviousNode == null)
            {
                firstNode.LinkToPreviousNode = new Node<T>(value, null, firstNode);
                firstNode = firstNode.LinkToPreviousNode;
            }
        }


        public void RemoveFirst()
        {
            if (firstNode == null)
            {
                throw new InvalidOperationException("Impossible to delete Item. List is empty");
            }
            else if (firstNode.LinkToPreviousNode == null)
            {
                firstNode = firstNode.LinkToNextNode;
                firstNode.LinkToPreviousNode = null;
            }
        }


        public void RemoveLast()
        {
            if (lastNode == null)
            {
                throw new InvalidOperationException("Impossible to delete Item. List is empty");
            }
            else if (lastNode.LinkToNextNode == null)
            {
                lastNode = lastNode.LinkToPreviousNode;
                lastNode.LinkToNextNode = null;
            }
        }


        public bool Find(T value)
        {
            Node<T> currentNode = firstNode;

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
            Node<T> currentNode = firstNode;
            do
            {
                if (currentNode.Data.CompareTo(value) != 0)
                {
                    if (currentNode.LinkToNextNode == null)
                    {
                        Console.WriteLine("Value wasn't removed because doesn't exist in the list.");
                        currentNode = currentNode.LinkToNextNode;
                    }
                    else
                    {
                        currentNode = currentNode.LinkToNextNode;
                    }
                }
                else
                {
                    if (currentNode.LinkToPreviousNode == null && currentNode.LinkToNextNode == null)
                    {
                        currentNode = null;
                        firstNode = lastNode = currentNode;
                        break;
                    }
                    if (currentNode.LinkToPreviousNode == null && currentNode.LinkToNextNode != null)
                    {
                        currentNode.LinkToNextNode.LinkToPreviousNode = null;
                        firstNode = currentNode.LinkToNextNode;
                        currentNode = null;
                        break;
                    }
                    if (currentNode.LinkToPreviousNode != null && currentNode.LinkToNextNode == null)
                    {
                        currentNode.LinkToPreviousNode.LinkToNextNode = null;
                        lastNode = currentNode.LinkToPreviousNode;
                        currentNode = null;
                        break;
                    }
                    else
                    {
                        currentNode.LinkToPreviousNode.LinkToNextNode = currentNode.LinkToNextNode;
                        currentNode.LinkToNextNode.LinkToPreviousNode = currentNode.LinkToPreviousNode;
                        currentNode = null;
                        break;
                    }
                }
            } while (currentNode != null);
        }


        public int Lenght()
        {
            int i = 0;
            Node<T> currentNode = firstNode;
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
            Node<T> currentNode = firstNode;
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
            return firstNode;
        }


        public Node<T> Last()
        {
            return lastNode;
        }


        public void Sort()
        {
            int length = Lenght();

            for (int i = 1; i <= length; i++)
            {
                Node<T> currentNode = firstNode;
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

    }


    public class Node<T>
    {
        public T Data;
        public Node<T> LinkToNextNode;
        public Node<T> LinkToPreviousNode;

        public Node(T data,  Node<T> linkToPreviousNode, Node<T> linkToNextNode)
        {
            Data = data;
            LinkToPreviousNode = linkToPreviousNode;
            LinkToNextNode = linkToNextNode;
        }
     }
}

