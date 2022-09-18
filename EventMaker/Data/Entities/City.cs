namespace EventMaker.Data.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Event> Events { get; set; }
    }
}
