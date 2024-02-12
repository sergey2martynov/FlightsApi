namespace Application.Flights.Queries.GetAll
{
    public class FlightLookupDto
    {
        public Guid Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTimeOffset Departure { get; set; }
        public DateTimeOffset Arrival { get; set; }
        public Status Status { get; set; }
    }
}
