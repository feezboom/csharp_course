using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{

    /**
     * Реализовать собственный двусвязный список.
     * Требования к списку:
     * Методы:
     * 
     * PushBack – добавить элемент в конец списка
     * PushFront – добавить элемент в начало списка
     * PopBack – вернуть последний элемент списка и удалить его из коллекции
     * PopFront - вернуть первый элемент списка и удалить его из коллекции
     * Front – возвращает первый элемент списка
     * Back – возвращает последний элемент списка
     * Size – возвращает количество элементов в списке
     * Может работать с любыми типами
     * Если список пуст, то методы PopBack, PopFront, Front, Back генерируют исключение
     * 
     * Дополнение 1: коллекция поддерживает IEnumerable<T>
    */

    class MyList<T>
    {
        private class Node<R>
        {
            public Node<R> next;
            public Node<R> prev;
            public R data;
            public Node(Node<R> prev, Node<R> next, R data)
            {
                this.data = data;
            }
        }

        private Node<T> mHead;
        private Node<T> mTail;
        private int mSize;

        public MyList()
        {
            mHead = null;
            mTail = null;
            mSize = 0;
        }

        public void PushBack(T data)
        {
            if (mTail == null)
            {
                createTheOnlyElement(data);
            }
            else
            {
                Node<T> node = new Node<T>(mTail, null, data);
                mTail.next = node;
            }

            mSize++;
        }

        public void PushFront(T data)
        {
            if (mHead == null)
            {
                createTheOnlyElement(data);
            }
            else
            {
                Node<T> node = new Node<T>(null, mHead, data);
                mHead.prev = node;
            }

            mSize++;
        }

        public T PopBack()
        {
            if (mSize == 0)
            {
                throw new InvalidOperationException();
            }

            T retVal;
            if (mHead == mTail)
            {
                retVal = removeTheOnlyElement();
            }
            else
            {
                retVal = mTail.data;
                mTail.prev.next = null;
                mTail = null;
            }

            mSize--;
            return retVal;
        }

        public T PopFront(string sampleParam)
        {
            if (mSize == 0)
            {
                throw new InvalidOperationException();
            }

            T retVal;
            if (mHead == mTail)
            {
                retVal = removeTheOnlyElement();
            }
            else
            {
                retVal = mHead.data;
                mHead.next.prev = null;
                mHead = null;
            }

            mSize--;
            return retVal;
        }

        public T Front()
        {
            if (mSize == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return mHead.data;
            }
        }

        public T Back()
        {
            if (mSize == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return mTail.data;
            }
        }

        public int size() {
            return mSize;
        }

        private void createTheOnlyElement(T data)
        {
            System.Diagnostics.Debug.Assert(mHead == null);
            System.Diagnostics.Debug.Assert(mTail == null);

            Node<T> node = new Node<T>(null, null, data);
            mHead = node;
            mTail = node;
        }

        private T removeTheOnlyElement()
        {
            System.Diagnostics.Debug.Assert(mHead == mTail);

            T retValue = mHead.data;
            mHead = null;
            mTail = null;

            return retValue;
        }
    }
}
