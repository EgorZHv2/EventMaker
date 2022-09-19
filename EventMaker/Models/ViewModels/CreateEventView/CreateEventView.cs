using EventMaker.Data.Entities;

namespace EventMaker.Models.ViewModels.CreateEventView
{
    public class CreateEventView
    {
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }

        public List<Direction> Directions { get; set; } = new List<Direction>();
        public List<City> City { get; set; } = new List<City>();
        public int CityId { get; set; }
        public List<User> UsersJury { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
