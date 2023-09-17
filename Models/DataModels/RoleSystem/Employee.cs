using System.ComponentModel.DataAnnotations;

namespace Models.DataModels.RoleSystem
{
    public class Employee : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }



    }
}
