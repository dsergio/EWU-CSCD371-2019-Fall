namespace Assignment
{
    public class Address : IAddress
    {
        public Address(string streetAddress, string city, string state, string zip)
        {
            StreetAddress = streetAddress ?? throw new System.ArgumentNullException(nameof(streetAddress));
            City = city ?? throw new System.ArgumentNullException(nameof(city));
            State = state ?? throw new System.ArgumentNullException(nameof(state));
            Zip = zip ?? throw new System.ArgumentNullException(nameof(zip));
        }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public override string ToString()
        {
            return $"{StreetAddress} {City}, {State} {Zip}";
        }
    }
}
