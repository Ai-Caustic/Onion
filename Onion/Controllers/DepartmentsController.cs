using DomainLayer.Data;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;


namespace Onion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {

        private readonly ICustomServices<Department> _customService;

        private readonly ApplicationDbContext _applicationDbContext;

        public DepartmentsController (ICustomServices<Department> customService, ApplicationDbContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet(nameof(GetDepartmentById))]
        public IActionResult GetDepartmentById(int Id)
        {
            var obj = _customService.Get(Id);

            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpGet(nameof(GetAllDepartments))]
        public IActionResult GetAllDepartments()
        {
            var obj = _customService.GetAll();
            if ( obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }

        }

        [HttpPost(nameof(CreateDepartment))]
        public IActionResult CreateDepartment(Department department)
        {
            if (department != null)
            {
                _customService.Insert(department);
                return Ok("Created department successfully");
            }
            else
            {
                return BadRequest("Something went wrong while creating department");
            }
        }

        [HttpPost(nameof(UpdateDepartment))]
        public IActionResult UpdateDepartment(Department department)
        {
            if (department != null)
            {
                _customService.Update(department);
                return Ok("Updated succesfully");
            }
            else
            {
                return BadRequest("Something went wrong while updating");
            }

        }

        [HttpDelete(nameof(DeleteDepartment))]
        public IActionResult DeleteDepartment(Department department)
        {
            if (department != null)
            {
                _customService.Delete(department);
                return Ok("Deleted succesfully");
            }
            else
            {
                return BadRequest("Something went wrong while deleting");
            }
        }
    }
}
