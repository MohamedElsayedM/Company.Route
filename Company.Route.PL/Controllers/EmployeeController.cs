using Company.Route.BLL.Interface;
using Company.Route.DAL.Models;
using Company.Route.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Company.Route.PL.Controllers
{
    public class EmployeeController : Controller 
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
           var Employees= _employeeRepository.GetAll();
            return View(Employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
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
                };

                return View(viewName, dto);
            }
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {  
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
        public IActionResult Delete([FromRoute] int id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (id != employee.Id) return BadRequest("Invalid Id .");
                var count = _employeeRepository.Delete(employee);
                if(count >0) return RedirectToAction("Index");  
            }
            return View(employee);
        }




    }
}
