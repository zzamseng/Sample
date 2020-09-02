using System;
namespace BuilderSample.Fluent
{
    public class Person
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public override string ToString() => $"Name: {Name} -- Location:{Location}";


        public class Builder : PersonJobBuilder<Builder> { }
        public static Builder New => new Builder();
    }

    public abstract class PersonBuilder
    {
        protected Person Person = new Person();

        public Person Build() => Person;
    }

    public class PersonInfoBuilder<T>
        : PersonBuilder
        where T:PersonInfoBuilder<T>
    {
        public T Called(string name)
        {
            Person.Name = name;
            return (T)this;
        }
    }

    public class PersonJobBuilder<T>
        : PersonInfoBuilder<PersonJobBuilder<T>>
        where T : PersonJobBuilder<T>
    {
        public T WorkAsA(string location)
        {
            Person.Location = location;
            return (T)this;
        }

    }
}
