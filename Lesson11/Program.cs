using System;

namespace Lesson11
{
    class A : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Init");
        }
    }
}