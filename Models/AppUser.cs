using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace homeChores.Models
{
    public class AppUser : IdentityUser<string>
    {
        public string FirstName { get; set; }                
        public string LastName { get; set; }
        public ICollection<Chores> Chores { get; set; }
        
    }
}