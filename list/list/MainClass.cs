using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    class MainClass
    {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            MyList<int> myList = new MyList<int>();
            myList.PushBack(5);
        }
    }
}
