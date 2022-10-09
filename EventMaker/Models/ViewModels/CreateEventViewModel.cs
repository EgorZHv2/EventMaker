using EventMaker.Data.Entities;

using System.ComponentModel.DataAnnotations;

namespace EventMaker.Models.ViewModels
{
    public class CreateEventViewModel
    {
        public string OrganizerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public IFormFile LogoInput { get; set; }
        public string Name { get; set; }
        public string? DirectionName { get; set; }
        public int? DirectionId { get; set; }
        public string? CityName { get; set; }
        public int? CityId { get; set; }
        
        public List<DirectionViewModel>? Directions { get; set; }
        public List<CityViewModel>? Cities { get; set; }



    }
}
