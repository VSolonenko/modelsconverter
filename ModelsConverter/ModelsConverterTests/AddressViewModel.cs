using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsConverterTests
{
    class AddressViewModel
    {
        public AddressViewModel(int id, string country, string city, string street, string number)
        {
            Id = id;
            Country = country;
            City = city;
            Street = street;
            Number = number;
        }
        public int Id { get; }
        public string Country { get; }
        public string City { get; }
        public string Street { get; }
        public string Number { get; }
    }
}
