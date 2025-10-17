using Company.Route.DAL.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace Company.Route.PL.Dtos
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

      
        [Range(20, 60, ErrorMessage = "Age must be from 20 to 60")]
        public int Age { get; set; }

        public string Address { get; set; }
        
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime HiringDate { get; set; }
        public DateTime CreateAt { get; set; }
        
        [DisplayName("Department")]
        public int? DepartmentId { get; set; }
        
    }
}
