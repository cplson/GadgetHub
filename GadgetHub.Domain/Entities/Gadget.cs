using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GadgetHub.Domain.Entities
{
    public class Gadget
    {
        [HiddenInput (DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a gadget name")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        public string Brand { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }
    }
}
