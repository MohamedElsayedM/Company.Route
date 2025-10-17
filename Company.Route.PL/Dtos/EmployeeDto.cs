using System.ComponentModel.DataAnnotations;

namespace Company.Route.PL.Dtos
{
    public class EmployeeDto : CreateEmployeeDto
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; } = string.Empty;
    }
}
