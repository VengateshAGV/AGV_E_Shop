

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Shop.ModelArea.Models.Commen;
using Shop.ModelArea.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.ModelArea.Models
{
    public class BrandModel : BaseModel
    {
        public string Name { get; set; }

        public string Image {  get; set; }

        public DateTime LounchDate { get; set; }

        public string ModelVersion { get; set; }

        [ValidateNever]
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        [Display(Name="Brand")]
        public Guid BrandId { get; set; }


        [ValidateNever]
        public ModelType ModelType { get; set; }

        [Display(Name ="Model Type")]
        public Guid ModelTypeId {  get; set; }

        public string Size {  get; set; }

        public string Wight {  get; set; }

        public string Height {  get; set; }

        public string Width { get; set; }

        public string Material {  get; set; }

        public string Color {  get; set; }

        public string Description { get; set; }

        [Display(Name ="MRP Price")]
        public double Price {  get; set; }

        [Display(Name ="Price")]
        public double Price1 {  get; set; }

        [Display(Name = "Select DisCount Yes/No")]
        public DisCount DisCount {get ; set; }

        [Range(1, 5, ErrorMessage = "Rating Should be from 1 to 5 only")]
        public int Rattings { get; set; }

        public int Count {  get; set; }

        

    }

    
    
}
