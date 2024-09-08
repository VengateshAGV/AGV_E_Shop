

using Microsoft.AspNetCore.Identity;
using Shop.ModelArea.Models.Commen;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.ModelArea.Models
{
    public class Reviews : BaseModel
    {
        public string Review { get; set; }


        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }
    }
}
