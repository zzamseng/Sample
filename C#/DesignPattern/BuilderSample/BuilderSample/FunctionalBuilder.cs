using System;
using System.Collections.Generic;
using System.Linq;

namespace BuilderSample.FunctionalBuilder
{
    public class Person
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return $"name::{Name},,Location:{Location}";
        }
    }

    public abstract class FunctionalBuilder<TSubject, TSelf>

        where TSubject : new()
        where TSelf : FunctionalBuilder<TSubject, TSelf>

    {
        private readonly List<Func<TSubject, TSubject>> _actions = new List<Func<TSubject, TSubject>>();

        public TSelf Do(Action<TSubject> action)
            => AddAction(action);

        protected TSelf AddAction(Action<TSubject> action)
        {
            _actions.Add(p => { action(p); return p; });
            return (TSelf)this;
        }

        public TSubject Builder()
        => _actions.Aggregate(new TSubject(), (p, f) => f(p));
    }

    public class PersonBuilder: FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name)
            => Do(p => p.Name = name);
    }

    public static class PersonBuilderEx
    {
        public static PersonBuilder Location(this PersonBuilder personBuilder, string location)
            => personBuilder.Do(p => p.Location = location);
    }
}
