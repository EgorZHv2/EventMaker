using EventMaker.Data.Entities;

namespace EventMaker.Models.ViewModels
{
    public class CreateActivityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public List<User> UsersJury { get; set; }
    }
}
