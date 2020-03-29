using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Folk
    {
        public string StreetAddress, PostCode, City;
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress} , {nameof(PostCode)}: {PostCode},  {nameof(PostCode)}: {PostCode},  " +
                $"{nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName},  {nameof(Position)}: {Position},  {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    // facade
    public class FolkBuilder
    {
        protected Folk folk = new Folk();

        public FolkJobBuilder Works => new FolkJobBuilder(folk);

        public FolkAddressBuilder Lives => new FolkAddressBuilder(folk);

        public static implicit operator Folk(FolkBuilder fb)
        {
            return fb.folk;
        }
    }

    public class FolkJobBuilder: FolkBuilder
    {
        public FolkJobBuilder(Folk folk)
        {
            this.folk = folk;
        }

        public FolkJobBuilder At(string companyName)
        {
            folk.CompanyName = companyName;
            return this;
        }
        public FolkJobBuilder AsA(string position)
        {
            folk.Position = position;
            return this;
        }

        public FolkJobBuilder Earning(int  amount)
        {
            folk.AnnualIncome = amount;
            return this;
        }
    }


    public class FolkAddressBuilder : FolkBuilder
    {
        public FolkAddressBuilder(Folk folk)
        {
            this.folk = folk;
        }

        public FolkAddressBuilder At(string streetAddress)
        {
            folk.StreetAddress = streetAddress;
            return this;
        }
        public FolkAddressBuilder WithPostCode(string postcode)
        {
            folk.PostCode = postcode;
            return this;
        }

        public FolkAddressBuilder In(string city)
        {
            folk.City = city;
            return this;
        }
    }

    public class FacetedBuilder
    {

        public static void Main(string[] args)
        {
            var fb = new FolkBuilder();
            Folk folks = fb
                .Works.At("THermo")
                .AsA("SE")
                .Earning(1600000)
                .Lives.At("123")
                .WithPostCode("234525")
                .In("Bangalore");
            Console.WriteLine(folks);
        }
    }
}
