using System;
namespace BuilderSample.Fluent
{
    public class Animal<T>
        where T:Animal<T>
    {

        public string Type { get; set; }
        public int Age { get; set; }

        public T SetType(string type)
        {
            this.Type = type;
            return (T)this;
        }

        public T SetAge(int age)
        {
            this.Age = age;
            return (T)this;
        }

        public override string ToString()
        {
            return $"Type: {Type}, Age:{Age} ";
        }
    }

    public class Human<T>
        : Animal<Human<T>>
        where T:Human<T>
    {
        public string Name { get; set; }

        public T SetName(string name)
        {
            this.Name = name;
            return (T)this;
        }

        public override string ToString()
        {
            return base.ToString() + $"name: {Name}";
        }
    }


    public class AnimalBuilder
    {
        public class Builder : Human<Builder> { };
        public static Builder New => new Builder();
    }
}
