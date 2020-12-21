namespace TestDoubles.TestSpecific
{
    public class Flight
    {
        public string Id { get;private set; }
        public string FlightNumber { get; private set; }

        public Flight(string _id , string flightNumber)
        {
            Id = _id;
            FlightNumber = flightNumber;
        }

        public void ChangeFlightNumber(string newFlightNumber)
        {
            FlightNumber = newFlightNumber;
        }
    }
}