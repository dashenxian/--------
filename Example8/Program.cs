using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example8
{
    class Program
    {
        static void Main(string[] args)
        {
            // //8.1 不可变集合
            // var stack = ImmutableStack<int>.Empty;
            //var stack1 = stack.Push(13);
            // stack = stack.Push(7);
            // foreach (var item in stack1)
            // {
            //     Console.WriteLine(item);
            // }
            // Console.ReadKey();

            ////8.2
            //var list = ImmutableList<int>.Empty;
            //list= list.Add(1);
            //list.Insert(0, 10);//返回新值
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();

            ////8.3
            //var hash = ImmutableHashSet<int>.Empty;
            //hash = hash.Add(13);
            //hash = hash.Add(7);
            //hash = hash.Add(12);
            //foreach (var item in hash)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();

            ////8.5
            //var dic = new ConcurrentDictionary<string, int>();
            //dic.AddOrUpdate("xiaoming", 10, (name, old) => 11);
            //dic.AddOrUpdate("xiaoming", 10, (name, old) => 11);
            //Console.WriteLine(dic["xiaoming"]);
            //Console.ReadKey();

            
        }
    }
}
