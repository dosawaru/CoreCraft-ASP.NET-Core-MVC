using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookHavenWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } // Primary key for the category

        [Required]
        public string? Name { get; set; } // Name of the category, required field

        [DisplayName("Display Order")] // Display name for the DisplayOrder property
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100")] // Validation to ensure DisplayOrder falls within a specific range

        public int DisplayOrder { get; set; } // Display order of the category

        public DateTime CreatedDateTime { get; set; } = DateTime.Now; // Date and time when the category was created, defaults to current date and time
    }
}
