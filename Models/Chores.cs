using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace home_chores.Models
{
    public class Chores
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(0, 10)]
        public int Level { get; set; }
        public DateTime Completed { get; set; }
        [ForeignKey("AppUser")]
        public int UserId { get; set; }
        
        
    }
}