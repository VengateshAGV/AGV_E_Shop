

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Shop.ModelArea.Models.Commen;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.ModelArea.Models
{
    public class ModelType : BaseModel
    {
        public string Name { get; set; }

        [Display(Name = "Brand Type")]
        public Guid BrandTypeId { get; set; }

        [ValidateNever]
        [ForeignKey("BrandTypeId")]
        public BrandType BrandType { get; set; }

    }
}
