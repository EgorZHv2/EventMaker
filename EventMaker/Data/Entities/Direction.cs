namespace EventMaker.Data.Entities
{
    public class Direction
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Event> Events { get; set; }
        public List<User> Users { get; set; }
    }
}
