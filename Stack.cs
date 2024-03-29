using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Task_1
{
    public class Stack<T>
    {
        private int _count = 0;
        private Node<T> tail = null;
        private bool isEmpty = true;

        public Stack() { }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = tail;
            tail = newNode;
            isEmpty = false;
            _count++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            T data = tail.Data;
            tail = tail.Next;
            _count--;

            if (tail == null)
            {
                isEmpty = true;
            }

            return data;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return tail.Data;
        }

        public bool IsEmpty() { return isEmpty; }

        public int Count { get { return _count; } }
    }
}
