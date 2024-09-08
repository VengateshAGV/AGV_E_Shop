

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shop.ModelArea.Models
{
    public class ShopingCard
    {
        public Guid Id { get; set; }

        public Guid ModelId {  get; set; }

        [ForeignKey("ModelId")]
        [ValidateNever]
        public BrandModel Model { get; set; }

        public int Count {  get; set; }

        public string UserId {  get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        public UserID Customer { get; set; }

        
        public double Price {  get; set; }
    }
}
