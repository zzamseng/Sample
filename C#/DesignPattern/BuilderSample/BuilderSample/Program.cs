using System;
using BuilderSample.CodeBuilderTest;

namespace BuilderSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person")
                                    .AddFiled("Name", "string")
                                    .AddFiled("Age", "int");


            Console.WriteLine(cb);
        }
    }
}
