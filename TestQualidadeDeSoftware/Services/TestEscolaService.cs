using Moq;
using QualidadeDeSoftware.Exceptions;
using QualidadeDeSoftware.Models;
using QualidadeDeSoftware.Repositories;
using QualidadeDeSoftware.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestQualidadeDeSoftware.Services
{
    public class TestEscolaService
    {
        [Fact]
        public async void AlunoNaoDeveSerElegivelParaNotaDeReposicao()
        {
            // Arrange
            var alunoTurma = new AlunoTurma() 
            { 
                Id = "1", AlunoId = "1", TurmaId = "1", Notas = new float?[4] { 10, 10, 10, null } 
            };
            
            var alunosService = new Mock<AlunosService>();
            var turmasService = new Mock<TurmasService>();
            var alunosTurmaService = new Mock<AlunoTurmaService>();
            
            alunosTurmaService.Setup(s => s.GetAlunoTurma(It.IsAny<string>(), It.IsAny<string>()))
                              .Returns(Task.FromResult(alunoTurma));

            alunosTurmaService.Setup(s => s.GetAlunoTurmaMedia(It.IsAny<string>(), It.IsAny<string>()))
                              .Returns(Task.FromResult((alunoTurma.Notas.Sum() / 3).Value));

            alunosTurmaService.Setup(s => s.UpdateAlunoTurma(It.IsAny<AlunoTurma>()))
                              .Returns(Task.FromResult(alunoTurma));

            var escolaService = new EscolaServiceImp(
                                    turmasService.Object, 
                                    alunosService.Object, 
                                    alunosTurmaService.Object);

            const int ordem = 4;
            const float nota = 10;

            // Act & Assert
            await Assert.ThrowsAsync(
                new AlunoNotaReposicaoException().GetType(), 
                async () => await escolaService.LancarNota(alunoTurma.AlunoId, alunoTurma.TurmaId, ordem, nota));
        }

        [Fact]
        public async void NaoDeveSerPossivelMatricularAlunoEmTurma()
        {
            // Arrange

            var turma = new Turma()
            {
                Vagas = 10,
                NumeroDeAlunos = 10,
            };

            var alunosService = new Mock<AlunosService>();
            var turmasService = new Mock<TurmasService>();
            var alunosTurmaService = new Mock<AlunoTurmaService>();

            turmasService.Setup(s => s.GetTurma(It.IsAny<string>()))
                              .Returns(Task.FromResult(turma));

            var escolaService = new EscolaServiceImp(turmasService.Object, alunosService.Object, alunosTurmaService.Object);


            // Act & Assert
            await Assert.ThrowsAsync(new TurmaSemVagaException().GetType(), async () => await escolaService.MatricularAlunoEmTurma(turma.Id, string.Empty));
        }

        [Fact]
        public async void DeveCalcularMediaCorretamente()
        {
            // Arrange

            float?[] notas = new float?[4] { 7.9F, 7.4F, 4.4F, 7.2F };
            float mediaEsperada = 7.5F;

            var alunoTurma = new AlunoTurma()
            {
                Id = "1", AlunoId = "1", TurmaId = "1", Notas = notas
            };

            var alunoTurmaRepositoryMock = new Mock<Repository<AlunoTurma>>();
            alunoTurmaRepositoryMock.Setup(r => r.GetItemAsync(It.IsAny<string>()))
                                    .Returns(Task.FromResult(alunoTurma));

            var alunosTurmaService = new AlunoTurmaServiceImp(alunoTurmaRepositoryMock.Object);

            float media = await alunosTurmaService.GetAlunoTurmaMedia(alunoTurma.TurmaId, alunoTurma.AlunoId);

            Assert.Equal(mediaEsperada, media);

        }
        
    }
}
