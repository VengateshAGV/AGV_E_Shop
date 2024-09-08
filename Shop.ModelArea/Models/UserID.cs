

using Microsoft.AspNetCore.Identity;
using Shop.ModelArea.Models.Enums;
using System.ComponentModel;

namespace Shop.ModelArea.Models
{
    public class UserID : IdentityUser
    {
        [DisplayName("Profile Upload")]
        public string ProfileName { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }

        [DisplayName("Select Place")]
        public Place Place { get; set; }

        public string Dor_No { get; set; }

        [DefaultValue("Street")]
        public string Street { get; set; }

        public string LandMark { get; set; }

        [DefaultValue("City")]
        public string City { get; set; }

        [DefaultValue("State")]
        public string State { get; set; }


        public Cuntry Cuntry { get; set; }

        [DefaultValue("0")]
        public string Pincode { get; set; }
    }
}
