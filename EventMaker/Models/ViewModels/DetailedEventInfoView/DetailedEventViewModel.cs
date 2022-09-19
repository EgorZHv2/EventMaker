using EventMaker.Data.Entities;

namespace EventMaker.Models.ViewModels
{
    public class DetailedEventViewModel //
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
        public DateTime StartDate { get; set; }
        public City City { get; set; }
        public User Organizer { get; set; }
    }
}
