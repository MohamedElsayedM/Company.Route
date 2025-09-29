using Company.Route.BLL.Interface;
using Company.Route.BLL.Repositories;
using Company.Route.DAL.Models;
using Company.Route.PL.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace Company.Route.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CreateDepartmentDto model)
        {
            if (ModelState.IsValid) {

                Department department = new Department()
                {
                    Code = model.Code,
                    Name = model.Name,
                    CreationAt = model.CreationAt,
                };

                int Count = _departmentRepository.Add(department);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
               return BadRequest("Invalid Id");
            } else {
               var department= _departmentRepository.Get(id.Value);
                if (department is null) return NotFound(new {StatusCode=404 ,Message= $"Department with Id :{id} is not found ."});
                return View(department);
            }
  
        }


    }
}
