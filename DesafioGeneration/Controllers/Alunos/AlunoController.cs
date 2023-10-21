using DesafioGeneration.Domain.Interfaces.Alunos;
using DesafioGeneration.Domain.Models.Alunos;
using Microsoft.AspNetCore.Mvc;

namespace DesafioGeneration.Api.Controllers.Alunos
{
    [ApiController]
    [Route("/api/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAluno _aluno;

        public AlunoController(IAluno aluno)
        {
            _aluno = aluno;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> Get()
        {
            var students = await _aluno.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> Get(int id)
        {
            var student = await _aluno.GetByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> Post([FromBody] Aluno student)
        {
            var id = await _aluno.CreateAsync(student);
            return CreatedAtAction(nameof(Get), new { id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Aluno student)
        {
            if (id != student.Id) return BadRequest();
            var updated = await _aluno.UpdateAsync(id, student);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _aluno.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }



    }
}
