using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Books_Collection.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        //validation for cilent-side
        [Required]
        [DisplayName("Display Name")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

    }
}
