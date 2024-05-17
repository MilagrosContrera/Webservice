using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Webservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly List<Student> _students = new List<Student>
        {
            new Student { Id = 1, Name = "Pedro", LastName = "Perez" },
            new Student { Id = 2, Name = "Luis", LastName = "Torres" }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Datos de estudiante inválidos");
            }

            // Validar otros criterios de validación si es necesario
            if (string.IsNullOrEmpty(student.Name) || string.IsNullOrEmpty(student.LastName))
            {
                return BadRequest("El nombre y el apellido del estudiante son obligatorios");
            }

            student.Id = _students.Count + 1; // Simulando un ID autoincremental
            _students.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}



