using System.ComponentModel.DataAnnotations;

namespace MIssion07_Cluff.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<Application> Movies { get; set; } = new List<Application>();
    }
}