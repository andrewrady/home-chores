using Microsoft.AspNetCore.Identity;

namespace home_chores.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }                
        public string LastName { get; set; }
    }
}