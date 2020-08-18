using System;
using BuilderSample.FunctionalBuilder;

namespace BuilderSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new FunctionalBuilder.PersonBuilder();

            var persion = builder.Called("shjung")
                                 .Location("Korea")
                                 .Builder();

            Console.WriteLine(persion);

        }
    }
}
