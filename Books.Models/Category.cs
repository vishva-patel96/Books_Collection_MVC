using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        //validation for cilent-side
        [Required]
        [DisplayName("Display Name")]
        [MaxLength(25)]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 to 100.")]
        public int DisplayOrder { get; set; }

    }
}
