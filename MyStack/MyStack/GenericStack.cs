using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MyStack
{
    public class GenericStack<T>
    {
        public int Length { get; set; }
        public int FreeSpaces { get; set; }

        private T pointer;
        private T[] TArray;

        public GenericStack(int length)
        {
            TArray = new T[length];
            Length = 0;
            FreeSpaces = length;
        }

        public void Push(T elem)
        {
            if (FreeSpaces == 0)
            {
                throw new StackOverflowException("Stack is full. Please remove an element to add one.");
            }
            TArray[Length] = elem;
            pointer = elem;
            Length++;
            FreeSpaces--;
        }

        public T Pop()
        {
            if (Length == 0)
            {
                throw new Exception("Stack is empty, cannot Pop any elements.");
            }
            T result = pointer;
            Length--;
            FreeSpaces++;
            pointer = TArray[Length];
            return result;
        }

        public T Peek()
        {
            return pointer;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Length; i++)
            {
                result += " " + TArray[i];
            }
            return result;
        }
    }
}
