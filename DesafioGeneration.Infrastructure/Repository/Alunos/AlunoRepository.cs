using Dapper;
using DesafioGeneration.Domain.Interfaces.Alunos;
using DesafioGeneration.Domain.Models.Alunos;
using DesafioGeneration.Infrastructure.DB;

namespace DesafioGeneration.Infrastructure.Repository.Alunos
{
    public class AlunoRepository : IAluno
    {
        public readonly DBContext _context;

        public AlunoRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aluno>> GetAllAsync()
        {
            using var connection = _context.Connection;
            const string query = "SELECT * FROM Alunos";
            return await connection.QueryAsync<Aluno>(query);
        }

        public async Task<Aluno> GetByIdAsync(int id)
        {
            using var connection = _context.Connection;
            const string query = "SELECT * FROM Alunos WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Aluno>(query, new { Id = id });
        }

        public async Task<Aluno> CreateAsync(Aluno aluno)
        {
            using var connection = _context.Connection;
            const string query = "INSERT INTO Alunos (Nome,Idade,NotaPrimeiroSemestre,NotaSegundoSemestre,NomeProfessor,NumeroSala) VALUES (@Nome,@Idade,@NotaPrimeiroSemestre,@NotaSegundoSemestre,@NomeProfessor,@NumeroSala);";
            return await connection.ExecuteScalarAsync<Aluno>(query, aluno);
        }
        public async Task<bool> UpdateAsync(int id, Aluno aluno)
        {
            using var connection = _context.Connection;
            const string query = "UPDATE Alunos SET Nome = @Nome, Idade = @Idade, NotaPrimeiroSemestre = @NotaPrimeiroSemestre, NotaSegundoSemestre = @NotaSegundoSemestre, NomeProfessor = @NomeProfessor,  NumeroSala = @NumeroSala WHERE Id = @Id";
            var rowsAffected = await connection.ExecuteAsync(query, aluno);
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _context.Connection;
            const string query = "DELETE FROM Alunos WHERE Id = @Id";
            var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
            return rowsAffected > 0;
        }

    }
}
