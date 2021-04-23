using QualidadeDeSoftware.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QualidadeDeSoftware.Services
{
    public interface AlunoTurmaService
    {
        Task<AlunoTurma> GetAlunoTurma(string turmaId, string alunoId);
        Task<AlunoTurma> SaveAlunoTurma(string turmamId, string alunoId);
        Task<AlunoTurma> UpdateAlunoTurma(AlunoTurma item);
        Task<IEnumerable<AlunoTurma>> getAlunoTurmasByTurma(string turmaId);
        

    }
}
