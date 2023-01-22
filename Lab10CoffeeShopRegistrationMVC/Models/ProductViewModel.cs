using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lab10CoffeeShopRegistrationMVC.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        public string Category { get; set; }
    }
}
