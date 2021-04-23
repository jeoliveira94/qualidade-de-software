using QualidadeDeSoftware.Models;
using QualidadeDeSoftware.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QualidadeDeSoftware.Services
{
    public class TurmasServiceImp : TurmasService
    {
        Repository<Turma> repository;
        public TurmasServiceImp(Repository<Turma> repository)
        {
            this.repository = repository;
        }

        public async Task<Turma> CadastrarTurma(string disciplina, int numeroDeAlunos)
        {
            string id = Guid.NewGuid().ToString();
            return await repository.AddItemAsync(new Turma() { Id = id, Disciplina = disciplina, Vagas = numeroDeAlunos, NumeroDeAlunos = 0 });
        }

        public async Task<Turma> GetTurma(string id)
        {
            return await repository.GetItemAsync(id);
        }

        public async Task<IEnumerable<Turma>> GetAllTurmas()
        {
            return await repository.GetItemsAsync();
        }

        public async Task<Turma> UpdateTurma(Turma turma)
        {
            return await repository.UpdateItemAsync(turma);
        }
    }
}
