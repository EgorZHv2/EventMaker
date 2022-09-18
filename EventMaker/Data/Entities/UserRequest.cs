using EventMaker.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventMaker.Data.Entities
{
    public class UserRequest
    {
        public int Id { get; set; }
        
        public Activity Activity { get; set; }
        public int ActivityId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public UserRequestStatus RequestStatus {get;set;}
    }
}
