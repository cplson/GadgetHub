using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GadgetHub.Domain.Entities
{
    public class Gadget
    {
        [HiddenInput (DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
