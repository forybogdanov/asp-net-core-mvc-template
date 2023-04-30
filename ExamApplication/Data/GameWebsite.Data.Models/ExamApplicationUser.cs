using Microsoft.AspNetCore.Identity;

namespace ExamApplication.Data.Models
{
    public class ExamApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Event> Events { get; set; }
    }
}
