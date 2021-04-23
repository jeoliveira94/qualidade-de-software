using QualidadeDeSoftware.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QualidadeDeSoftware.Services
{
    public interface TurmasService
    {
        Task<Turma> GetTurma(string id);
        Task<Turma> UpdateTurma(Turma turma);
        Task<Turma> CadastrarTurma(string disciplina, int numeroDeAlunos);
        Task<IEnumerable<Turma>> GetAllTurmas();
    }
}
