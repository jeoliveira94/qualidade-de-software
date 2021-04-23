using QualidadeDeSoftware.Models;
using QualidadeDeSoftware.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QualidadeDeSoftware.Services
{
    public class AlunoTurmaServiceImp : AlunoTurmaService
    {
        private Repository<AlunoTurma> repository;
        public AlunoTurmaServiceImp(Repository<AlunoTurma> repository)
        {
            this.repository = repository;
        }
        public Task<AlunoTurma> UpdateAlunoTurma(AlunoTurma item)
        {
            return repository.UpdateItemAsync(item);
        }

        public async Task<AlunoTurma> SaveAlunoTurma(string turmaId, string alunoId)
        {
            const int numeroNotas = 4;
            string id = $"T-{turmaId}--A-{alunoId}";
            return await repository.AddItemAsync(new AlunoTurma() { Id = id, AlunoId = alunoId, TurmaId = turmaId, Notas = new float?[numeroNotas] });
        }

        public async Task<AlunoTurma> GetAlunoTurma(string turmaId, string alunoId)
        {
            string id = $"T-{turmaId}--A-{alunoId}";
            return await repository.GetItemAsync(id);
        }

        public async Task<IEnumerable<AlunoTurma>> getAlunoTurmasByTurma(string turmaId)
        {
            var items = (List<AlunoTurma>)(await repository.GetItemsAsync());
            var result = items.FindAll((e) => e.TurmaId.Equals(turmaId));
            return result;
        }

    }
}
