using System.ComponentModel.DataAnnotations.Schema;

namespace EventMaker.Data.Entities
{
    public class Event
    {
        public int Id { get;set; }
        public string Name { get;set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LogoPath { get; set;}
        public Direction Direction { get; set; }
        public int DirectionId { get; set; }
       
        public City City { get; set; }
        public int CityId { get; set; }
        public List<User> UsersJury { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
