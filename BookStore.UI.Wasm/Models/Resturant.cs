using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.UI.Wasm.Models
{
    public class Resturant
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Style")]
        public string Style { get; set; }
        public int PriceClass { get; set; }
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

        private enum PriceClassEnum
        {
            Cheap = 0,
            Normal = 1,
            Expensive = 2
        }
        [DisplayName("Price Range")]
        public string getPriceLabel()
        {
            switch (PriceClass)
            {
                case (int)PriceClassEnum.Cheap:
                    return "Cheap";
                case (int)PriceClassEnum.Normal:
                    return "Normal";
                case (int)PriceClassEnum.Expensive:
                    return "Expensive";
                default:
                    return "Wrong Class";
            }
        }
    }
}