using EventMaker.Data.Enums;

namespace EventMaker.Data.Entities
{
    public class UserRequest
    {
        public Guid Id { get; set; }
        public Activity Activity { get; set; }
        public Guid ActivityId { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public UserRequestStatus RequestStatus {get;set;}
    }
}
