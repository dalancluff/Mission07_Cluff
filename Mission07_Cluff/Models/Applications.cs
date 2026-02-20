using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIssion07_Cluff.Models
{
    public class Application
    {
        // Primary key for the Movies table
        [Key]
        public int MovieId { get; set; }

        // Foreign key linking to the Categories table
        [Required(ErrorMessage = "Please select a category.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        // Movie title is required
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        // Year must be provided and no earlier than 1888 (the year the first movie was made)
        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, 9999, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }

        // Optional fields
        public string? Director { get; set; }
        public string? Rating { get; set; }

        // Whether the movie is an edited version — required per assignment
        [Required(ErrorMessage = "Please indicate if the movie is edited.")]
        public bool Edited { get; set; }

        [Display(Name = "Lent To")]
        public string? LentTo { get; set; }

        // Whether the movie has been copied to Plex — required per assignment
        [Required(ErrorMessage = "Please indicate if the movie has been copied to Plex.")]
        [Display(Name = "Copied to Plex")]
        public bool CopiedToPlex { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}