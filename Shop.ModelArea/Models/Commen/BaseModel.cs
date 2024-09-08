

namespace Shop.ModelArea.Models.Commen
{
    public class BaseModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiOn { get; set; }

        public string ModifiBy { get; set; }
    }
}
