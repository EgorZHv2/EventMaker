using EventMaker.Data.Entities;

namespace EventMaker.Models.ViewModels
{
    public class DetailedEventViewModel //
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Logo { get; set; }
        public Direction Direction { get; set; }
        public DateTime StartDate { get; set; }
        public City City { get; set; }
        public User Organizer { get; set; }
    }
}
