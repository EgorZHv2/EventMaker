using EventMaker.Data.Entities;

namespace EventMaker.Models.ViewModels.CreateEventView
{
    public class CreateEventViewModel
    {
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }

        public int? DirectionId { get; set; }
        public string? DirectionName { get; set; }
        public int? CityId { get; set; }
        public string? CityName { get; set; }



    }
}
