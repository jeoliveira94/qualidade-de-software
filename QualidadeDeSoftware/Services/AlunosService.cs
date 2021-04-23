
using QualidadeDeSoftware.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QualidadeDeSoftware.Services
{
    public interface AlunosService
    {
        Task<Aluno> GetAlunoById(string id);
        Task<Aluno> CadastrarAluno(string primeiroNome, string ultimoNome);
        Task<IEnumerable<Aluno>> getAlunos();
    }
}
