using System;

namespace ExamProject
{
    public class Node<T>
    {
        public T Data;
        public Node<T> LinkToNextNode { get; set; }
        public Node<T> LinkToPreviousNode { get; set; }
    

        public Node(T data,  Node<T> linkToPreviousNode, Node<T> linkToNextNode)
        {
            Data = data;
            LinkToPreviousNode = linkToPreviousNode;
            LinkToNextNode = linkToNextNode;
        }
     }
}

