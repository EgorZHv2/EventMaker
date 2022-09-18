using System.ComponentModel.DataAnnotations.Schema;

namespace EventMaker.Data.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        
        public Event Event { get; set; }
        
        public int EventId { get; set; }
        
        public User? Moderator { get; set; }
        public string? ModeratorId { get; set; }
       
        public User? Winner { get; set; }
        public string? WinnerId { get; set; }
        public List<User> UsersJury { get; set; }
        public List<UserRequest>? UserRequests { get; set; }
        //public object Resource { get; set; } //ToDo Понять чё за ресурсы такие





    }
}
