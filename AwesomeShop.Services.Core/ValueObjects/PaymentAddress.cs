using System;

namespace AwesomeShop.Services.Core.ValueObjects
{
    public class PaymentAddress
    {
        public PaymentAddress(string street, string number, string city, string state, string zipCode)
        {
            Street = street;
            Number = number;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is PaymentAddress address &&
                   Street == address.Street &&
                   Number == address.Number &&
                   City == address.City &&
                   State == address.State &&
                   ZipCode == address.ZipCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, Number, City, State, ZipCode);
        }
    }
}
