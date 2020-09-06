using System;
namespace BuilderSample.FactoryPattern
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Factory
    {
        private static int _count = 0;

        public Factory()
        {

        }

        public Person CreatePerson(string name)
        {
            return new Person()
            {
                Id = _count++,
                Name = name
            };
        }
    }
}