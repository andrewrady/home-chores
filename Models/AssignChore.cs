using System.Collections.Generic;
using homeChores.Models;

namespace homeChores.Models
{
    public class AssignChore
    {
        public IEnumerable<Chore> Chores { get; set; }
        public IEnumerable<AppUser> AppUsers { get; set; }
    }
}