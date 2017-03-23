using System;

namespace list
{
    internal class MainClass
    {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            var myList = new MyList<int>();

            myList.PushBack(5);
            myList.PushFront(46);
            myList.PushFront(35);
            myList.PushBack(44);

            myList.PopFront();

            Console.WriteLine(myList.Front());
            Console.WriteLine(myList.Back());

            Console.ReadLine();
        }
    }
}
