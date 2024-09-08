//using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
//using Shop.ModelArea.Models.Commen;
//using Shop.ModelArea.Models.Enums;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;


//namespace Shop.ModelArea.Models
//{
//    public class BrandPost : BaseModel
//    {
//        [Display(Name ="Brand")]
//        public Guid BrandId { get; set; }

//        [ValidateNever]
//        [ForeignKey("BrandId")]
//        public Brand Brand { get; set; }

        

//        [Display(Name ="Select DisCount Yes/No")]
//        public DisCount DisCount { get; set; }

//        [Range(1, 5, ErrorMessage ="Rating Should be from 1 to 5 only")]
//        public int Rattings {  get; set; }

//        public double Price {  get; set; }

        



//    }
//}
