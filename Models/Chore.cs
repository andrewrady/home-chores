using System.ComponentModel.DataAnnotations;

namespace homeChores.Models
{
    public class Chore
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(0, 10)]
        public int Level { get; set; }
    }
}