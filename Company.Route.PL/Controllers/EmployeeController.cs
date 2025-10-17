using Company.Route.BLL.Interface;
using Company.Route.DAL.Models;
using Company.Route.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Company.Route.PL.Controllers
{
    public class EmployeeController : Controller 
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult Index(string? SearchInput)
        {
            IEnumerable<Employee> Employees;
            if (string.IsNullOrEmpty(SearchInput))
            {
                 Employees = _employeeRepository.GetAll();
            }else { 
            Employees= _employeeRepository.GetByName(SearchInput);
                    }
                return View(Employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments =_departmentRepository.GetAll();
            ViewData["departments"] = departments;
           return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Name = model.Name,
                    Address = model.Address,
                    Age = model.Age,
                    Phone = model.Phone,
                    Email = model.Email,
                    Salary = model.Salary,
                    IsActive = model.IsActive,
                    IsDeleted = model.IsDeleted,
                    HiringDate = model.HiringDate,
                    CreateAt = model.CreateAt,
                    DepartmentId = model.DepartmentId

                };
                var Check = _employeeRepository.Add(employee);
                if (Check > 0) return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Details(int? id,string viewName ="Details") 
        {
            if (id is null)
            { return BadRequest("Invalid Id"); }
            else
            {                
                var employee = _employeeRepository.Get(id.Value);
                if(employee is null) return NotFound(new { StatusCode = 404, Message = $"Employee with Id :{id} is not found ." });
                var dto = new EmployeeDto
                {
                    Id=employee.Id,
                    Name = employee.Name,
                    Address = employee.Address,
                    Age = employee.Age,
                    Phone = employee.Phone,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    IsActive = employee.IsActive,
                    IsDeleted = employee.IsDeleted,
                    HiringDate = employee.HiringDate,
                    CreateAt = employee.CreateAt,
                    DepartmentId = employee.DepartmentId,
                    DepartmentName= employee.Department?.Name ?? "No Department"
                };

                return View(viewName, dto);
            }
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var departments = _departmentRepository.GetAll();
            ViewData["departments"] = departments;
            return Details(id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id,EmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id=id,
                    Name = model.Name,
                    Address = model.Address,
                    Age = model.Age,
                    Phone = model.Phone,
                    Email = model.Email,
                    Salary = model.Salary,
                    IsActive = model.IsActive,
                    IsDeleted = model.IsDeleted,
                    HiringDate = model.HiringDate,
                    CreateAt = model.CreateAt,
                    DepartmentId = model.DepartmentId,
                };
                var Check = _employeeRepository.Update(employee);
                if (Check > 0) return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int id, EmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                if (id != model.Id) return BadRequest("Invalid Id .");
                var employee = new Employee() {
                    Id = id,
                    Name = model.Name,
                    Address = model.Address,
                    Age = model.Age,
                    Phone = model.Phone,
                    Email = model.Email,
                    Salary = model.Salary,
                    IsActive = model.IsActive,
                    IsDeleted = model.IsDeleted,
                    HiringDate = model.HiringDate,
                    CreateAt = model.CreateAt,
                    DepartmentId=model.DepartmentId,
                    
                };
                var count = _employeeRepository.Delete(employee);
                if(count >0) return RedirectToAction("Index");  
            }
            return View(model);
        }

    }
}
