using System.ComponentModel.DataAnnotations;
namespace SafeView.Dto.Product
{
    public class ProductDto
    {
        public string Name { get; set; }

        public decimal PriceForMe { get; set; }

        public decimal PriceForSell { get; set; }
    }
}
