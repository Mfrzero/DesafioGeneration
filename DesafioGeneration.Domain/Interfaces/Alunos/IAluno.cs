using DesafioGeneration.Domain.Models.Alunos;

namespace DesafioGeneration.Domain.Interfaces.Alunos
{
    public interface IAluno
    {
        Task<IEnumerable<Aluno>> GetAllAsync();
        Task<Aluno> GetByIdAsync(int id);
        Task<Aluno> CreateAsync(Aluno aluno);
        Task<bool> UpdateAsync(int id, Aluno aluno);
        Task<bool> DeleteAsync(int id);
    }
}
