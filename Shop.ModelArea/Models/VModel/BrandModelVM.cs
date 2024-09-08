

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shop.ModelArea.Models.VModel
{
    public class BrandModelVM
    {
        public BrandModel BrandModel { get; set; }

        public IEnumerable<SelectListItem> BrandList {  get; set; }

        public IEnumerable<SelectListItem> ModelTypeList {  get; set; }

        public IEnumerable<SelectListItem> DisCountList { get; set; }
    }
}
