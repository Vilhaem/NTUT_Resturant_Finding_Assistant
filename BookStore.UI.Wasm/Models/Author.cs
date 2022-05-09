using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.UI.Wasm.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Style")]
        public string Style { get; set; }
        [Required]
        [DisplayName("Distance")]
        public double Distance { get; set; }
        [Required]
        [DisplayName("Address")]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [DisplayName("Rating")]
        public double Rating { get; set; }
    }
}