using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamProject
{
    class LinkedListEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        private Node<T> _firstNode;

        private Node<T> _currentNode;

        public LinkedListEnumerator(Node<T> firstNode)
        {
            _firstNode = firstNode;
            _currentNode = null;
        }

        public bool MoveNext()
        {
            if (_firstNode == null)
                return false;

            if (_currentNode == null)
            {
                _currentNode = _firstNode;
                Current = _currentNode.Data;
                return true;
            }

            _currentNode = _currentNode.LinkToNextNode;
            if (_currentNode == null)
                return false;

            Current = _currentNode.Data;
            return true;
        }

        public void Reset()
        {
            _currentNode = null;
            Current = default(T);
        }

        public T Current { get; private set; }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
        }
    }

}
