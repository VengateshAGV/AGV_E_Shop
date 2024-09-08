

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Shop.ModelArea.Models.Commen;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.ModelArea.Models
{
    public class OrderDetail: BaseModel
    {
        public int ModelId {  get; set; }

        [ForeignKey("ModelId")]
        [ValidateNever]
        public BrandModel BrandModel { get; set; }

        public int Count {  get; set; }

        public double Price {  get; set; }
    }
}
