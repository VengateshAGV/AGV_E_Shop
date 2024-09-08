using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Shop.ModelArea.Models.Commen;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.ModelArea.Models.Enums;

namespace Shop.ModelArea.Models
{
    public class Brand : BaseModel
    {
        public string BrandName { get; set; }


        [DisplayName("Brand Logo")]
        public string BrandLogo { get; set; }



        [DisplayName("Company Dor.No & Street")]
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public Cuntry Cuntry { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }


        public string PostalCode { get; set; }
    }
}
