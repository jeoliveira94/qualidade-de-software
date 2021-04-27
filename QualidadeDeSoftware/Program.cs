using System;
using System.Linq;
using QualidadeDeSoftware.Services;
using QualidadeDeSoftware.Repositories;
using QualidadeDeSoftware.Models;
using System.Collections.Generic;
using QualidadeDeSoftware.Mock;
using System.Threading.Tasks;

namespace QualidadeDeSoftware
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Task.Run(main).Wait();
        }

        static async void main()
        {
            

            Repository<Turma> TurmasRepository = new RepositoryImp<Turma>();
            Repository<Aluno> AlunosRepository = new RepositoryImp<Aluno>();
            Repository<AlunoTurma> AlunoTurmaRepository = new RepositoryImp<AlunoTurma>();

            TurmasService TurmasService = new TurmasServiceImp(TurmasRepository);
            AlunosService AlunosService = new AlunosServiceImp(AlunosRepository);
            AlunoTurmaService AlunoTurmaService = new AlunoTurmaServiceImp(AlunoTurmaRepository);

            EscolaService EscolaService = new EscolaServiceImp(TurmasService, AlunosService, AlunoTurmaService);

            // Cadastrar alunos
            var alunos = AlunosMock.GetAlunos();
            int numeroDeAlunos;

            Console.WriteLine("Informe número de alunos");
            numeroDeAlunos = int.Parse(Console.ReadLine());
            if(numeroDeAlunos > 10)
            {
                Console.WriteLine("Numero maximo de alunos execedido");
                return;
            }

            // Cadastrar turmas
            var turma = await TurmasService.CadastrarTurma("Qualidade de Software", numeroDeAlunos);

            alunos = AlunosMock.GetAlunos().GetRange(0, numeroDeAlunos);
            foreach (var a in alunos)
            {
                var r = await AlunosService.CadastrarAluno(a.PrimeiroNome, a.UltimoNome);
                await EscolaService.MatricularAlunoEmTurma(turma.Id, r.Id);
            }

            var alunosTurma = await AlunoTurmaService.getAlunoTurmasByTurma(turma.Id) as List<AlunoTurma>;
            Console.WriteLine("Lançamento das notas 1, 2, 3 dos Alunos");
            float nota;
            for (int i = 0; i < alunosTurma.Count; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Console.WriteLine($"Informa nota {j} do Aluno: {(await AlunosService.GetAlunoById(alunosTurma[i].AlunoId)).UltimoNome}");
                    nota = float.Parse(Console.ReadLine());
                    await EscolaService.LancarNota(alunosTurma[i].AlunoId, turma.Id, j, nota);
                }
            }

            alunosTurma = await AlunoTurmaService.getAlunoTurmasByTurma(turma.Id) as List<AlunoTurma>;
            Console.WriteLine("Imprimindo média do alunos\n\n");
            Aluno aluno;
            float?[] notas;
            float media = 0F;
            for (int i = 0; i < alunosTurma.Count; i++)
            {
                aluno = await AlunosService.GetAlunoById(alunosTurma[i].AlunoId);
                notas = alunosTurma[i].Notas;
                media = 0f;
                Console.WriteLine(aluno.PrimeiroNome + " " + aluno.UltimoNome);
                for (int j = 0; j < 3; j++)
                {

                    if(notas[j] != null)
                    {
                        media += notas[j].Value;
                    }
                    
                }

                Console.WriteLine($"\tMédia - {media / 3}");
            }

            alunosTurma = await AlunoTurmaService.getAlunoTurmasByTurma(turma.Id) as List<AlunoTurma>;
            alunosTurma = alunosTurma.FindAll(at => (at.Notas.Sum() / 3) < 7);
            if(alunosTurma.Count > 0)
            {
                Console.WriteLine("Lançamento da Notas de Reposição");
                for (int i = 0; i < alunosTurma.Count; i++)
                {
                    Console.WriteLine($"Informa nota de reposição do Aluno: {(await AlunosService.GetAlunoById(alunosTurma[i].AlunoId)).UltimoNome}");
                    nota = float.Parse(Console.ReadLine());
                    await EscolaService.LancarNota(alunosTurma[i].AlunoId, turma.Id, 4, nota);
                }
            }

            alunosTurma = await AlunoTurmaService.getAlunoTurmasByTurma(turma.Id) as List<AlunoTurma>;
            Console.WriteLine("Imprimindo notas do alunos");

            for (int i = 0; i < alunosTurma.Count; i++)
            {
                aluno = await AlunosService.GetAlunoById(alunosTurma[i].AlunoId);
                notas = alunosTurma[i].Notas;
                media = 0f;
                Console.WriteLine(aluno.PrimeiroNome + " " + aluno.UltimoNome);

                media = await AlunoTurmaService.GetAlunoTurmaMedia(alunosTurma[i].TurmaId, alunosTurma[i].AlunoId);

                Console.WriteLine($"\tMédia - {media}");
            }

        }
    }
}
