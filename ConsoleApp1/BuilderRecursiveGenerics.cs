using System;
using System.Collections.Generic;
using System.Text;


namespace ConsoleApp1
{
    class BuilderRecursiveGenerics
    {
       
        
        //public static void Main(string[] args)
        //{
        //  var me =  Person.New
        //        .Called("Tony")
        //        .WorkAs("SE")
        //        .Build();
        //    Console.WriteLine(me);
        //}
    }
    public class Person
    {
        public string Name;
        public string Posittion;

        public class Builder: PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();
        public override string ToString()
        {
            return $"{nameof(Name)} : {Name}, {nameof(Posittion)} : {Posittion}";
        }


    }

    public abstract class PersonBuilder 
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }
    // class Foo: Bar<foo>
    public class PersonInfoBuilder<T>: 
        PersonBuilder
        where T: PersonInfoBuilder<T>
    {
       // protected Person person = new Person();

        public T Called(string name)
        {
            person.Name = name;
            return (T)this;
        }
    }

    public class PersonJobBuilder<T>:
        PersonInfoBuilder<PersonJobBuilder<T>>
        where T: PersonJobBuilder<T>
        
    {
        public T WorkAs(string position)
        {
            person.Posittion = position;
            return (T) this;
        }
    }
}
