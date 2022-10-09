using EventMaker.Data.Entities;
using EventMaker.Data.Enums;

namespace EventMaker.Models.ViewModels
{
    public class MemberViewModel
    {
        public string Id { get; set; }
        public int IdNumber { get; set; }
        public DateTime LastLogin { get; set; }
        public byte[]? UserProfile { get; set; }
        public Gender Gender { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Patronimyc { get; set; }
        public DateTime BirthDate { get; set; }
        public Direction? Direction { get; set; }
        public string Email { get; set; }
    }
}
