using EventMaker.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace EventMaker.Data.Entities
{
    public class User:IdentityUser
    {
        public int IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronimyc { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte[]? UserProfile { get; set; }
        public Gender Gender { get; set; }
        public Direction? Direction { get; set; }
        public Guid? DirectionId { get; set; }
        public Event? Event { get; set; }
        public Guid? EventId { get; set; }
        public Country? Country { get; set; }
        public Guid? CountryId { get; set; }
    }
}
