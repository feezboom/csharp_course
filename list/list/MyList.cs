using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

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

    internal class MyList<T> : IEnumerable<T>, IMyList<T>
    {
        private class Node<TR>
        {
            public Node<TR> Next;
            public Node<TR> Prev;
            public readonly TR Data;
            public Node(Node<TR> prev, Node<TR> next, TR data)
            {
                Data = data;
                Next = next;
                Prev = prev;
            }
        }

        private Node<T> _mHead;
        private Node<T> _mTail;
        private int _mSize;

        public MyList()
        {
            _mHead = null;
            _mTail = null;
            _mSize = 0;
        }

        public void PushBack(T data)
        {
            if (_mTail == null)
            {
                Debug.Assert(_mHead == null);
                CreateTheOnlyElement(data);
            }
            else
            {
                var node = new Node<T>(_mTail, null, data);
                _mTail.Next = node;
                _mTail = node;
            }

            _mSize++;
        }

        public void PushFront(T data)
        {
            if (_mHead == null)
            {
                Debug.Assert(_mSize == 0);
                CreateTheOnlyElement(data);
            }
            else
            {
                Debug.Assert(_mSize > 0);
                Debug.Assert(_mHead != null && _mTail != null);
                var node = new Node<T>(null, _mHead, data);
                _mHead.Prev = node;
                _mHead = node;
            }

            _mSize++;
        }

        public T PopBack()
        {
            if (_mSize == 0)
            {
                Debug.Assert(_mHead == null && _mTail == null);
                throw new InvalidOperationException();
            }

            T retVal;
            if (_mHead == _mTail)
            {
                Debug.Assert(_mSize == 1);
                retVal = RemoveTheOnlyElement();
            }
            else
            {
                Debug.Assert(_mSize > 1);
                retVal = _mTail.Data;
                _mTail = _mTail.Prev;
                _mTail.Next = null;
            }

            _mSize--;
            return retVal;
        }

        public T PopFront()
        {
            if (_mSize == 0)
            {
                Debug.Assert(_mHead == null && _mTail == null);
                throw new InvalidOperationException();
            }

            Debug.Assert(_mHead != null && _mTail != null);

            T retVal;
            if (_mHead == _mTail)
            {
                Debug.Assert(_mSize == 1);
                Debug.Assert(_mHead != null);
                retVal = RemoveTheOnlyElement();
            }
            else
            {
                Debug.Assert(_mHead != null && _mTail != null);
                Debug.Assert(_mHead.Next != null);
                Debug.Assert(_mSize > 1);
                retVal = _mHead.Data;
                _mHead = _mHead.Next;
                _mHead.Prev = null;
            }

            _mSize--;
            return retVal;
        }

        public T Front()
        {
            if (_mSize == 0)
            {
                throw new InvalidOperationException();
            }

            return _mHead.Data;
        }

        public T Back()
        {
            if (_mSize == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return _mTail.Data;
            }
        }

        public int Size() {
            return _mSize;
        }

        private void CreateTheOnlyElement(T data)
        {
            System.Diagnostics.Debug.Assert(_mHead == null);
            System.Diagnostics.Debug.Assert(_mTail == null);

            var node = new Node<T>(null, null, data);
            _mHead = node;
            _mTail = node;

        }

        private T RemoveTheOnlyElement()
        {
            System.Diagnostics.Debug.Assert(_mHead == _mTail);

            var retValue = _mHead.Data;
            _mHead = null;
            _mTail = null;

            return retValue;
        }



        private class Enumerator<TR> : IEnumerator<TR>
        {
            private Node<TR> _node;
            private readonly Node<TR> _head;
            private bool _beforeBegin;

            public Enumerator(Node<TR> node, bool beforeBegin = false, Node<TR> head = null)
            {
                _node = node;
                _beforeBegin = beforeBegin;
                _head = beforeBegin ? head : FindHeadNode(node);
                Debug.Assert(_head != null);
            }

            private static Node<TR> FindHeadNode(Node<TR> someNode)
            {
                if (someNode == null)
                {
                    return null;
                }
                while (someNode.Next != null)
                {
                    someNode = someNode.Next;
                }

                return someNode;
            }


            public TR Current
            {
                get
                {
                    if (_node == null)
                    {
                        throw new InvalidOperationException();
                    }

                    return _node.Data;
                }
            }

            object IEnumerator.Current => this;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (_beforeBegin)
                {
                    Debug.Assert(_node == null);
                    _node = _head;
                    _beforeBegin = false;
                    return true;
                }

                if (_node == null)
                {
                    return false;
                }

                _node = _node.Next;
                return true;
            }

            public void Reset()
            {
                _beforeBegin = true;
                _node = null;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(_mHead);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator<T>(_mHead);
        }
    }
}
