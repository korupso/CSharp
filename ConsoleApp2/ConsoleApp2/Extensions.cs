using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class MyExtensions
    {
        public static void Println<T>(this T val)
        {
            Console.WriteLine(val.ToString());
        }

        public static void Print<T>(this T val)
        {
            Console.Write(val.ToString());
        }

        public static void Println(this List<string> list)
        {
            Console.WriteLine("[" + String.Join(", ", list) + "]");
        }

        public static void Wait()
        {
            Console.ReadLine();
        }
    }
}