using System.Collections.Generic;
using homeChores.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace homeChores.Models
{
    public class AssignChore
    {
        public List<SelectListItem> Chores { get; set; }
        public string Chore { get; set; }
        public List<SelectListItem> AppUsers { get; set; }
        public string User { get; set; }
        
        
    }
}