using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Core.Entities
{
    [Table("Authors")]
    public class Author : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Style { get; set; }
        public double Distance { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
    }
}
