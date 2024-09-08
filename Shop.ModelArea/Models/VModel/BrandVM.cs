

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shop.ModelArea.Models.VModel
{
    public class BrandVM
    {
        public Brand Brand { get; set; }

        public IEnumerable<SelectListItem> CunteryList { get; set; }
    }
}
