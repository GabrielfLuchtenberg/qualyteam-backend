using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentsApi.Models;

namespace DocumentsApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public DepartmentController(DatabaseContext context)
        {
            _context = context;

            if (_context.Departments.Count() == 0)
            {
                _context.Departments.Add(new Department { Name = "Desenvolvimento" });
                _context.Departments.Add(new Department { Name = "Comercial" });
                _context.Departments.Add(new Department { Name = "Suporte" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetDepartments()
        {
            return _context.Departments.ToList();
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartment(long id)
        {
            var department = _context.Departments.Find(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // POST: api/Department
        [HttpPost]
        public ActionResult<Department> PostDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();

            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }


        // PUT: api/Department/5
        [HttpPut("{id}")]
        public IActionResult PutDepartment(long id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public ActionResult<Department> DeleteDepartment(long id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();

            return department;
        }
    }
}