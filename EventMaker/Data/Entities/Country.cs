

namespace EventMaker.Data.Entities
{
    public class Country
    {
        
        public int Id { get; set; }
        public string CharId { get; set; }
        public string RusName { get; set; }
        public string EngName { get; set; }
        public List<User> Users { get; set; }
    }
}
