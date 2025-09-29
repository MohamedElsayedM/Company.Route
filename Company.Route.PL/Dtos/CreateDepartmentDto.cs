using System.ComponentModel.DataAnnotations;

namespace Company.Route.PL.Dtos
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage ="Code is required")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "CreationAt is required")]
        public DateTime CreationAt { get; set; }
    }
}
