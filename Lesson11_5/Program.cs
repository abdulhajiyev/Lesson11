using System;
using System.Threading.Channels;

namespace Lesson11_5
{
    class Program
    {
        static void Foo()
        {
            Console.WriteLine("Hakuna");
        }

        static void ExceptionHandling(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        static void Main(string[] args)
        {
            ExceptionHandling(Foo);
        }
    }
}