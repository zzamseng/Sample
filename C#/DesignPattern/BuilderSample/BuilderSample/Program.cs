using System;

namespace BuilderSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var htmlBuilder = new HtmlBuilder("html");

            
            htmlBuilder.AppendElement("body", "nothing")
                   .AppendElement("element", "nothing");

            Console.WriteLine(htmlBuilder.ToString());


            //fluent builder
            var person = Person.New.Called("Manager").WorkAsA("Korea").Build();

            Console.WriteLine(person);
            // 
        }
    }
}
