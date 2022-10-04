using EventMaker.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventMaker.Data.Entities
{
    public class User:IdentityUser
    {

        public int IdNumber { get; set; }
        public DateTime? LastLogin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronimyc { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? UserProfilePath { get; set; }
        public Gender Gender { get; set; }
       
        public Direction? Direction { get; set; }
        public int? DirectionId { get; set; }
        
        public Event? Event { get; set; }
        public int? EventId { get; set; }
     
        public Country? Country { get; set; }
        public int? CountryId { get; set; }
        public List<Activity> WinnerActivities { get; set; }
        public List<Activity> ModeratorActivities { get; set; }
        public List<Activity> JuryActivities { get; set; }

        public List<UserRequest> Requests { get; set; }
    }
}
