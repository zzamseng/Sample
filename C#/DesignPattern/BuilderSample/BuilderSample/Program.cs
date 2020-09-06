using System;

namespace BuilderSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new FactoryPattern.Factory().CreatePerson("person");
        }
    }
}
