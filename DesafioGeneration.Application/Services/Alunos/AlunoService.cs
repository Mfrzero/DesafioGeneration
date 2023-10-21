using DesafioGeneration.Domain.Interfaces.Alunos;
using DesafioGeneration.Domain.Models.Alunos;

namespace DesafioGeneration.Application.Services.Alunos
{
    public class AlunoService
    {
        private readonly IAluno _aluno;

        public AlunoService(IAluno aluno)
        {
            _aluno = aluno;
        }
        public async Task<IEnumerable<Aluno>> GetAllStudentsAsync()
        {
            return await _aluno.GetAllAsync();
        }

        public async Task<Aluno> GetStudentByIdAsync(int id)
        {
            return await _aluno.GetByIdAsync(id);
        }

        public async Task<Aluno> AddStudentAsync(Aluno aluno)
        {
            return await _aluno.CreateAsync(aluno);
        }

        public async Task<bool> UpdateStudentAsync(int id, Aluno aluno)
        {
            return await _aluno.UpdateAsync(id, aluno);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            return await _aluno.DeleteAsync(id);
        }
    }
}
