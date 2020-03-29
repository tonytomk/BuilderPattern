using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Customer
    {
        public string Name, Position;
    }

    public class CustomerBuilder
    {
        public readonly List<Action<Customer>> Actions =
            new List<Action<Customer>>();
        public CustomerBuilder Called(string name)
        {
            Actions.Add(c => c.Name = name);
            return this;
        }
        public Customer Build()
        {
            var c = new Customer();
            Actions.ForEach(a => a(c));
            return c;
        }
    }

    public static class CustomerBuilderExtensions
    {
        public static CustomerBuilder WorksAsA
            (this CustomerBuilder builder, string position)
        {
            builder.Actions.Add(c => { c.Position = position; });
            return builder;
        }
    }


    class FunctionalBuilder
    {
        //static void Main(string[] args)
        //{
        //    var customBuilder = new CustomerBuilder();
        //    customBuilder.Called("Tony")
        //        .WorksAsA("developer")
        //        .Build();
        //}
    }
}
