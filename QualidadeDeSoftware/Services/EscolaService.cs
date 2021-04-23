using QualidadeDeSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualidadeDeSoftware.Services
{
    public interface EscolaService
    {
        Task<AlunoTurma> MatricularAlunoEmTurma(string turmaId, string AlunoId);
        Task<AlunoTurma> LancarNota(string alunoId, string turmaId, int ordem, float nota);
    }
}
