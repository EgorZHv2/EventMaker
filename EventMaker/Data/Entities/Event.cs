namespace EventMaker.Data.Entities
{
    public class Event
    {
        public Guid Id { get;set; }
        public string Name { get;set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Direction Direction { get; set; }
        public Guid DirectionId { get; set; }
        public City City { get; set; }
        public Guid CityId { get; set; }
        public List<User> Jury { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
