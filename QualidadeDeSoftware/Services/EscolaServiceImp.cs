using QualidadeDeSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualidadeDeSoftware.Services
{
    class EscolaServiceImp : EscolaService
    {
        private TurmasService TurmasService;
        private AlunosService AlunosService;
        private AlunoTurmaService AlunoTurmaService;
        public EscolaServiceImp(TurmasService turmasService, AlunosService alunosService, AlunoTurmaService alunoTurmaService)
        {
            TurmasService = turmasService;
            AlunosService = alunosService;
            AlunoTurmaService = alunoTurmaService;
        }


        public async Task<AlunoTurma> MatricularAlunoEmTurma(string turmaId, string AlunoId)
        {
            var turma = await TurmasService.GetTurma(turmaId);
            if(turma.NumeroDeAlunos >= turma.Vagas)
            {
                throw new Exception("Turma não qualificada para receber novos alunos, todas as vagas já foram preenchidas");
            }

            var aluno = await AlunosService.GetAlunoById(AlunoId);

            var alunoTurma = await AlunoTurmaService.SaveAlunoTurma(turma.Id, aluno.Id);
            turma.NumeroDeAlunos += 1;
            await TurmasService.UpdateTurma(turma);

            return alunoTurma;
            
        }
        public async Task<AlunoTurma> LancarNota(string alunoId, string turmaId, int ordem, float nota)
        {
            
            var alunoTurma = await AlunoTurmaService.GetAlunoTurma(turmaId, alunoId);

            var notas = alunoTurma.Notas;
            float? mediaTresPrimeirasNotas = 0F;
            float menorNota = 0F;
            float notaCalc;

            // Pega menor nota
            for (int i = 0; i < 3; i++)
            {
                notaCalc = (notas[i] == null) ? 0 : notas[i].Value;
                if (menorNota > notaCalc)
                    menorNota = notaCalc;
            }

            // Pega menor nota usando for loop
            mediaTresPrimeirasNotas = await AlunoTurmaService.GetAlunoTurmaMedia(turmaId, alunoId);

            if (ordem == 4 && mediaTresPrimeirasNotas >= 7)
            {
                throw new Exception("Aluno não está qualificado para nota de reposição, média das 3 primeiras notas é >= 7");
            }

            if (ordem == 4 && mediaTresPrimeirasNotas < 7 && !(nota > menorNota))
            {
                throw new Exception("Aluno não está qualificado para nota de reposição, nota de reposição menor que a nota a ser reposta");
            }

            alunoTurma.Notas[ordem - 1] = nota;
            return await AlunoTurmaService.UpdateAlunoTurma(alunoTurma);
        }
    }
}
