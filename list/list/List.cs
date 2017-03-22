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
            Node<R> next;
            Node<R> prev;
            R data;
        }

        private Node<T> mHead;
        private Node<T> mTail;
        private int mSize;

        public void PushBack(T data)
        {
            throw new NotImplementedException();
        }

        public void PushFront(T data)
        {
            throw new NotImplementedException();
        }

        public T PopBack()
        {
            throw new NotImplementedException();
        }

        public T PopFront(string sampleParam)
        {
            throw new NotImplementedException();
        }

        public T Front()
        {
            throw new NotImplementedException();
        }

        public T Back()
        {
            throw new NotImplementedException();
        }

        public int size() {
            return mSize;
        }
    }
}
