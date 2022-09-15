namespace EventMaker.Data.Entities
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public Event Event { get; set; }
        public Guid EventId { get; set; }
        public List<User> Jury { get; set; }
        public List<UserRequest> UserRequests { get; set; }
        //public object Resource { get; set; } //ToDo Понять чё за ресурсы такие





    }
}
