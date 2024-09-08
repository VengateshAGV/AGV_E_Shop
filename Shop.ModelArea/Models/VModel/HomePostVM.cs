using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Shop.ModelArea.Models.VModel
{
    public class HomePostVM
    {
        public List<BrandModel> BrandModel { get; set; }

        public string? SearchBox {  get; set; }

        public Guid? BrandId { get; set; }

        public Guid? BrandTypeId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> BrandList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ModelTypeList {  get; set; }
    }
}
