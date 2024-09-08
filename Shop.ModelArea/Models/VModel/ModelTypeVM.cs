

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shop.ModelArea.Models.VModel
{
    public class ModelTypeVM
    {
        public ModelType ModelType { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> BrandTypeList { get; set; }
    }
}
