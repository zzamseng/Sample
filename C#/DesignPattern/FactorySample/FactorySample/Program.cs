using System;
using BuilderSample.FactoryPattern;

namespace FactorySample
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Factory().CreatePerson("test");

            Console.WriteLine(person);
        }
    }
}
