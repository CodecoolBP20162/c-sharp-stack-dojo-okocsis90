using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack.Tests
{
    [TestClass()]
    public class GenericStackTests
    {
        [TestMethod()]
        public void GenericStackTest()
        {
            GenericStack<int> myStack = new GenericStack<int>(3);
            Assert.IsNotNull(myStack);
        }

        [TestMethod()]
        public void PushTest_TestValidInput()
        {
            GenericStack<int> myStack = CreateIntStack();
            Assert.AreEqual(" 1 2 3", myStack.ToString());
        }

        [TestMethod()]
        [ExpectedException(typeof(StackOverflowException), "Stack is full. Please remove an element to add one.")]
        public void PushTest_ThrowsExceptionWhenStackIsFull()
        {
            GenericStack<int> myStack = CreateIntStack();
            myStack.Push(4);
        }

        [TestMethod()]
        public void PopTest_PoppedElementIsLast()
        {
            GenericStack<int> myStack = CreateIntStack();
            int popped = myStack.Pop();
            Assert.AreEqual(3, popped);
        }

        [TestMethod()]
        public void PopTest_PoppedElementIsRemoved()
        {
            GenericStack<int> myStack = CreateIntStack();
            myStack.Pop();
            Assert.AreEqual(" 1 2", myStack.ToString());
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Stack is empty, cannot Pop any elements.")]
        public void PopTest_ThrowsExceptionWhenLengthIsZero()
        {
            GenericStack<int> myStack = CreateIntStack();
            myStack.Pop();
            myStack.Pop();
            myStack.Pop();
            myStack.Pop();
        }

        [TestMethod()]
        public void PeekTest_LastElementIsShown()
        {
            GenericStack<int> myStack = CreateIntStack();
            int lastElem = myStack.Peek();
            Assert.AreEqual(3, lastElem);
        }

        [TestMethod()]
        public void PeekTest_LastElementIsNotRemoved()
        {
            GenericStack<int> myStack = CreateIntStack();
            int lastElem = myStack.Peek();
            Assert.AreEqual(" 1 2 3", myStack.ToString());
        }

        [TestMethod()]
        public void LengthTest()
        {
            GenericStack<int> myStack = CreateIntStack();
            Assert.AreEqual(3, myStack.Length);
        }

        [TestMethod()]
        public void FreeSpacesTest()
        {
            GenericStack<int> myStack = CreateIntStack();
            Assert.AreEqual(0, myStack.FreeSpaces);
        }

        public GenericStack<int> CreateIntStack()
        {
            GenericStack<int> myStack = new GenericStack<int>(3);
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            return myStack;
        }
    }
}