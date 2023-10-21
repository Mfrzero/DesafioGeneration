using System.ComponentModel.DataAnnotations;

namespace DesafioGeneration.Domain.Models.Alunos
{
    public class Aluno
    {
        //ID, nome, idade, nota do primeiro semestre, nota do segundo semestre, nome do professor e número da sala.
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Idade é obrigatória.")]
        [Range(0, 150, ErrorMessage = "Idade não pode ser menor que 0 nem maior que 150.")]
        public short Idade { get; set; }
        [Required(ErrorMessage = "Nota do primeiro semestre é obrigatória.")]
        [Range(0, 10, ErrorMessage = "Nota não pode ser menor que 0 nem maior que 10.")]
        public short NotaPrimeiroSemestre { get; set; }
        [Required(ErrorMessage = "Nota do segundo semestre é obrigatória.")]
        [Range(0, 10, ErrorMessage = "Nota não pode ser menor que 0 nem maior que 10.")]
        public short NotaSegundoSemestre { get; set; }
        [Required(ErrorMessage = "Nome do  professor é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Nome não pode ter mais de 100 caracteres.")]
        public string NomeProfessor { get; set; }
        [Required(ErrorMessage = "Número da sala é obrigatório.")]
        public int NumeroSala { get; set; }
    }
}
