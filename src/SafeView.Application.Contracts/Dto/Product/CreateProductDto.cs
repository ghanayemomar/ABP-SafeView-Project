using System.ComponentModel.DataAnnotations;

namespace SafeView.Dto.Product
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal PriceForMe { get; set; }
        [Required]
        public decimal PriceForSell { get; set; }


    }
}
