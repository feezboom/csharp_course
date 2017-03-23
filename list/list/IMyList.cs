using System.Collections.Generic;

namespace list
{
    internal interface IMyList<T>
    {
        T Back();
        T Front();
        IEnumerator<T> GetEnumerator();
        T PopBack();
        T PopFront();
        void PushBack(T data);
        void PushFront(T data);
        int Size();
    }
}