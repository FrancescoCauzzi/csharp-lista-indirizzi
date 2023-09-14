using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    internal class Address
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }

        public Address(string name, string surname,string street, string city, string province,string zipCode) { 
            this.Name = name;
            this.Surname = surname;
            this.Street = street;
            this.City = city;
            this.Province = province;
            this.ZipCode = zipCode;
        }

        public override string ToString()
		{
			return $"The address of {Name} {Surname}: {Street}, {City}, {Province}, ZIP: {ZipCode}";
		}
    }
}
